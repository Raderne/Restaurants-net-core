import { StrictMode } from "react";
import { createRoot } from "react-dom/client";
import { BrowserRouter, Routes, Route } from "react-router";
import "./index.css";
import App from "./App.jsx";
import Chat from "./Chat.jsx";
import Login from "./Login.jsx";
import Order from "./Order.jsx";

createRoot(document.getElementById("root")).render(
	<StrictMode>
		<BrowserRouter>
			<Routes>
				<Route
					path="/"
					element={<App />}
				/>
				<Route
					path="/chat"
					element={<Chat />}
				/>
				<Route
					path="/login"
					element={<Login />}
				/>
				<Route
					path="/order"
					element={<Order />}
				/>
			</Routes>
		</BrowserRouter>
	</StrictMode>,
);
