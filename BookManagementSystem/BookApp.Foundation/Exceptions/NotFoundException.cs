using System;

namespace BookApp.Foundation.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : base()
        { }

        public NotFoundException(string name) : base(name)
        {}
    }
}
