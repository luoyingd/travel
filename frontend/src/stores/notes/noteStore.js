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
    category: null,
    userId: 0,
  };
  dataList = {
    total: 0,
    list: [],
  };
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

  loadNotes = ({ filter, category, keyWord, page, userId }) => {
    if (filter) {
      this.listForm.filter = filter;
    }
    if (category) {
      this.listForm.category = category;
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
