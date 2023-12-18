using Country_explorer_API.Models;

namespace Country_explorer_API.Tests
{
    internal class CountryViewModelEqualityComparer : IEqualityComparer<CountryViewModel>
    {
        public bool Equals(CountryViewModel x, CountryViewModel y)
        {
            // Compare only the relevant properties
            return x.Name?.Common == y.Name?.Common;
        }

        public int GetHashCode(CountryViewModel obj)
        {
            return obj.Name?.Common.GetHashCode() ?? 0;
        }
    }
}
