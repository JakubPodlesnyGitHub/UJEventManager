import React from "react";
import { Provider } from "react-redux";
import "bootstrap/dist/css/bootstrap.min.css";
import "./index.css";
import { createRoot } from 'react-dom/client';

import { PersistGate } from "redux-persist/integration/react";
import { store, persistor } from "./state/store";
import { AuthProvider } from "./context/AuthContext";
import App from "./App";

const container = document.getElementById('root');
const root = createRoot(container); // createRoot(container!) if you use TypeScript
root.render(
    <AuthProvider>
        <Provider store={store}>
            <PersistGate loading={null} persistor={persistor}>
                <App />
            </PersistGate>
        </Provider>
    </AuthProvider>
);