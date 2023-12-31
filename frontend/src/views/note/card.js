import LocationOnIcon from "@mui/icons-material/LocationOn";
import { baseURL } from "../../utils/http";
import { Card, Col } from "antd";
import history from "../../utils/history";
import blank from "../../assets/img/blank.jpg"
function NoteCard({ item, filters }) {
  const { Meta } = Card;
  const toInfo = () => {
    history.push(
      "/note/info?id=" +
        item.id +
        "&category=" +
        filters.category +
        "&filterOption=" +
        filters.filterOption +
        "&keyWord=" +
        filters.keyWord
    );
  };
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
                : blank
            }
            loading="lazy"
          />
        }
        onClick={toInfo}
      >
        {item.likes >= 20 ? (
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
