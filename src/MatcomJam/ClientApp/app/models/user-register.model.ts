export class UserRegister {
    constructor(email?: string, password?: string, confirmPassword?: string) {
        this.email = email;
        this.password = password;
        this.confirmPassword = confirmPassword;
    }

    email: string;
    password: string;
    confirmPassword: string;
}