import { useEffect } from "react";
import NoteCard from "./card";
import { observer } from "mobx-react-lite";
import { useSearchParams } from "react-router-dom";
import noteStore from "../../stores/notes/noteStore";
import LocationOnIcon from "@mui/icons-material/LocationOn";
import EmojiPeopleIcon from "@mui/icons-material/EmojiPeople";
import history from "../../utils/history";
import { Carousel, Row, Button, Col, Empty, Spin } from "antd";
import { baseURL } from "../../utils/http";
import { myUser } from "../../utils/auth";
import FavoriteBorderIcon from "@mui/icons-material/FavoriteBorder";
import FavoriteIcon from "@mui/icons-material/Favorite";
import loadingStore from "../../stores/common/loadingStore";

function NoteInfo() {
  const [params] = useSearchParams();
  useEffect(() => {
    noteStore.loadNote(params.get("id"));
  }, [params]);
  const toAuthor = () => {
    history.push("/note?id=" + noteStore.noteInfo.authorId);
  };
  const toMap = () => {
    window.open(noteStore.noteInfo.addressCode);
  };
  // TODO: like not refresh
  const onChange = () => {};
  return (
    <div>
      <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
        <div class="container">
          <a class="navbar-brand" href="/">
            Travel Notes
          </a>
          <div class="collapse navbar-collapse" id="navbarSupportedContent">
            <ul class="navbar-nav ms-auto mb-2 mb-lg-0">
              <li class="nav-item">
                <a
                  class="nav-link"
                  href={
                    "/note?id=" +
                    myUser.getUserId() +
                    "&category=" +
                    params.get("category") +
                    "&filterOption=" +
                    params.get("filterOption") +
                    "&keyWord=" +
                    params.get("keyWord")
                  }
                >
                  My Notes
                </a>
              </li>
              <li class="nav-item">
                <a
                  class="nav-link"
                  href={
                    "/note?" +
                    "category=" +
                    params.get("category") +
                    "&filterOption=" +
                    params.get("filterOption") +
                    "&keyWord=" +
                    params.get("keyWord")
                  }
                >
                  All Notes
                </a>
              </li>
            </ul>
          </div>
        </div>
      </nav>

      <section class="py-5">
        <div class="container px-4 px-lg-5 my-3">
          <Spin spinning={loadingStore.isLoading}>
            <article>
              <header class="mb-1">
                <h1 class="fw-bolder mb-1">{noteStore.noteInfo.title}</h1>

                <div class="text-muted fst-italic mb-4">
                  <EmojiPeopleIcon></EmojiPeopleIcon>
                  <Button onClick={toAuthor} type="text">
                    {noteStore.noteInfo.firstName +
                      " " +
                      noteStore.noteInfo.lastName}
                  </Button>
                  <LocationOnIcon></LocationOnIcon>
                  <Button onClick={toMap} type="text">
                    {noteStore.noteInfo.address}
                  </Button>
                  {noteStore.noteInfo.isLiked ? (
                    <Button
                      icon={<FavoriteIcon sx={{ color: "red" }}></FavoriteIcon>}
                      type="text"
                      onClick={noteStore.doLike}
                    ></Button>
                  ) : (
                    <Button
                      icon={<FavoriteBorderIcon></FavoriteBorderIcon>}
                      type="text"
                      onClick={noteStore.doLike}
                    ></Button>
                  )}
                  {noteStore.noteInfo.likes}
                </div>
              </header>
              <figure class="mb-5 info-box">
                {noteStore.noteInfo.photos &&
                noteStore.noteInfo.photos.length > 0 ? (
                  <Carousel afterChange={onChange} initialSlide={0} autoplay>
                    {noteStore.noteInfo.photos.split(",").map((key) => {
                      return (
                        <img
                          class="card-img-single"
                          src={baseURL + "/common/photo/" + key}
                          alt="..."
                        />
                      );
                    })}
                  </Carousel>
                ) : (
                  <img
                    class="card-img-top mb-5 mb-md-0"
                    src="empty"
                    alt="..."
                  />
                )}
              </figure>
              <section class="mb-5">
                <p class="fs-5 mb-4">{noteStore.noteInfo.content}</p>
              </section>
            </article>
          </Spin>
        </div>
      </section>

      <section class="py-5 bg-light">
        <div class="container px-4 mt-1">
          <h2 class="fw-bolder mb-4">Recommend Notes</h2>
          <div class="container px-4 mt-5">
            <Spin spinning={loadingStore.isLoading}>
              {noteStore.recommendationList.length > 0 ? (
                <Row gutter={16}>
                  {noteStore.recommendationList.map((item) => {
                    return (
                      <NoteCard
                        item={item}
                        filters={{
                          category: noteStore.listForm.categoryId,
                          filterOption: noteStore.listForm.filter,
                          keyWord: noteStore.listForm.keyWord,
                        }}
                      ></NoteCard>
                    );
                  })}
                </Row>
              ) : (
                <Col span={24}>
                  <Empty description={false} />
                </Col>
              )}
            </Spin>
          </div>
        </div>
      </section>

      <footer class="bg-light py-5">
        <div class="container px-4 px-lg-5">
          <div class="small text-center text-muted">
            Copyright &copy; 2023 - Deloria
          </div>
          <div class="small text-center text-muted">
            Images from https://www.pexels.com/
          </div>
        </div>
      </footer>

      <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js"></script>

      <script src="js/scripts.js"></script>
    </div>
  );
}

export default observer(NoteInfo);
