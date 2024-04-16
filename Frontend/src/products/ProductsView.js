import Product from "./Product";
import useGetRequest from "../api/Requests";
import { Row, Col, CardGroup, Card, CardTitle, CardImg } from "react-bootstrap";
import { useEffect, useState } from "react";

export default function ProductsView() {

  const [isLoading, setIsLoading] = useState(false);
  const data = useGetRequest("https://localhost:44398/api/Product");

  const products = data.map((val) => <Product idx={val["name"]} product={val} />);


  return (
      <Row style={{padding: '5px'}} xs={2} md={5} className="g-4">
        {Array.from(products).map((el, idx) => (
          <Col key={idx}>
            <Card>
              <CardImg src={el.props.product.picture}></CardImg>
              <Card.Body>
                <CardTitle>{el.props.idx}</CardTitle>
                <Card.Text>{el.props.product.description}</Card.Text>
              </Card.Body>
              </Card>
          </Col>
        ))}
      </Row>
  );
}
