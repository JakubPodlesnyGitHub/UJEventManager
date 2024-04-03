import Basket from "./bar/Basket";

import ProductsView from "./products/ProductsView";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Auth from "./pages/Authorize";
import Layout from "./layout/Layout";
import BasketDetails from "./pages/BasketDetails";

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route
          path="/auth"
          element={Layout(
            <>
              <Auth />
            </>,
          )}
        />
        <Route
          path="/"
          element={Layout(
            <>
              <ProductsView />
            </>,
          )}
        />
        <Route
          path="/shopping-cart"
          element={Layout(
            <>
              <BasketDetails />
            </>,
          )}
        />
      </Routes>
    </BrowserRouter>
  );
}

export default App;
