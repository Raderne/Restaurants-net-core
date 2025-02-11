import { useAuth } from "@/contexts/AuthContext";
import { LoginUser } from "@/models/Users";
import { useForm } from "react-hook-form";
import { z } from "zod";
import { zodResolver } from "@hookform/resolvers/zod";
import { Button } from "@/components/ui/button";
import {
	Form,
	FormControl,
	FormField,
	FormItem,
	FormLabel,
	FormMessage,
} from "@/components/ui/form";
import { Input } from "@/components/ui/input";
import { useLocation, useNavigate } from "react-router";
import { useToast } from "@/hooks/use-toast";

const formSchema = z.object({
	email: z.string().email("Please enter a valid email address"),
	password: z.string().min(6),
});

const Login = () => {
	const { login } = useAuth();
	const location = useLocation();
	const { from } = location.state || { from: { pathname: "/" } };
	const navigate = useNavigate();
	const { toast } = useToast();

	const form = useForm<LoginUser>({
		resolver: zodResolver(formSchema),
		defaultValues: {
			email: "",
			password: "",
		},
	});

	const onSubmit = form.handleSubmit(async (values: LoginUser) => {
		const res = await login(values);

		if (res?.succeeded) {
			toast({
				title: "Success",
				description: res?.message,
			});

			setTimeout(() => {
				navigate(from);
			}, 300);
		} else {
			toast({
				title: "Error",
				description: res?.validationErrors?.join(", ") || res?.message,
				variant: "destructive",
			});
		}
	});

	return (
		<Form {...form}>
			<form
				onSubmit={onSubmit}
				className="space-y-8 border border-gray-200 p-8 rounded-lg shadow-md shadow-white"
			>
				<FormField
					control={form.control}
					name="email"
					render={({ field }) => (
						<>
							<FormItem>
								<FormLabel>Email</FormLabel>
								<FormControl>
									<Input
										placeholder="Email"
										{...field}
									/>
								</FormControl>
								{form.formState.errors.email && (
									<FormMessage role="alert">
										{form.formState.errors.email.message}
									</FormMessage>
								)}
							</FormItem>
						</>
					)}
				/>

				<FormField
					control={form.control}
					name="password"
					render={({ field }) => (
						<>
							<FormItem>
								<FormLabel>Password</FormLabel>
								<FormControl>
									<Input
										type="password"
										placeholder="Password"
										{...field}
									/>
								</FormControl>
								{form.formState.errors.password && (
									<FormMessage role="alert">
										{form.formState.errors.password.message}
									</FormMessage>
								)}
							</FormItem>
						</>
					)}
				/>
				<Button
					type="submit"
					className="w-full"
					variant={"outline"}
				>
					Login
				</Button>
			</form>
		</Form>
	);
};

export default Login;
