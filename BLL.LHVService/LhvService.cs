namespace BLL.LHVService
{
    public class LhvService : ILhvService
    {
        private readonly string _baseUrl;

        public LhvService(string baseUrl)
        {
            _baseUrl = baseUrl;
        }
        public string GetConsent(string bearer)
        {
            throw new System.NotImplementedException();
        }
    }
}