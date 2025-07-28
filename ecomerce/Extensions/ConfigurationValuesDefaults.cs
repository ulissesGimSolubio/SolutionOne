namespace Ecomerce.Extensions
{
    public static class ConfigurationValuesDefaults
    {
        private static readonly List<int> pagination = new List<int> { 2, 5, 10, 20, 50, 100, 500, 1000, 5000 };

        public static List<int> Pagination
        {
            get { return pagination; }
        }
    }
}
