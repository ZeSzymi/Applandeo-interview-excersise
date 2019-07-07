using System.Reflection;

namespace AssertionLibrary
{
    public class AssertionWithProperties<T> : Assertion<T>
    {
        public AssertionWithProperties(T expected) : base(expected)
        {
        }

        public void Eq(dynamic provided)
        {
            foreach (PropertyInfo propertyInfo in Expected.GetType().GetProperties())
            {
                if (!(provided.GetType().GetProperty(propertyInfo.Name).GetValue(provided, null) == propertyInfo.GetValue(Expected, null)))
                    throw new ExpectationFailedException();
            }
            return;
        }
    }

    
}
