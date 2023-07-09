import { Button, Col, Drawer, Form, Input, Row, Space, Select } from "antd";
import { useEffect, useState } from "react";
import { observer } from "mobx-react-lite";
import AutoComplete from "../../components/map/autoComplete";
import PhotoWall from "../../components/photo/photoWall";
import { categories } from "../../utils/constant";
import noteStore from "../../stores/notes/noteStore";
import { message } from "antd";
function AddNote({ isOpen, key, callback }) {
  const [open, setOpen] = useState(false);
  const [form] = Form.useForm();
  const onClose = () => {
    setOpen(false);
  };
  const getFormatTextArea = (strValue) => {
    return strValue
      .toString()
      .replace(/\r\n/g, "<br/>")
      .replace(/\n/g, "<br/>")
      .replace(/\s/g, " ");
  };
  const onSubmit = async () => {
    if (noteStore.hasUploading) {
      message.error("You have photo uploading in process!");
      return;
    }
    let title = form.getFieldValue("title");
    let description = form.getFieldValue("description");
    let category = form.getFieldValue("category");
    if (
      !title ||
      !description ||
      !category ||
      !noteStore.address ||
      !noteStore.addressCode
    ) {
      message.error("Please input all necessary fields!");
      return;
    }
    description = getFormatTextArea(description);
    const result = await noteStore.addNote({ title, description, category });
    if (result) {
      message.success("Successfully posted!", [3]);
      onClose();
      callback();
    }
  };
  useEffect(() => {
    setOpen(isOpen);
    noteStore.hasUploading = false;
    noteStore.photoKeys = [];
    noteStore.address = null;
    noteStore.addressCode = null;
  }, [key]);
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
                <Input placeholder="Please enter a title" maxLength={50} />
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
                    return { value: item.name, label: item.name };
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
                <PhotoWall key={Math.random}></PhotoWall>
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
                  maxLength={2000}
                  placeholder="Please enter description, maximum 2000 characters"
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
