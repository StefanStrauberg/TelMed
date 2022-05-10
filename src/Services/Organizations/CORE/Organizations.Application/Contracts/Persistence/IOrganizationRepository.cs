﻿using Organizations.Domain;

namespace Organizations.Application.Contracts.Persistence
{
    public interface IOrganizationRepository : IGenericRepository<Organization>
    {
        Task<Object> GetShortOrganizationsAsync();
    }
}
