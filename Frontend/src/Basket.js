import { connect } from "react-redux";
import { Image } from "react-bootstrap";
import useGetRequest from "./GetRequest"

function Basket(props) {
  const data = useGetRequest("http://localhost:8080/user/1/basketItems")

  return (
    <div>
      <Image className="basket_ikon" src="./photos/shopping_bag.png"></Image>
      <p className="sum_in_basket">{data["price"]}</p>
      <p className="sum_in_basket">
        {props.items_in_basket.map((item, _) => (
          <>{item}</>
        ))}
      </p>
    </div>
  );
}

const mapStateToProps = (state) => {
  return {
    items_in_basket: state.items_in_basket,
  };
};

export default connect(mapStateToProps)(Basket);
