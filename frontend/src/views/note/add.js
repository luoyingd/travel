import {
  Button,
  Col,
  Drawer,
  Form,
  Input,
  Row,
  Space,
  AutoComplete,
} from "antd";
import { useEffect, useState } from "react";
import mapApiStore from "../../stores/common/mapApiStore";
import { observer } from "mobx-react-lite";
import usePlacesService from "react-google-autocomplete/lib/usePlacesAutocompleteService";
import { mapAPI } from "../../utils/constant";
function AddNote({ isOpen, key }) {
  const [open, setOpen] = useState(false);
  const [options, setOptions] = useState([]);
  const [address, setAddress] = useState();
  const { placePredictions, getPlacePredictions } = usePlacesService({
    apiKey: mapAPI,
    language: "en",
  });
  const getPanelValue = (searchText) => (!searchText ? [] : getMap(searchText));
  const getMap = (str) => {
    getPlacePredictions({ input: str });
    const list = [];
    placePredictions.forEach((item) => {
      list.push({ value: item.description });
    });
    return list;
  };
  const onSelect = (data) => {
    setAddress(data);
  };
  const onClose = () => {
    setOpen(false);
  };
  useEffect(() => {
    setOpen(isOpen);
    mapApiStore.getApi();
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
                <AutoComplete
                  options={options}
                  onSelect={onSelect}
                  onSearch={(text) => setOptions(getPanelValue(text))}
                  placeholder="Please enter address"
                />
              </Form.Item>
            </Col>
          </Row>
          <Row gutter={16}>
            <Col span={24}>
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
