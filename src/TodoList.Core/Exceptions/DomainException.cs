

using System;
using System.Collections.Generic;

namespace TodoList.Core.Exceptions
{
    public class DomainException : Exception
    {
        internal List<string> _errors;

        public IReadOnlyCollection<string> Error => _errors;

        public DomainException()
        {
        }

        public DomainException(string message, List<string> errors) : base(message)
        {
            _errors = errors;
        }

        public DomainException(string message) : base(message)
        {
        }

        public DomainException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}