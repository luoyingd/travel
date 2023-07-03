import LocationOnIcon from "@mui/icons-material/LocationOn";
import { baseURL } from "../../utils/http";
import { Card, Col} from "antd";
import history from "../../utils/history";
function NoteCard({ item }) {
  const { Meta } = Card;
  const toInfo = () => {
    history.push("/note/info?id=" + item.id);
  }
  return (
    <Col span={8}>
      <Card
        style={{
          width: 320,
        }}
        className="card-antd"
        cover={
          <img
            className="card-img-item"
            alt="error"
            src={
              item.photos && item.photos.length > 0
                ? baseURL + "/common/photo/" + item.photos.split(",")[0]
                : "error"
            }
          />
        }
        onClick={toInfo}
      >
        {item.likes > 20 ? (
          <div
            class="badge bg-danger text-white position-absolute"
            style={{ top: 0.5, right: 0.5 }}
          >
            Hot
          </div>
        ) : null}
        <Meta
          title={
            <div className="text-center" title={item.title}>
              {item.title}
            </div>
          }
          description={
            <div class="text-center form-text">
              <LocationOnIcon></LocationOnIcon>
              {item.address}
            </div>
          }
        />
      </Card>
    </Col>
  );
}

export default NoteCard;
