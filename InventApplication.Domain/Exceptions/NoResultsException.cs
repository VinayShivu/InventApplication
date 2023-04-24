using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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
