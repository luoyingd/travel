import { PlusOutlined } from "@ant-design/icons";
import { Upload, Modal, message } from "antd";
import { useEffect, useState } from "react";
import { baseURL, http } from "../../utils/http";
import { observer } from "mobx-react-lite";
import noteStore from "../../stores/notes/noteStore";
import uploadStore from "../../stores/common/uploadStore";
const PhotoWall = ({ key }) => {
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
  const handleChange = ({ fileList: newFileList }) => uploadStore.fileList = newFileList;
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
  useEffect(() => {
    uploadStore.fileList = [];
  }, [key]);
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
      file.size / 1024 / 1024 < 3;
    if (!check) {
      file.status = "error";
      message.error(
        "You can only upload JPG/PNG/JPEG file, and each file should be smaller than 3MB!"
      );
      uploadStore.fileList.push(file);
    } else {
      noteStore.hasUploading = true;
      file.status = "uploading";
      let uid = file.uid;
      uploadStore.fileList.push(file);
      // do upload here
      let formData = new FormData();
      formData.append("file", file);
      http
        .post("/common/upload", formData)
        .then((res) => {
          noteStore.photoKeys.push(res.data);
          // find the file and replace status
          const newFileList = uploadStore.fileList.map((file) => {
            if (file.uid == uid) {
              file.status = "success";
              file.url = baseURL + "/common/photo/" + res.data;
            }
            return file;
          });
          uploadStore.fileList = newFileList;
        })
        .catch((err) => {
          // find the file and replace status
          const newFileList = uploadStore.fileList.map((file) => {
            if (file.uid == uid) {
              file.status = "error";
            }
            return file;
          });
          uploadStore.fileList = newFileList;
        })
        .finally(() => {
          noteStore.hasUploading = false;
        });
    }
    return false;
  };
  return (
    <>
      <Upload
        beforeUpload={beforeUpload}
        listType="picture-card"
        fileList={uploadStore.fileList}
        onPreview={handlePreview}
        onChange={handleChange}
      >
        {uploadStore.fileList.length >= 6 ? null : uploadButton}
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
