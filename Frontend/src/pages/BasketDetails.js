import React from "react";
import { connect } from "react-redux";

function BasketDetails(props) {
  return (
    <>
      {
        <p className="sum_in_basket">
          {props.items_in_basket.map((item, _) => (
            <>{item}</>
          ))}
        </p>
      }
    </>
  );
}

const mapStateToProps = (state) => {
  return {
    items_in_basket: state.items_in_basket,
  };
};
export default connect(mapStateToProps)(BasketDetails);
