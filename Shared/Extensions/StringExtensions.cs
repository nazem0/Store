namespace Shared.Extensions
{
    public static class StringExtensions
    {
        public static string Join(this string[] strings, string joinSymbol = ", ")
        {
            return string.Join(joinSymbol, strings);
        }
    }
}
