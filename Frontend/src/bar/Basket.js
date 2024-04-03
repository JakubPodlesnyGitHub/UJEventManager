import { connect } from "react-redux";
import useGetRequest from "../api/Requests";
import { Col, Container, Image, Row } from "react-bootstrap";

function Basket(props) {
  return (
    <div>
      <Container>
        <Row>
          <Col>
            <Image src={"./photos/card.svg"}></Image>
          </Col>
          <Col>
            <p className="allign_centrally">50zł</p>
          </Col>
        </Row>
      </Container>
    </div>
  );
}

const mapStateToProps = (state) => {
  return {
    items_in_basket: state.items_in_basket,
  };
};

export default connect(mapStateToProps)(Basket);
