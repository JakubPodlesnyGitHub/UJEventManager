import React, { useState } from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import ProductsView from "./products/ProductsView";
import AdminProductsView from "./pages/Admin";
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
            <Layout>
                <Routes>
                    <Route path="/p5/auth/" element={<Auth />} />
                    <Route path="/p5/payment/" element={<Payment />} />
                    <Route path="/p5/" element={<ProductsView shopValue={shopValue} addToShopValue={addToShopValue} />} />
                    <Route path="/p5/admin/" element={<AdminProductsView shopValue={shopValue} addToShopValue={addToShopValue} />} />
                    <Route path="/p5/shopping-cart/" element={<BasketDetails />} />
                    <Route path="/p5/payment-result/" element={<PaymentResult />} />
                </Routes>
            </Layout>
        </BrowserRouter>
    );
}

export default App;
