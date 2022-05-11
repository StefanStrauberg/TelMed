export interface IOrganization {
    id: string
    level: OrganizationLevel
    region: OrganizationRegion
    address: IAddress
    isActive: boolean
    organizationName: IOrganizationName
    specializationIds: string
}

export interface IUpdateOrganization {
    id: string
    level: OrganizationLevel
    region: OrganizationRegion
    address: IAddress
    isActive: boolean
    organizationName: IOrganizationName
    specializationIds: string[]
}

export interface IShortOrganization {
    id: string;
    name: string;
}

export interface IAddress {
    line: string
}

export interface IOrganizationName {
    usualName: string
    officialName: string
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