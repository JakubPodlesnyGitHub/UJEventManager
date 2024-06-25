import React, { useState } from "react";
import ProductsView from "./products/ProductsView";
import AdminProductsView from "./pages/Admin";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Auth from "./pages/Authorize";
import Layout from "./layout/Layout";
import BasketDetails from "./pages/BasketDetails";
import Payment from "./pages/Payment";
import PaymentResult from "./pages/PaymentResult";

function App() {

    const [shopValue, setShopValue] = useState(0);

    const addToShopValue = (rate) => {
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
                            <ProductsView shopValue={shopValue} addToShopValue={addToShopValue} />
                        </>
                    )}
                />
                <Route
                    path="/admin"
                    element={Layout(<AdminProductsView shopValue={shopValue} addToShopValue={addToShopValue} />)}
                />
                <Route
                    path="/shopping-cart"
                    element={Layout(<BasketDetails />)}
                />
                <Route
                    path="/payment-result"
                    element={Layout(<PaymentResult />)}
                />
            </Routes>
        </BrowserRouter>
    );
}

export default App;
