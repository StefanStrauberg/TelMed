namespace Organizations.Application.Errors
{
    public class OrganizationNotFoundException : NotFoundException
    {
        public OrganizationNotFoundException(string Id)
            : base($"The organization with the identifier {Id} was not found.")
        {
        }
    }
}
