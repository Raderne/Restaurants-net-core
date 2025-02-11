import {
	LoginResponse,
	LoginUser,
	RegisterResponse,
	RegisterUser,
	UserProfile,
} from "@/models/Users";
import axios from "axios";
import { createContext, useContext, useState } from "react";

type UserContextType = {
	user: UserProfile;
	setUser: (user: UserProfile) => void;
	token: string;
	login: (credentials: LoginUser) => Promise<LoginResponse | undefined>;
	register: (
		credentials: RegisterUser,
	) => Promise<RegisterResponse | undefined>;
	logout: () => void;
	IsLoggedIn: () => boolean;
};

const AuthContext = createContext<UserContextType>({} as UserContextType);

type Props = { children: React.ReactNode };

const api = "https://localhost:7156/api/identity";

const AuthProvider = ({ children }: Props) => {
	const [user, setUser] = useState<UserProfile>({} as UserProfile);
	const [token, setToken] = useState<string>("");

	const login = async (credentials: LoginUser) => {
		const response = await axios.post<LoginResponse>(
			`${api}/login`,
			credentials,
		);

		if (response.data.succeeded) {
			setToken(response.data.loginResponse?.token || "");
			return response.data;
		}
	};

	const logout = () => {
		setToken("");
	};

	const register = async (credentials: RegisterUser) => {
		const response = await axios.post<RegisterResponse>(
			`${api}/register`,
			credentials,
		);

		if (response.data.succeeded) {
			return response.data;
		}
	};

	const IsLoggedIn = () => {
		return token !== "";
	};

	return (
		<AuthContext.Provider
			value={{ user, setUser, token, login, register, logout, IsLoggedIn }}
		>
			{children}
		</AuthContext.Provider>
	);
};

export { AuthContext, AuthProvider };

export const useAuth = () => {
	return useContext(AuthContext);
};
