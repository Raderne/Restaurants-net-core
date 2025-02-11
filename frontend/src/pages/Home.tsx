import { Outlet } from "react-router";

const Home = () => {
	return (
		<div>
			<h1>home</h1>

			<Outlet />
		</div>
	);
};

export default Home;
