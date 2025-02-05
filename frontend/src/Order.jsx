import { useState } from "react";

const Order = () => {
	const [restaurantId, setRestaurantId] = useState(0);
	const [customerName, setCustomerName] = useState("");

	const order = async () => {
		let order = {
			restaurantId: restaurantId,
			customerName: customerName,
		};

		const token = localStorage.getItem("token");
		if (!token) {
			console.log("Token not found");
			return;
		}

		await fetch("https://localhost:7156/api/orders/add", {
			method: "POST",
			headers: {
				"Content-Type": "application/json",
				Authorization: `Bearer ${token}`,
			},
			body: JSON.stringify(order),
		});
	};

	return (
		<div>
			<h1>Order</h1>
			<input
				type="number"
				value={restaurantId}
				onChange={(e) => setRestaurantId(e.target.value)}
				placeholder="Restaurant Id"
			/>
			<input
				type="text"
				value={customerName}
				onChange={(e) => setCustomerName(e.target.value)}
				placeholder="Customer Name"
			/>
			<button onClick={order}>Order</button>
		</div>
	);
};

export default Order;
