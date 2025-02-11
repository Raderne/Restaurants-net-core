import { useAuth } from "@/contexts/AuthContext";
import { Navigate, useLocation } from "react-router";

type Props = { children: React.ReactNode };

const ProtectedRoute = ({ children }: Props) => {
	const location = useLocation();
	const { IsLoggedIn } = useAuth();

	return (
		<>
			{IsLoggedIn() ? (
				children
			) : (
				<Navigate
					to="/login"
					state={{ from: location.pathname }}
					replace
				/>
			)}
		</>
	);
};

export default ProtectedRoute;
