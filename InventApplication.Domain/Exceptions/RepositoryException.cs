using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace InventApplication.Domain.Exceptions
{
    [Serializable]
    public class RepositoryException : Exception
    {
        public RepositoryException(string message) : base(message) { }
        public RepositoryException(string message, Exception innerException) : base(message, innerException) { }
        protected RepositoryException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
