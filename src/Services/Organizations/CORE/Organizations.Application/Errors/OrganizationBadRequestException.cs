namespace Organizations.Application.Errors
{
    public class OrganizationBadRequestException : BadRequestException
    {
        public OrganizationBadRequestException(string Id) 
            : base($"The organization with the identifier {Id} was not found.")
        {
        }
    }
}
