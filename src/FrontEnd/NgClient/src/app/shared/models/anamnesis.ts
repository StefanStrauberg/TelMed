export interface IAnamnesis {
    referralId: string;
    categoryId: AnamnesisCategory;
    summary: string;
}

export enum AnamnesisCategory {
    "Анамнез жизни" = 1,
    "Анамнез заболевания" = 2,
    "Объективный статус" = 3
}