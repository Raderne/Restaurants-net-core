import { useRef, useState } from "react";
import { useNavigate } from "react-router";
import { useAuth } from "./Contexts/AuthContext";

const Login = () => {
	const [email, setEmail] = useState("");
	const [password, setPassword] = useState("");
	const ref = useRef(null);
	const navigation = useNavigate();
	const { login } = useAuth();

	const Login = async () => {
		let user = {
			email: email,
			password: password,
		};

		let data = await login(user);

		if (data) {
			console.log(data);

			if (data.succeeded) {
				localStorage.setItem("token", data.loginResponse.token);
				navigation("/order");
			} else {
				ref.current.innerHTML = data?.validationErrors[0];
			}
		} else {
			console.log("Failed to login");
		}
	};

	return (
		<div>
			<h1>Login</h1>
			<input
				type="text"
				value={email}
				onChange={(e) => setEmail(e.target.value)}
				placeholder="Email"
			/>
			<input
				type="password"
				value={password}
				onChange={(e) => setPassword(e.target.value)}
				placeholder="Password"
			/>
			<button onClick={Login}>Login</button>
			<div
				className="result"
				ref={ref}
			></div>
		</div>
	);
};

export default Login;
