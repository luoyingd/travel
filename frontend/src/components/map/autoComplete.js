import { Select } from "antd";
import { http } from "../../utils/http";
import { useState } from "react";
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
    setValue(newValue);
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
        value: d.code,
        label: d.address,
      }))}
    />
  );
}

export default AutoComplete;
