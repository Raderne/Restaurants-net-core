export type LoginUserToken = {
	token: string;
	refreshToken: string;
	UserName: string;
};

export type LoginResponse = {
	succeeded: boolean;
	message: string;
	validationErrors: string[] | null;
	loginResponse: LoginUserToken | null;
};

export type LoginUser = {
	email: string;
	password: string;
};

export type UserProfile = {
	email: string;
	fullName: string;
	userName: string;
};

export type RegisterUser = {
	userEmail: string;
	userName: string;
	password: string;
	passwordConfirmation: string;
	roleName: string;
	firstName: string;
	lastName: string;
};

export type RegisteredUser = {
	email: string;
	fullName: string;
	userName: string;
};

export type RegisterResponse = {
	succeeded: boolean;
	message: string;
	validationErrors: string[] | null;
	registeredUser: RegisteredUser | null;
};
