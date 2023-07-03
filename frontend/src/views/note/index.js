import { Button, Radio, Input, Row, Col } from "antd";
import { useEffect, useState } from "react";
import { LogoutOutlined } from "@mui/icons-material";
import { useSearchParams } from "react-router-dom";
import AddNote from "./add";
import NoteCard from "./card";
import { Empty, Carousel, Pagination, Popconfirm, message } from "antd";
import { categories } from "../../utils/constant";
import history from "../../utils/history";
import { myToken, myUser } from "../../utils/auth";
import noteStore from "../../stores/notes/noteStore";
import { observer } from "mobx-react-lite";
function Notes() {
  const { Search } = Input;
  const [params] = useSearchParams();
  const userId = params.get("id");
  const [openAdd, setOpenAdd] = useState(false);
  const [key, setKey] = useState(0);
  const [filterOption, setFilterOption] = useState(
    params.get("filterOption") ? Number(params.get("filterOption")) : 1
  );
  const [category, setCategory] = useState(
    params.get("category") ? Number(params.get("category")) : 0
  );
  const [keyWord, setKeyWord] = useState(params.get("keyWord"));
  const confirmLogout = async (e) => {
    myToken.clearToken();
    myUser.clearUserId();
    history.push("/");
    message.success("Successfully logout!");
  };
  const cancelLogout = (e) => {};
  const onChange = (e) => {
    let filter = e.target.value;
    setFilterOption(e.target.value);
    noteStore.loadNotes({ filter, userId, keyWord });
  };
  const onSearch = (value) => {
    let keyWord = value;
    setKeyWord(keyWord);
    noteStore.loadNotes({ keyWord, userId });
  };
  const onCategoryChange = (currentSlide) => {
    let category = categories[currentSlide].name;
    noteStore.loadNotes({ category, userId, keyWord });
  };
  const onPageChange = (page, pageSize) => {
    noteStore.loadNotes({ page, userId, keyWord });
  };
  useEffect(() => {
    let filter = params.get("filterOption")
      ? Number(params.get("filterOption"))
      : 1;
    let keyWord = params.get("keyWord");
    let category = params.get("category")
      ? categories[Number(params.get("category"))].name
      : categories[0].name;
    noteStore.loadNotes({ filter, category, keyWord, userId });
  }, []);
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
                  {userId ? (
                    <Popconfirm
                      title=""
                      description="Are you sure to logout?"
                      onConfirm={confirmLogout}
                      onCancel={cancelLogout}
                      okText="Yes"
                      cancelText="No"
                    >
                      <LogoutOutlined />
                      <a href="#!">Logout</a>
                    </Popconfirm>
                  ) : null}
                </li>
              </ul>
              {userId ? (
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

        <Carousel afterChange={onCategoryChange} initialSlide={category}>
          {categories.map((category) => {
            return (
              <header className={"py-5 bg-category-" + category.name}>
                <div class="container px-4 px-lg-5 my-5">
                  <div class="text-center text-white">
                    <h1 class="display-4 fw-bolder">{category.name}</h1>
                  </div>
                </div>
              </header>
            );
          })}
        </Carousel>

        <section class="py-5">
          <div style={{ paddingLeft: 60 }} class="container px-lg-5">
            <Radio.Group onChange={onChange} value={filterOption}>
              <Radio value={1}>Hottest</Radio>
              <Radio value={2}>Most Recent</Radio>
            </Radio.Group>
            <Search
              placeholder="Find something you like"
              onSearch={onSearch}
              style={{
                width: 300,
              }}
              defaultValue={keyWord}
            />
          </div>
          <div class="container px-4 px-lg-5 mt-5">
            <Row gutter={[16, 20]}>
              {noteStore.dataList.list.length > 0 ? (
                <>
                  {noteStore.dataList.list.map((item) => (
                    <NoteCard item={item}></NoteCard>
                  ))}
                </>
              ) : (
                <Col span={24}>
                  <Empty description={false} />
                </Col>
              )}
            </Row>
          </div>
          <Pagination
            style={{ textAlign: "right", marginRight: 50 }}
            defaultCurrent={1}
            total={noteStore.dataList.total}
            pageSize={6}
            onChange={onPageChange}
          />
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

export default observer(Notes);
