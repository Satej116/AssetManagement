namespace AssetManagement.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string entityName, int id)
            : base($"{entityName} with ID {id} was not found.")
        { }
    }
}
