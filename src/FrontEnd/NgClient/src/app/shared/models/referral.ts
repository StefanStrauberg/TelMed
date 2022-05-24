export interface IReferral {
    id: string;
    status: ReferralStatus;
    patient: Patient;
    authorId: string;
    anamnesis: string[];
    imagingStudies: string[];
    observations: string[];
    purposeList: string[];
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