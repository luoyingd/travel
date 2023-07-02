import { makeAutoObservable } from "mobx";
import { http } from "../../utils/http";
import { myUser } from "../../utils/auth";

class NoteStore {
  address = null;
  addressCode = null;
  photoKeys = [];
  addNote = async ({ title, description, category }) => {
    let data = {
      title: title,
      description: description,
      category: category,
      photoKeys: this.photoKeys,
      addressCode: this.addressCode,
      address: this.address,
      userId : myUser.getUserId()
    };
    try {
      const result = await http.post("/note", data);
      return result;
    } catch (e) {}
    return null;
  };

  // loadNotes = async({category, })

  constructor() {
    makeAutoObservable(this);
  }
}

const noteStore = new NoteStore();
export default noteStore;
