export const addToBasket = (id) => {
  return {
    type: "ADD_TO_BASKET",
    payload: { id: id },
  };
};
