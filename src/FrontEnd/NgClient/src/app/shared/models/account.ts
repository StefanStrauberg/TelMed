export interface IAccount {
    id: string;
    userName: string;
    lastName: string;
    firstName: string;
    middleName: string;
    organizationId: string;
    phoneNumber: string;
    officePhone: string;
    email: string;
    specializationId: string;
    isActive: boolean
}

export interface IRegisterAccount {
    userName: string;
    password: string;
    confirmPassword: string;
    lastName: string;
    firstName: string;
    middleName: string;
    role: Role;
    organizationId: string;
    phoneNumber: string;
    officePhone: string;
    email: string;
    specializationId: string;
}

export enum Role {
    "Врач" = 1,
    "Консультант" = 2,
    "Администратор" = 3,
    "Координатор-консультант" = 4,
    "Координатор-врач" = 5,
    "Разработчик [Exception]" = 9,
}