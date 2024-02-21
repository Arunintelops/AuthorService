namespace Application.Exceptions
{
    public class AuthorNotFoundException : ApplicationException
    {
        public AuthorNotFoundException(string name, object key) : base($"Entity {name} - {key} is not found.")
        {

        }
    }
}
