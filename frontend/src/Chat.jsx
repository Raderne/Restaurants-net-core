import { useEffect, useState } from "react";
import { useSignalR } from "./Hooks/useSignalR";

const Chat = () => {
	const [messages, setMessages] = useState([]);
	// const [connection, setConnection] = useState(null);

	// useEffect(() => {
	// 	try {
	// 		const newConnection = new HubConnectionBuilder()
	// 			.withUrl("https://localhost:7156/orderHub", {
	// 				accessTokenFactory: () => localStorage.getItem("token"),
	// 			})
	// 			.withAutomaticReconnect()
	// 			.build();

	// 		setConnection(newConnection);
	// 	} catch (error) {
	// 		console.log(error);
	// 	}
	// }, []);

	// useEffect(() => {
	// 	if (connection) {
	// 		connection.start().then(() => {
	// 			connection.on("ReceiveOrderNotification", (order) => {
	// 				setMessages((messages) => [
	// 					...messages,
	// 					`${order?.orderId}: ${order?.customerName} ${new Date(
	// 						order?.createdAt,
	// 					).toLocaleString()}`,
	// 				]);
	// 			});
	// 		});
	// 	}

	// 	return () => {
	// 		if (connection) {
	// 			connection.stop();
	// 		}
	// 	};
	// }, [connection]);
	const connection = useSignalR();

	useEffect(() => {
		if (!connection) return;

		connection.on("ReceiveOrderNotification", ({ createdAt, customerName }) => {
			setMessages((messages) => [
				...messages,
				`${customerName} ${new Date(createdAt).toLocaleString()}`,
			]);
		});

		return () => {
			connection.off("ReceiveOrderNotification");
		};
	}, [connection]);

	return (
		<div>
			<h1>Chats</h1>

			<ul>
				{messages.map((message, index) => {
					return <li key={index}>{message}</li>;
				})}
			</ul>
		</div>
	);
};

export default Chat;
