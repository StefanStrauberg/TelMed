export interface ILogin {
    login: string;
    password: string;
}

export interface IToken {
    isAuthSuccessful: boolean;
    token: string;
}