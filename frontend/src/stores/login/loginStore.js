import { http } from "../../utils/http";
import { makeAutoObservable } from "mobx";
import { myToken, myUser } from "../../utils/auth";

class LoginStore {
  login = async (data) => {
    try {
      const result = await http.post("/user/login", {
        email: data.email,
        password: data.password,
      });
      this.saveToken(result);
      return result;
    } catch (e) {}
    return null;
  };

  loginGoogle = async (accessToken) => {
    try {
      const result = await http.post("/user/login", {
        isFromGoogle: true,
        accessToken: accessToken,
      });
      this.saveToken(result);
      return result;
    } catch (e) {}
    return null;
  };

  saveToken = (loginResult) => {
    const token = loginResult.data.token;
    const userId = loginResult.data.userId;
    myToken.saveToken(token);
    myUser.saveUserId(userId);
  };

  register = async (data) => {
    try {
      const result = await http.post("/user/register", {
        firstName: data.firstName,
        lastName: data.lastName,
        password: data.password,
        email: data.email,
      });
      return result;
    } catch (e) {}
    return null;
  };

  // resetPwdSendMail = async (email) => {
  //   const result = await http.post("/user/resetPwdSendMail", {
  //     email: email,
  //   });
  //   return result;
  // };

  // resetPwd = async (password, token, email) => {
  //   const result = await http.post("/user/resetPwd", {
  //     password: password,
  //     token: token,
  //     email: email,
  //   });
  //   return result;
  // };

  // logout = async () => {
  //   const result = await http.post("/user/logout", {
  //     userId: myUser.getUserId(),
  //   });
  //   myToken.clearToken();
  //   myUser.clearUserId();
  //   return result;
  // };

  constructor() {
    makeAutoObservable(this);
  }
}

const loginStore = new LoginStore();
export default loginStore;
