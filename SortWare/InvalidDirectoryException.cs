using System;

namespace SortWare
{
    public class InvalidDirectoryException : Exception
    {
        public InvalidDirectoryException() : base()
        {
        }

        public InvalidDirectoryException(string message) : base(message)
        {
        }

        public InvalidDirectoryException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}