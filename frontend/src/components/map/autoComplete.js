import { Select } from "antd";
import { http } from "../../utils/http";
import { useState } from "react";
import { observer } from "mobx-react-lite";
import noteStore from "../../stores/notes/noteStore";
function AutoComplete({ placeholder }) {
  let currentValue;
  let timeout;
  const [data, setData] = useState([]);
  const [value, setValue] = useState();
  const fetch = (value, callback) => {
    if (timeout) {
      clearTimeout(timeout);
      timeout = null;
    }
    currentValue = value;
    const getMap = () => {
      if (currentValue === value) {
        http
          .get("/common/getMapResult/" + currentValue)
          .then((res) => {
            callback(res.data);
          })
          .catch((err) => {});
      }
    };
    if (value) {
      timeout = setTimeout(getMap, 300);
    } else {
      callback([]);
    }
  };
  const handleSearch = (newValue) => {
    fetch(newValue, setData);
  };
  const handleChange = (newValue) => {
    console.log(newValue);
    setValue(newValue);
    let addressInfo = newValue.split("@");
    noteStore.address = addressInfo[1];
    noteStore.addressCode = addressInfo[0];
  };
  return (
    <Select
      showSearch
      value={value}
      placeholder={placeholder}
      defaultActiveFirstOption={false}
      showArrow={false}
      filterOption={false}
      onSearch={handleSearch}
      onChange={handleChange}
      notFoundContent={null}
      options={(data || []).map((d) => ({
        value: d.code + "@" + d.address,
        label: d.address,
      }))}
    />
  );
}

export default observer(AutoComplete);
