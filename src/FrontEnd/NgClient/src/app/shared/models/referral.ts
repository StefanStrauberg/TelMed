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
}

export enum ReferralStatus {
    Incomplete,
    Opened,
    Closed,
    NeedAttention,
    Canceled
}

export interface Patient {
    fullName: string;
    gender: PatientGender;
    birthDate: string;
}

export enum PatientGender {
    Male = 1,
    Female = 2
}

export enum MedicalAttention {
    Urgent = 1,
    Planned = 2
}