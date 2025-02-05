import { HubConnectionBuilder, LogLevel } from "@microsoft/signalr";
import { useEffect, useState } from "react";

export const useSignalR = () => {
	const [connection, setConnection] = useState(null);
	const accessToken = localStorage.getItem("token");

	useEffect(() => {
		if (!accessToken) return;

		const newConnection = new HubConnectionBuilder()
			.withUrl("https://localhost:7156/orderHub", {
				accessTokenFactory: () => accessToken,
			})
			.configureLogging(LogLevel.Information)
			.withAutomaticReconnect()
			.build();

		newConnection
			.start()
			.then(() => console.log("Connection started"))
			.catch((error) => console.log(error));

		setConnection(newConnection);

		return () => {
			newConnection.stop();
		};
	}, [accessToken]);

	return connection;
};
