import React, { useEffect, useState } from "react";
import { useLocation, useNavigate } from "react-router-dom";
import { Spinner, Container, Row, Col } from "react-bootstrap";

const PaymentResult = () => {
    const location = useLocation();
    const navigate = useNavigate();
    const [loading, setLoading] = useState(true);
    const [transactionSuccess, setTransactionSuccess] = useState(null);

    useEffect(() => {
        // Redirect if not coming from the "Pay" button
        if (!location.state?.fromPayButton) {
            navigate('/');
            return;
        }

        // Simulate loading time (3 to 5 seconds)
        const loadingTime = Math.floor(Math.random() * 2000) + 3000;
        // add removing avaialibility in products here
        setTimeout(() => {
            setTransactionSuccess(true);
            setLoading(false);
        }, loadingTime);

    }, [location, navigate]);

    if (loading) {
        return (
            <Container className="d-flex flex-column justify-content-center align-items-center" style={{ height: "100vh" }}>
                <Spinner animation="border" />
                <h2 className="mt-3">Transaction in progress...</h2>
            </Container>
        );
    }

    return (
        <Container className="d-flex justify-content-center align-items-center" style={{ height: "100vh" }}>
            {transactionSuccess ? (
                <h1>Transaction Successful!</h1>
            ) : (
                <h1>Transaction Failed. Please try again.</h1>
            )}
        </Container>
    );
};

export default PaymentResult;