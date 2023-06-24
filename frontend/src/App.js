import Home from "./views/home/index";
import { Route, Routes } from "react-router-dom";
import "./App.scss";
import { unstable_HistoryRouter as HistoryRouter } from "react-router-dom";
import history from "./utils/history";
import Error from "./views/404";
import Main from "./views/home/main";
import Login from "./views/login/login";
import SignUp from "./views/login/signup";

function App() {
  return (
    // use history if need route in non-component js
    <HistoryRouter history={history}>
      <div className="App">
        <Routes>
          <Route exact path="/" element={<Home></Home>}>
            <Route index element={<Main></Main>}></Route>
            <Route path="login" element={<Login></Login>}></Route>
            <Route path="signup" element={<SignUp></SignUp>}></Route>
          </Route>
          {/* use high-level component for auth */}
          {/* <Route
            path="/home"
            element={
              <AuthLogin>
                <Main></Main>
              </AuthLogin>
            }
          >
            <Route
              index
              element={
                <AuthLogin>
                  <Data></Data>
                </AuthLogin>
              }
            ></Route>
            <Route path="allBlog">
              <Route
                index
                element={
                  <AuthLogin>
                    <Blog></Blog>
                  </AuthLogin>
                }
              ></Route>
              <Route
                path="info/:id"
                element={
                  <AuthLogin>
                    <BlogInfo></BlogInfo>
                  </AuthLogin>
                }
              ></Route>
            </Route>
            <Route
              path="publish"
              element={
                <AuthLogin>
                  <Publish></Publish>
                </AuthLogin>
              }
            ></Route>
          </Route> */}
          {/* 404配置 */}
          <Route path="*" element={<Error></Error>}></Route>
        </Routes>
      </div>
    </HistoryRouter>
  );
}

export default App;
