export interface IOrganization {
    id: string
    level: OrganizationLevel
    region: OrganizationRegion
    address: IAddress
    isActive: boolean
    organizationName: IOrganizationName
    specializationIds: string[]
}

export interface IAddress {
    line: string
}

export interface IOrganizationName {
    usualName: string
    officialName: string
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