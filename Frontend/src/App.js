import React, { useState } from "react";
import Basket from "./bar/Basket";
import ProductsView from "./products/ProductsView";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Auth from "./pages/Authorize";
import Layout from "./layout/Layout";
import BasketDetails from "./pages/BasketDetails";
import Payment from "./pages/Payment";

function App() {
    // State to store the shop value
    const [shopValue, setShopValue] = useState(0);

    // Function to handle adding product rate to shop value
    const addToShopValue = (rate) => {
        // Update shopValue state by adding the rate
        const newValue = shopValue + rate;
        console.log("New shop value:", newValue);
        setShopValue(newValue);
    };

    return (
        <BrowserRouter>
            <Routes>
                <Route
                    path="/auth"
                    element={Layout(<Auth />)}
                />
                <Route
                    path="/payment"
                    element={Layout(<Payment />)}
                />
                <Route
                    path="/"
                    element={Layout(
                        <>
                            {/* Pass shopValue and addToShopValue function as props */}
                            <ProductsView shopValue={shopValue} addToShopValue={addToShopValue} />
                            {/* Pass shopValue to the Basket component */}
                            {/*<Basket shopValue={shopValue} />*/}
                        </>
                    )}
                />
                <Route
                    path="/shopping-cart"
                    element={Layout(<BasketDetails />)}
                />
            </Routes>
        </BrowserRouter>
    );
}

export default App;
