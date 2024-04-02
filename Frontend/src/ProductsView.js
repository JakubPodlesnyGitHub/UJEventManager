import Product from "./Product";
import useGetRequest from "./GetRequest"
import { Row, Col, CardGroup } from "react-bootstrap";

export default function ProductsView() {
  const data = useGetRequest("http://localhost:8080/all")

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
