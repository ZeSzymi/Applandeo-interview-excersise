using System.Reflection;

namespace AssertionLibrary
{
    public class AssertionWithoutProperties<T> : Assertion<T>
    {
        private readonly dynamic _excludedProperty;
        public AssertionWithoutProperties(T expected, dynamic excludedProperty) : base(expected)
        {
            _excludedProperty = excludedProperty;
        }

        public void Eq(dynamic provided)
        {
            foreach (PropertyInfo propertyInfo in Expected.GetType().GetProperties())
            {
                var providedProperty = provided.GetType().GetProperty(propertyInfo.Name).GetValue(provided, null);
                var expectedProperty = propertyInfo.GetValue(Expected, null);
                if (IsNotExcludedProperty(expectedProperty))
                {
                    CompareProperties(expectedProperty, providedProperty);
                }
            }
        }

        public bool IsNotExcludedProperty(dynamic excpectedProperty) => _excludedProperty != excpectedProperty;

    }

    
}
