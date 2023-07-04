import { useEffect } from "react";
import NoteCard from "./card";
import { observer } from "mobx-react-lite";
import { useSearchParams } from "react-router-dom";
import noteStore from "../../stores/notes/noteStore";
import LocationOnIcon from "@mui/icons-material/LocationOn";
import EmojiPeopleIcon from "@mui/icons-material/EmojiPeople";
import history from "../../utils/history";
import { Carousel, Row, Button } from "antd";
import { baseURL } from "../../utils/http";

function NoteInfo() {
  const [params] = useSearchParams();
  useEffect(() => {
    noteStore.loadNote(params.get("id"));
    // TODO: load recommendation
  }, []);
  const toAuthor = () => {
    history.push("/note?id=" + noteStore.noteInfo.authorId);
  };
  const toMap = () => {
    window.open(noteStore.noteInfo.addressCode);
  };
  const onChange = () => {};
  return (
    <div>
      <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
        <div class="container">
          <a class="navbar-brand" href="/">
            Travel Notes
          </a>
        </div>
      </nav>

      <section class="py-5">
        <div class="container px-4 px-lg-5 my-3">
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
                <img class="card-img-top mb-5 mb-md-0" src="empty" alt="..." />
              )}
            </figure>
            <section class="mb-5">
              <p class="fs-5 mb-4">{noteStore.noteInfo.content}</p>
            </section>
          </article>
        </div>
      </section>

      <section class="py-5 bg-light">
        <div class="container px-4 mt-1">
          <h2 class="fw-bolder mb-4">Recommend Notes</h2>
          <div class="container px-4 mt-5">
            <Row gutter={16}>
              <NoteCard item={noteStore.noteInfo}></NoteCard>
              <NoteCard item={noteStore.noteInfo}></NoteCard>
              <NoteCard item={noteStore.noteInfo}></NoteCard>
            </Row>
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
    </div>
  );
}

export default observer(NoteInfo);
