import {
  Button,
  Col,
  Drawer,
  Form,
  Input,
  Row,
  Space,
} from "antd";
import { useEffect, useState } from "react";
import { observer } from "mobx-react-lite";
import AutoComplete from "../../components/map/autoComplete";
import PhotoWall from "../../components/upload/photoWall";
function AddNote({ isOpen, key }) {
  const [open, setOpen] = useState(false);
  const onClose = () => {
    setOpen(false);
  };
  useEffect(() => {
    setOpen(isOpen);
  }, []);
  return (
    <>
      <Drawer
        title="Post your new note!"
        width={720}
        onClose={onClose}
        open={open}
        bodyStyle={{
          paddingBottom: 80,
        }}
        extra={
          <Space>
            <Button onClick={onClose}>Cancel</Button>
            <Button onClick={onClose} type="primary">
              Submit
            </Button>
          </Space>
        }
      >
        <Form layout="vertical" hideRequiredMark>
          <Row gutter={20}>
            <Col span={20}>
              <Form.Item
                name="title"
                label="Title"
                rules={[
                  {
                    required: true,
                    message: "Please enter a title",
                  },
                ]}
              >
                <Input placeholder="Please enter a title" />
              </Form.Item>
            </Col>
          </Row>
          <Row gutter={20}>
            <Col span={20}>
              <Form.Item
                name="address"
                label="Address"
                rules={[
                  {
                    required: true,
                    message: "Please select address",
                  },
                ]}
              >
                <AutoComplete placeholder="Please enter address" />
              </Form.Item>
            </Col>
          </Row>
          <Row gutter={16}>
            <Col span={22}>
              <Form.Item
                name="fileKeyList"
                label="Photos"
              >
                <PhotoWall></PhotoWall>
              </Form.Item>
            </Col>
          </Row>
          <Row gutter={16}>
            <Col span={22}>
              <Form.Item
                name="description"
                label="Description"
                rules={[
                  {
                    required: true,
                    message: "please enter description",
                  },
                ]}
              >
                <Input.TextArea
                  rows={8}
                  maxLength={650}
                  placeholder="Please enter description, maximum 600 words"
                />
              </Form.Item>
            </Col>
          </Row>
        </Form>
      </Drawer>
    </>
  );
}

export default observer(AddNote);
