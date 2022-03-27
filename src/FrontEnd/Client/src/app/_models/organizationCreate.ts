import { Address, OrganizationLevel, OrganizationName, OrganizationRegion } from "./organization";

export interface OrganizationCreate {
    level: OrganizationLevel;
    region: OrganizationRegion;
    address: Address;
    organizationName: OrganizationName;
    specializationIds: string[];
}