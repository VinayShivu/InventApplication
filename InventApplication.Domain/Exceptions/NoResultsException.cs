using System.Runtime.Serialization;

namespace InventApplication.Domain.Exceptions
{
    [Serializable]
    public class NoResultsException : RepositoryException
    {
        public NoResultsException(string message) : base(message) { }
        public NoResultsException(string message, Exception innerException) : base(message, innerException) { }
        protected NoResultsException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
