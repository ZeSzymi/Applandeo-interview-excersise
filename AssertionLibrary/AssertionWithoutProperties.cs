namespace AssertionLibrary
{
    public class AssertionWithoutProperties<T> : Assertion<T>
    {
        public AssertionWithoutProperties(T expected) : base(expected)
        {
        }

        public void Eq(dynamic provided)
        {
            if (Expected.Equals(provided)) return;
            throw new ExpectationFailedException();
        }
    }

    
}
