import { useEffect, useState } from "react";

export default function ProductDescription(props) {
  const baseURL = `http://localhost:8080/product/${props["id"]}`;
  const [data, setData] = useState([]);

  useEffect(() => {
    fetch(baseURL)
      .then((res) => res.json())
      .then((res) => {
        setData(res);
      });
  }, [baseURL]);

  return (
    <>
      <h1>{data["name"]}</h1>
      <h2>{data["description"]}</h2>
    </>
  );
}
