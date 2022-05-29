export interface IReferral {
    id: string;
    status: ReferralStatus;
    patient: Patient;
    authorId: string;
    anamnesis: IAnamnesis[];
    imagingStudies: string[];
    observations: string[];
    purpose: IPurpose[];
    medicalAttention: MedicalAttention;
    recallCause: string;
    published: Date;
    updated: Date;
}

export enum ReferralStatus {
    "Недооформлено",
    "Открыто",
    "Консультация оформлена",
    "Требует дополнения",
    "Аннулировано"
}

export interface Patient {
    fullName: string;
    gender: PatientGender;
    birthDate: string;
}

export enum PatientGender {
    "Мужской" = 1,
    "Женский" = 2
}

export enum MedicalAttention {
    "Экстренная" = 1,
    "Плановая" = 2
}

export interface IAnamnesis {
    categoryId: AnamnesisCategory;
    summary: string;
}

export enum AnamnesisCategory {
    "Анамнез жизни" = 1,
    "Анамнез заболевания" = 2,
    "Объективный статус" = 3
}

export interface IPurpose {
    group: PurposeGroup;
    resume: string;
}

export enum PurposeGroup {
    "Определение (уточнение, установление) клинического диагноза" = 1,
    "Определение (уточнение, установление) тактики обследования (лабораторного, функционального, инструментального и др.)" = 2,
    "Определение (уточнение, установление) тактики лечения (консервативного, оперативного)" = 3,
    "Решение вопроса о плановой госпитализации (согласование даты плановой госпитализации)" = 4,
    "Другое" = 5
}