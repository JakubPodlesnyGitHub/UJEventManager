// Initial state with an empty array for items_in_basket
const initialState = {
  items_in_basket: [],
};

// Root reducer function that handles state updates based on actions
const rootReducer = (state = initialState, action) => {
  switch (action.type) {
    // Appending the new item to the existing items_in_basket array in the state
    case "ADD_TO_BASKET":
      return {
        ...state,
        items_in_basket: [...state.items_in_basket, action.payload.id],
      };
    default:
      return state;
  }
};

export default rootReducer;
