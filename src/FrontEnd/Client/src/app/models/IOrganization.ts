export interface IOrganization {
    id: string;
    published: Date;
    updated: Date;
    level: OrganizationLevel;
    region: OrganizationRegion;
    address: Address;
    isActive: boolean;
    organizationName: OrganizationName;
    specializationIds: string[];
}

export enum OrganizationLevel {
    "Раонный уровень",
    "егиональынй уровень",
    "Республика Беларусь"
}

export enum OrganizationRegion {
    "Брестский регион",
    "Витебский регион",
    "Гомельский регион",
    "Гродненский регион",
    "Минский регион",
    "Могилевский регион",
    "г. Минск",
    "Беларусь"
}

export interface Address {
    line: string;
}

export interface OrganizationName {
    usualName: string;
    officialName: string;
}