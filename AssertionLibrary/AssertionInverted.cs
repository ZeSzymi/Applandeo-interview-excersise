using System;
using System.Collections.Generic;

namespace AssertionLibrary
{
    public class AssertionInverted<T> : Assertion<T>
    {
        
        public AssertionInverted(T expected) : base(expected)
        {
        }

        public override void IsGreater(int providedNumber)
        {
            if (!(Convert.ToInt32(Expected) > providedNumber)) return;
            throw new ExpectationFailedException();
        }

        public override void Eq(T provided)
        {
            if (!EqualityComparer<T>.Default.Equals(Expected, provided)) return;
            throw new ExpectationFailedException();
        }
    }

    
}
