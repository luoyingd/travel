import { PlusOutlined } from "@ant-design/icons";
import { Upload, Modal, message } from "antd";
import { useState } from "react";
import { baseURL, http } from "../../utils/http";
import { observer } from "mobx-react-lite";
import noteStore from "../../stores/notes/noteStore";
const PhotoWall = () => {
  const getBase64 = (file) =>
    new Promise((resolve, reject) => {
      const reader = new FileReader();
      reader.readAsDataURL(file);
      reader.onload = () => resolve(reader.result);
      reader.onerror = (error) => reject(error);
    });
  const [previewOpen, setPreviewOpen] = useState(false);
  const [previewImage, setPreviewImage] = useState("");
  const [previewTitle, setPreviewTitle] = useState("");
  const [fileList, setFileList] = useState([]);
  const handleChange = ({ fileList: newFileList }) => setFileList(newFileList);
  const handleCancel = () => setPreviewOpen(false);
  const handlePreview = async (file) => {
    if (!file.url && !file.preview) {
      file.preview = await getBase64(file.originFileObj);
    }
    setPreviewImage(file.url || file.preview);
    setPreviewOpen(true);
    setPreviewTitle(
      file.name || file.url.substring(file.url.lastIndexOf("/") + 1)
    );
  };
  const uploadButton = (
    <div>
      <PlusOutlined />
      <div
        style={{
          marginTop: 8,
        }}
      >
        Upload
      </div>
    </div>
  );
  const beforeUpload = async (file) => {
    // check file type
    let check =
      (file.type === "image/jpeg" ||
        file.type === "image/png" ||
        file.type === "image/jpg") &&
      file.size / 1024 / 1024 < 10;
    if (!check) {
      file.status = "error";
      message.error(
        "You can only upload JPG/PNG/JPEG file, and each file should be smaller than 10MB!"
      );
      setFileList([...fileList, file]);
    } else {
      file.status = "uploading";
      let uid = file.uid;
      let newList = [...fileList, file];
      setFileList(newList);
      // do upload here
      let formData = new FormData();
      formData.append("file", file);
      http
        .post("/common/upload", formData)
        .then((res) => {
          noteStore.photoKeys.push(res.data);
          // find the file and replace status
          const newFileList = newList.map((file) => {
            if (file.uid == uid) {
              file.status = "success";
              file.url = baseURL + "/common/photo/" + res.data;
            }
            return file;
          });
          setFileList(newFileList);
        })
        .catch((err) => {
          // find the file and replace status
          const newFileList = newList.map((file) => {
            if (file.uid == uid) {
              file.status = "error";
            }
            return file;
          });
          setFileList(newFileList);
        });
    }
    return false;
  };
  return (
    <>
      <Upload
        beforeUpload={beforeUpload}
        listType="picture-card"
        fileList={fileList}
        onPreview={handlePreview}
        onChange={handleChange}
      >
        {fileList.length >= 6 ? null : uploadButton}
      </Upload>
      <Modal
        open={previewOpen}
        title={previewTitle}
        footer={null}
        onCancel={handleCancel}
      >
        <img
          alt="example"
          style={{
            width: "100%",
          }}
          src={previewImage}
        />
      </Modal>
    </>
  );
};
export default observer(PhotoWall);
