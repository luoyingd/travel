import { Button, Radio, Input } from "antd";
import { useEffect, useState } from "react";
import { useSearchParams } from "react-router-dom";
import AddNote from "./add";
import { AudioOutlined } from "@ant-design/icons";
import NoteCard from "./card";
import { Empty } from "antd";
function Notes() {
  const [params] = useSearchParams();
  const id = params.get("id");
  const [openAdd, setOpenAdd] = useState(false);
  const [key, setKey] = useState(0);
  const [value, setValue] = useState(1);
  const { Search } = Input;
  const [list, setList] = useState([]);
  const suffix = (
    <AudioOutlined
      style={{
        fontSize: 16,
        color: "#1677ff",
      }}
    />
  );
  const onChange = (e) => {
    console.log("radio checked", e.target.value);
    setValue(e.target.value);
  };
  const onSearch = (value) => console.log(value);
  useEffect(() => {}, []);
  return (
    <div>
      <body>
        <nav class="navbar navbar-expand-lg navbar-light bg-light">
          <div class="container px-4 px-lg-5">
            <a class="navbar-brand" href="/">
              Travel Notes
            </a>
            <div class="collapse navbar-collapse" id="navbarSupportedContent">
              <ul class="navbar-nav me-auto mb-2 mb-lg-0 ms-lg-4">
                <li class="nav-item">
                  {id ? (
                    <a class="nav-link active" aria-current="page" href="#!">
                      Logout
                    </a>
                  ) : null}
                </li>
              </ul>
              {id ? (
                <Button
                  className="btn-center btn-add"
                  size="large"
                  onClick={() => {
                    setOpenAdd(true);
                    setKey(key + 1);
                  }}
                >
                  Add New
                </Button>
              ) : null}
            </div>
          </div>
        </nav>

        <AddNote isOpen={openAdd} key={key}></AddNote>

        <header class="bg-dark py-5">
          <div class="container px-4 px-lg-5 my-5">
            <div class="text-center text-white">
              <h1 class="display-4 fw-bolder">Shop in style</h1>
              <p class="lead fw-normal text-white-50 mb-0">
                With this shop hompeage template
              </p>
            </div>
          </div>
        </header>

        <section class="py-5">
          <div style={{ paddingLeft: 60 }} class="container px-lg-5">
            <Radio.Group onChange={onChange} value={value}>
              <Radio value={1}>Hottest</Radio>
              <Radio value={2}>Most Recent</Radio>
            </Radio.Group>
            <Search
              placeholder="Find something you like"
              onSearch={onSearch}
              style={{
                width: 300,
              }}
            />
          </div>
          <div class="container px-4 px-lg-5 mt-5">
            <div class="row gx-4 gx-lg-5 row-cols-2 row-cols-md-3 row-cols-xl-4 justify-content-center">
              {list.length > 0 ? (
                <>
                  {list.map((item) => (
                    <NoteCard></NoteCard>
                  ))}
                </>
              ) : (
                <Empty description={false} />
              )}
            </div>
          </div>
        </section>

        <footer class="bg-light py-5">
          <div class="container px-4 px-lg-5">
            <div class="small text-center text-muted">
              Copyright &copy; 2023 - Deloria
            </div>
          </div>
        </footer>

        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js"></script>

        <script src="js/scripts.js"></script>
      </body>
    </div>
  );
}

export default Notes;
