import { http } from "../../utils/http";
import { makeAutoObservable } from "mobx";

class MapApiStore {
  api = null;
  getApi = async () => {
    try {
      const result = await http.get("/common/getMapApi");
      this.api = result.data;
    } catch (e) {}
    return null;
  };

  constructor() {
    makeAutoObservable(this);
  }
}

const mapApiStore = new MapApiStore();
export default mapApiStore;
