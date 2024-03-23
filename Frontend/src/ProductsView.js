import Product from "./Product";
import { useEffect, useState } from "react";
import { Row, Col, CardGroup } from "react-bootstrap";

export default function ProductsView() {
  const baseURL = `http://localhost:8080/all`;
  const [data, setData] = useState([]);

  useEffect(() => {
    fetch(baseURL)
      .then((res) => res.json())
      .then((res) => {
        setData(res);
      });
  }, [baseURL]);

  const products = data.map((val) => <Product key={val["id"]} product={val} />);

  return (
    <CardGroup>
      <Row xs={"auto"} md={"auto"} className="g-4">
        {Array.from(products).map((el, idx) => (
          <Col key={idx}> {el} </Col>
        ))}
      </Row>
    </CardGroup>
  );
}
