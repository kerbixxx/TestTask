namespace Business.Common.Extensions
{
    public static class QueryStringExtensions
    {
        public static string ToQueryString(this IEnumerable<KeyValuePair<string, string>> parameters)
        {
            return string.Join("&", parameters.Select(kvp => $"{Uri.EscapeDataString(kvp.Key)}={Uri.EscapeDataString(kvp.Value)}"));
        }
    }
}
