
namespace Country_explorer_API.Exceptions
{
    [Serializable]
    public class CountryServiceException : Exception
    {
        public CountryServiceException()
        {
        }

        public CountryServiceException(string message) : base(message)
        {
        }

        public CountryServiceException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
