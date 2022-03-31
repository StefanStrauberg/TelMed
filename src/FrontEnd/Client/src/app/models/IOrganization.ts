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
    AreaLevel,
    RegionLevel,
    RepublicLevel
}

export enum OrganizationRegion {
    BrestRegion,
    VitebskRegion,
    GomelRegion,
    GrodnoRegion,
    MinskRegion,
    MogilevRegion,
    Minsk,
    Belarus
}

export interface Address {
    line: string;
}

export interface OrganizationName {
    usualName: string;
    officialName: string;
}