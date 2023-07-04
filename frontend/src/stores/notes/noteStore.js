import { makeAutoObservable } from "mobx";
import { http } from "../../utils/http";
import { myUser } from "../../utils/auth";

class NoteStore {
  address = null;
  addressCode = null;
  photoKeys = [];
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
      userId: myUser.getUserId(),
    };
    try {
      const result = await http.post("/note", data);
      return result;
    } catch (e) {}
    return null;
  };

  loadNote = (id) => {
    http
      .get("/note/" + id)
      .then((res) => {
        this.noteInfo = res.data;
        http
          .post("/note/recommendation", {
            authorId: this.noteInfo.authorId,
            category: this.noteInfo.category,
            address: this.noteInfo.address,
            id : id
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
          })
          .catch((err) => {});
      })
      .catch((err) => {});
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

  constructor() {
    makeAutoObservable(this);
  }
}

const noteStore = new NoteStore();
export default noteStore;
