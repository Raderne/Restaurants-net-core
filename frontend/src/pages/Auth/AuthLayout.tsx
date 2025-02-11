import { Outlet } from "react-router";

const AuthLayout = () => {
	return (
		<div className="flex items-center justify-center h-screen bg-black">
			<Outlet />
		</div>
	);
};

export default AuthLayout;
