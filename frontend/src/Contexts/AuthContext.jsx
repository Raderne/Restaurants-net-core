import { createContext, useContext, useState } from "react";
import PropTypes from "prop-types";
import { useSignalR } from "../Hooks/useSignalR";

const AuthContext = createContext();

const url = "https://localhost:7156/api/identity";

export const AuthProvider = ({ children }) => {
	const [token, setToken] = useState(localStorage.getItem("token"));
	const [user, setUser] = useState(null);
	const connection = useSignalR(token);

	const login = async (credentials) => {
		let response = await fetch(url + "/login", {
			method: "POST",
			headers: {
				"Content-Type": "application/json",
			},
			body: JSON.stringify(credentials),
		});

		if (!response.ok) {
			console.log("Failed to login");
			return;
		}

		// localStorage.setItem("token", token);
		// setToken(token);
		setUser(credentials);

		return response.json();
	};

	const logout = () => {
		localStorage.removeItem("token");
		connection.stop();
		setToken(null);
	};

	return (
		<AuthContext.Provider value={{ token, user, login, logout }}>
			{children}
		</AuthContext.Provider>
	);
};

AuthProvider.propTypes = {
	children: PropTypes.node.isRequired,
};

export default AuthContext;

export const useAuth = () => {
	const context = useContext(AuthContext);

	if (!context) {
		throw new Error("useAuth must be used within an AuthProvider");
	}

	return context;
};
