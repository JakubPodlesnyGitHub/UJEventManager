import { ADD_TO_CART, REMOVE_FROM_CART } from "./actions";

const initialState = {
  cartProducts: [],
};

const rootReducer = (state = initialState, action) => {
  switch (action.type) {
    case ADD_TO_CART:
      const productExists = state.cartProducts.find(product => product.id === action.payload.id);
      if (productExists) {
        return {
          ...state,
          cartProducts: state.cartProducts.map(product =>
              product.id === action.payload.id
                  ? { ...product, quantity: product.quantity + 1 }
                  : product
          ),
        };
      }
      return {
        ...state,
        cartProducts: [...state.cartProducts, { ...action.payload, quantity: 1 }],
      };
    case REMOVE_FROM_CART:
      return {
        ...state,
        cartProducts: state.cartProducts
            .map(product =>
                product.id === action.payload
                    ? { ...product, quantity: product.quantity - 1 }
                    : product
            )
            .filter(product => product.quantity > 0),
      };
    default:
      return state;
  }
};

export default rootReducer;
