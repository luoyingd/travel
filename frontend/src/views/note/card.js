import LocationOnIcon from "@mui/icons-material/LocationOn";
import { baseURL } from "../../utils/http";
import { Card, Col } from "antd";
function NoteCard({ item }) {
  const { Meta } = Card;
  return (
    <Col span={8}>
      <Card
        style={{
          width: 320
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
      >
        <Meta
          title={<div className="text-center" title={item.title}>{item.title}</div>}
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
