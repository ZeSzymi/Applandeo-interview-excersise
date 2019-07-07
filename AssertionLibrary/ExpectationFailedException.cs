using System;

namespace AssertionLibrary
{
    [Serializable()]
    public class ExpectationFailedException : Exception
    {
        public ExpectationFailedException() : base() { }
    }
}
