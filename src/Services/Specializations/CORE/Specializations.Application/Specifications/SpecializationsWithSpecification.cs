using BaseDomain.Specifications;
using BaseDomain.Specs;
using Specializations.Domain;

namespace Specializations.Application.Specifications
{
    public class SpecializationsWithSpecification : BaseSpecification<Specialization>
    {
        public SpecializationsWithSpecification(QuerySpecParams querySpecParams) : base(x =>
            (string.IsNullOrEmpty(querySpecParams.Search) || x.Name.ToLower().Contains(querySpecParams.Search)))
        {
            AddOrderBy(x => x.Name);
            ApplyPaging(querySpecParams.PageSize * (querySpecParams.PageIndex - 1), querySpecParams.PageSize);
            if(!string.IsNullOrEmpty(querySpecParams.Sort))
            {
                switch (querySpecParams.Sort)
                {
                    case "nameAsc":
                        AddOrderBy(x => x.Name);
                        break;
                    case "nameDesc":
                        AddOrderByDescending(x => x.Name);
                        break;
                    default:
                        AddOrderBy(x => x.Name);
                        break;
                }
            }
        }
    }
}
