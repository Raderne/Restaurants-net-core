import { Button } from "@/components/ui/button";
import {
	Card,
	CardContent,
	CardDescription,
	CardFooter,
	CardHeader,
	CardTitle,
} from "@/components/ui/card";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import { Tabs, TabsContent, TabsList, TabsTrigger } from "@/components/ui/tabs";

const Register = () => {
	return (
		<div>
			<Tabs
				defaultValue="account"
				className="w-[400px]"
			>
				<TabsList className="grid w-full grid-cols-2">
					<TabsTrigger value="account">Account</TabsTrigger>
					<TabsTrigger value="password">Password</TabsTrigger>
				</TabsList>
				<TabsContent value="account">
					<Card>
						<CardHeader>
							<CardTitle>Account</CardTitle>
							<CardDescription>
								Register Your Account. Click save when you're done.
							</CardDescription>
						</CardHeader>
						<CardContent className="space-y-2">
							<div className="space-y-1">
								<Label htmlFor="name">Name</Label>
								<Input
									id="name"
									defaultValue="Pedro Duarte"
								/>
							</div>
							<div className="space-y-1">
								<Label htmlFor="username">Username</Label>
								<Input
									id="username"
									defaultValue="@peduarte"
								/>
							</div>
						</CardContent>
						<CardFooter>
							<TabsList>
								<TabsTrigger
									value="password"
									className="bg-[#27272a]"
								>
									Add Password
								</TabsTrigger>
							</TabsList>
						</CardFooter>
					</Card>
				</TabsContent>
				<TabsContent value="password">
					<Card>
						<CardHeader>
							<CardTitle>Password</CardTitle>
							<CardDescription>
								Change your password here. After saving, you'll be logged out.
							</CardDescription>
						</CardHeader>
						<CardContent className="space-y-2">
							<div className="space-y-1">
								<Label htmlFor="current">Password</Label>
								<Input
									id="current"
									type="password"
								/>
							</div>
							<div className="space-y-1">
								<Label htmlFor="confirme">Confirm Password</Label>
								<Input
									id="confirme"
									type="password"
								/>
							</div>
						</CardContent>
						<CardFooter>
							<Button type="submit">Save password</Button>
						</CardFooter>
					</Card>
				</TabsContent>
			</Tabs>
		</div>
	);
};

export default Register;
