import { Route, Routes } from "react-router";
import Home from "./pages/Home";
import Restaurants from "./pages/Restaurants/Restaurants";
import Restaurant from "./pages/Restaurants/Restaurant";
import AuthLayout from "./pages/Auth/AuthLayout";
import Login from "./pages/Auth/Login";
import Register from "./pages/Auth/Register";
import { AuthProvider } from "./contexts/AuthContext";
import ProtectedRoute from "./utils/ProtectedRoute";
import { ThemeProvider } from "./contexts/theme-provider";
import { Toaster } from "./components/ui/toaster";
import { Suspense } from "react";
import { SkeletonCard } from "./components/SkeletonCard";

function App() {
	return (
		<ThemeProvider>
			<AuthProvider>
				<Routes>
					<Route element={<Home />}>
						<Route
							index
							element={<Restaurants />}
						/>
						<Route
							path="restaurants/:restaurantId"
							element={
								<ProtectedRoute>
									<Restaurant />
								</ProtectedRoute>
							}
						/>
					</Route>

					<Route element={<AuthLayout />}>
						<Route
							path="login"
							element={
								<Suspense fallback={<SkeletonCard />}>
									<Login />
								</Suspense>
							}
						/>
						<Route
							path="register"
							element={<Register />}
						/>
					</Route>
				</Routes>
			</AuthProvider>
			<Toaster />
		</ThemeProvider>
	);
}

export default App;
