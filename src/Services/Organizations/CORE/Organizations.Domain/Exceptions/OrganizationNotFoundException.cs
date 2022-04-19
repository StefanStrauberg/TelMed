namespace Organizations.Domain.Exceptions
{
    public class OrganizationNotFoundException : NotFoundException
    {
        public OrganizationNotFoundException(string Id)
            : base($"The organization with the identifier {Id} was not found.")
        {
        }
    }
}
