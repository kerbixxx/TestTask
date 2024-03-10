namespace Business.Common.Exceptions
{
    public class RemovalException : Exception
    {
        public RemovalException(string name, object key) : base($"Entity \"{name}\" ({key}) can not be deleted.") { }
    }
}
