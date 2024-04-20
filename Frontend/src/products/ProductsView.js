import Product from "./Product";
import useGetRequest from "../api/Requests";
import { Row, Col, CardGroup } from "react-bootstrap";

export default function ProductsView() {

  const data = useGetRequest("http://localhost:5164/api/Product");

  const products = data.map((val) => <Product key={val["id"]} product={val} />);

  return (
      <CardGroup className="products_view">
        <Row xs={"auto"} md={"auto"} className="g-4">
          {Array.from(products).map((el, idx) => (
              <Col key={idx}> {el} </Col>
          ))}
        </Row>
      </CardGroup>
  );
}
