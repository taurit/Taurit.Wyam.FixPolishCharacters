using System.Text.RegularExpressions;

namespace Wyam.FixPolishCharacters
{
    public static class StringExtensions
    {
        public static string ReplaceCaseInsensitive(this string content, string from, string to)
        {
            return Regex.Replace(content, from, to, RegexOptions.IgnoreCase);
        }
    }
}