import { useEffect } from "react";
import NoteCard from "./card";
import { observer } from "mobx-react-lite";
import { useSearchParams } from "react-router-dom";
import noteStore from "../../stores/notes/noteStore";
import LocationOnIcon from "@mui/icons-material/LocationOn";
import EmojiPeopleIcon from "@mui/icons-material/EmojiPeople";
import history from "../../utils/history";
import { Button, Carousel } from "antd";
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
  }
  const onChange = () => {};
  return (
    <div>
      <nav class="navbar navbar-expand-lg navbar-light bg-light">
        <div class="container px-4 px-lg-5">
          <a class="navbar-brand" href="/">
            Travel Notes
          </a>
        </div>
      </nav>

      <section class="py-5">
        <div class="container px-4 px-lg-5 my-5">
          <div class="row gx-4 gx-lg-5 align-items-center">
            <div class="col-md-6 info-box">
              {noteStore.noteInfo.photos &&
              noteStore.noteInfo.photos.length > 0 ? (
                <Carousel afterChange={onChange} initialSlide={0} autoplay>
                  {noteStore.noteInfo.photos.split(",").map((key) => {
                    return (
                      <img
                        class="card-img-info mb-5 mb-md-0"
                        src={baseURL + "/common/photo/" + key}
                        alt="..."
                      />
                    );
                  })}
                </Carousel>
              ) : (
                <img class="card-img-top mb-5 mb-md-0" src="error" alt="..." />
              )}
            </div>
            <div class="col-md-6">
              <h1 class="display-6 fw-bolder">{noteStore.noteInfo.title}</h1>
              <div class="fs-6 mt-3 mb-3">
                <EmojiPeopleIcon></EmojiPeopleIcon>
                <Button onClick={toAuthor} type="text">
                  {noteStore.noteInfo.firstName +
                    " " +
                    noteStore.noteInfo.lastName}
                </Button>
              </div>
              <div class="fs-5 mb-4">
                <LocationOnIcon></LocationOnIcon>
                <Button onClick={toMap} type="text">
                  {noteStore.noteInfo.address}
                </Button>
              </div>
              <p class="lead">{noteStore.noteInfo.content}</p>
            </div>
          </div>
        </div>
      </section>

      <section class="py-5 bg-light">
        <div class="container px-4 px-lg-5 mt-5">
          <h2 class="fw-bolder mb-4">Recommend Notes</h2>
          <div class="row gx-4 gx-lg-5 row-cols-2 row-cols-md-3 row-cols-xl-4 justify-content-center">
            <div class="col mb-5">
              <div class="card h-100">
                <NoteCard item={noteStore.noteInfo}></NoteCard>
              </div>
            </div>
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
