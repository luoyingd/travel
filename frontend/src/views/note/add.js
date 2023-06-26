import { Button, Col, Drawer, Form, Input, Row, Space, Select } from "antd";
import { useEffect, useState } from "react";
import { observer } from "mobx-react-lite";
import AutoComplete from "../../components/map/autoComplete";
import PhotoWall from "../../components/photo/photoWall";
import { categories } from "../../utils/constant";
import noteStore from "../../stores/notes/noteStore";
import { message } from "antd";
function AddNote({ isOpen, key }) {
  const [open, setOpen] = useState(false);
  const [form] = Form.useForm();
  const onClose = () => {
    setOpen(false);
  };
  const onSubmit = async () => {
    let title = form.getFieldsValue("title");
    let description = form.getFieldsValue("description");
    let category = form.getFieldsValue("category");
    const result = await noteStore.addNote(title, description, category);
    if (result) {
      message.success("Successfully posted!", [3]);
      onClose();
      // TODO: load list
    }
  };
  useEffect(() => {
    setOpen(isOpen);
    noteStore.photoKeys = [];
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
            <Button onClick={onSubmit} type="primary">
              Submit
            </Button>
          </Space>
        }
      >
        <Form layout="vertical" form={form}>
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
                name="category"
                label="Category"
                rules={[
                  {
                    required: true,
                    message: "Please select a category",
                  },
                ]}
              >
                <Select
                  options={categories.map((item) => {
                    return { value: item, label: item };
                  })}
                  placeholder="Please select a category"
                />
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
              <Form.Item name="fileKeyList" label="Photos">
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
