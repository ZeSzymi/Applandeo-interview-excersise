using System;
using System.Collections.Generic;

namespace AssertionLibrary
{
    public class Assertion<T>
    {
        public T Expected { get; set; }

        public Assertion(T expected)
        {
            Expected = expected;
        }

        public virtual void Eq(T provided)
        {
            if (EqualityComparer<T>.Default.Equals(Expected, provided)) return;
            throw new ExpectationFailedException();
        }

        public void RaiseError() {
            try
            {
                var method = Expected as Action;
                method();
            } catch
            {
                return;
            }
            throw new ExpectationFailedException();
        }

        public virtual void IsGreater(int providedNumber)
        {
            if (Convert.ToInt32(Expected) > providedNumber) return;
            throw new ExpectationFailedException();
        }

        public void CompareProperties(dynamic expectedProperty, dynamic providedProperty)
        {
            if (!(providedProperty == expectedProperty))
                throw new ExpectationFailedException();
        }

        public AssertionInverted<T> Not() => new AssertionInverted<T>(Expected);

        public AssertionWithProperties<T> Properties() => new AssertionWithProperties<T>(Expected);

        public AssertionWithoutProperties<T> PropertiesWithout(Func<T, dynamic> method) => new AssertionWithoutProperties<T>(Expected, method(Expected));

        public AssertionWithoutProperties<T> PropertiesWithout(dynamic property) => new AssertionWithoutProperties<T>(Expected, property);
    }

    public static class ExpectExtension
    {
        public static Assertion<T> Expect<T>(this T obj)
        {
            return new Assertion<T>(obj);
        }
    }

}
