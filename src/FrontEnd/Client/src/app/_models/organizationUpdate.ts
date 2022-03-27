import { Address, OrganizationLevel, OrganizationName, OrganizationRegion } from "./organization";

export interface OrganizationUpdate {
    id: string;
    level: OrganizationLevel;
    region: OrganizationRegion;
    address: Address;
    isActive: boolean;
    organizationName: OrganizationName;
}