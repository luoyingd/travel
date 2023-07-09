import { makeAutoObservable } from "mobx";

class UploadStore {
  fileList = [];

  constructor() {
    makeAutoObservable(this);
  }
}

const uploadStore = new UploadStore();
export default uploadStore;
