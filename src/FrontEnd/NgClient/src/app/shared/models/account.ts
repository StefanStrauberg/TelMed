export interface IAccount {
    id: string;
    userName: string;
    lastName: string;
    firstName: string;
    middleName: string;
    role: string;
    organizationId: string;
    phoneNumber: string;
    officePhone: string;
    email: string;
    specializationId: string;
    isActive: boolean;
}

export interface IRegisterAccount {
    userName: string;
    password: string;
    confirmPassword: string;
    lastName: string;
    firstName: string;
    middleName: string;
    role: string;
    organizationId: string;
    phoneNumber: string;
    officePhone: string;
    email: string;
    specializationId: string;
}

export interface IRole {
    id: string;
    name: string;
}