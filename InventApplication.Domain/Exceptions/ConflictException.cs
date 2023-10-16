namespace InventApplication.Domain.Exceptions
{
    public class ConflictException : CustomException
    {
        public ConflictException(string message) : base(message) { }
    }
}
