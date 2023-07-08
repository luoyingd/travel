import { makeAutoObservable } from "mobx";
import { http } from "../../utils/http";
import loadingStore from "../common/loadingStore";

class NoteStore {
  address = null;
  addressCode = null;
  photoKeys = [];
  hasUploading = false;
  listForm = {
    offset: 1,
    size: 6,
    keyWord: null,
    filter: null,
    categoryId: null,
    category: null,
    userId: 0,
  };
  dataList = {
    total: 0,
    list: [],
  };
  noteInfo = {
    address: null,
    addressCode: null,
    authorId: 0,
    content: null,
    firstName: null,
    id: 0,
    lastName: null,
    likes: 0,
    photos: null,
    title: null,
    category: null,
    isLiked: false,
    isSubscribed: false
  };
  recommendationList = [];
  addNote = async ({ title, description, category }) => {
    let data = {
      title: title,
      description: description,
      category: category,
      photoKeys: this.photoKeys,
      addressCode: this.addressCode,
      address: this.address,
    };
    try {
      const result = await http.post("/note", data);
      return result;
    } catch (e) {}
    return null;
  };

  loadNote = (id) => {
    loadingStore.isLoading = true;
    http
      .get("/note/" + id)
      .then((res) => {
        this.noteInfo = res.data;
        http
          .post("/note/recommendation", {
            authorId: this.noteInfo.authorId,
            category: this.noteInfo.category,
            address: this.noteInfo.address,
            id: id,
          })
          .then((res) => {
            this.recommendationList = [];
            res.data.map((item) => {
              this.recommendationList.push({
                address: item.address,
                id: item.id,
                likes: item.likes,
                photos: item.photos,
                title: item.title,
              });
            });
            loadingStore.isLoading = false;
          })
          .catch((err) => {
            loadingStore.isLoading = false;
          });
      })
      .catch((err) => {
        loadingStore.isLoading = false;
      });
  };

  loadNotes = ({ filter, category, keyWord, page, userId }) => {
    if (filter) {
      this.listForm.filter = filter;
    }
    if (category) {
      this.listForm.category = category.name;
      this.listForm.categoryId = category.id;
    }
    if (keyWord) {
      this.listForm.keyWord = keyWord;
    } else {
      this.listForm.keyWord = null;
    }
    if (page) {
      this.listForm.offset = page;
    }
    if (userId) {
      this.listForm.userId = Number(userId);
    }
    http
      .post("/note/info", this.listForm)
      .then((res) => {
        this.dataList.total = res.data.total;
        this.dataList.list = res.data.notes;
      })
      .catch((err) => {});
  };

  doLike = () => {
    let like = this.noteInfo.isLiked ? 0 : 1;
    http
      .post("/like/" + like + "/" + this.noteInfo.id)
      .then((res) => {
        if (like == 0) {
          this.noteInfo.likes =
            this.noteInfo.likes == 0
              ? this.noteInfo.likes
              : this.noteInfo.likes - 1;
        } else {
          this.noteInfo.likes += 1;
        }
        this.noteInfo.isLiked = !this.noteInfo.isLiked;
      })
      .catch((err) => {});
  };

  doSubscribe = () => {
    let subscribed = this.noteInfo.isSubscribed ? 0 : 1;
    http
      .post("/user/subscribe", {
        authorId : this.noteInfo.authorId,
        subscribe : subscribed
      })
      .then((res) => {
        this.noteInfo.isSubscribed = !this.noteInfo.isSubscribed;
      })
      .catch((err) => {});
  }

  constructor() {
    makeAutoObservable(this);
  }
}

const noteStore = new NoteStore();
export default noteStore;
