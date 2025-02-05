import "./App.css";
import { Routes, Route } from "react-router-dom";
import Chat from "./Chat";
import Login from "./Login";
import Order from "./Order";

function App() {
	return (
		<>
			<header className="App-header">
				<nav>
					<ul>
						<li>
							<a href="/chat">Chat</a>
						</li>
						<li>
							<a href="/login">Login</a>
						</li>
						<li>
							<a href="/order">Order</a>
						</li>
					</ul>
				</nav>
			</header>

			<Routes>
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
		</>
	);
}

export default App;
