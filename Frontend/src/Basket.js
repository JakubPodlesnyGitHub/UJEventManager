import { connect } from "react-redux";
import { Image } from "react-bootstrap";
import { useEffect, useState } from "react";

function Basket(props) {
  const baseURL = `http://localhost:8080/user/1/basketItems`;
  const [data, setData] = useState([]);

  useEffect(() => {
    fetch(baseURL)
      .then((res) => res.json())
      .then((res) => {
        setData(res);
      });
  }, [baseURL]);

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
