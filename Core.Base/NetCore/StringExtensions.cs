namespace Core.Core.NetCore
{
    public static class StringExtensions
    {
        public static string TrimNull(this string s)
        {
            if (string.IsNullOrEmpty(s))
                return "";

            return s.Trim();
        }
    }
}
