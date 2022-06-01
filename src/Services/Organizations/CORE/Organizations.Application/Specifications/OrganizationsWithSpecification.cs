using BaseDomain.Specifications;
using BaseDomain.Specs;
using Organizations.Domain;

namespace Organizations.Application.Specifications
{
    public class OrganizationsWithSpecification : BaseSpecification<Organization>
    {
        public OrganizationsWithSpecification(QuerySpecParams querySpecParams) : base(x =>
            (string.IsNullOrEmpty(querySpecParams.Search) || x.OfficialName.ToLower().Contains(querySpecParams.Search)))
        {
            AddOrderBy(x => x.OfficialName);
            ApplyPaging(querySpecParams.PageSize * (querySpecParams.PageIndex - 1), querySpecParams.PageSize);
            if (!string.IsNullOrEmpty(querySpecParams.Sort))
            {
                switch (querySpecParams.Sort)
                {
                    case "nameAsc":
                        AddOrderBy(x => x.OfficialName);
                        break;
                    case "nameDesc":
                        AddOrderByDescending(x => x.OfficialName);
                        break;
                    default:
                        AddOrderBy(x => x.OfficialName);
                        break;
                }
            }
        }
    }
}
