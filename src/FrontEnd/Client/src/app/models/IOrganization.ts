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
    "Районный уровень",
    "Областной уровень",
    "Республиканский уровень"
}

export enum OrganizationRegion {
    "Брестская область",
    "Витебская область",
    "Гомельская область",
    "Гродненская область",
    "Минская область",
    "Могилевская область",
    "г. Минск",
    "Республика Беларусь"
}

export interface Address {
    line: string;
}

export interface OrganizationName {
    usualName: string;
    officialName: string;
}