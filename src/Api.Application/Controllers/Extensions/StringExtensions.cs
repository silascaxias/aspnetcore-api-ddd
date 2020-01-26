using System.Text.RegularExpressions;

namespace Api.Application.Controllers.Extensions
{
    public static class StringExtensions
    {
        public static bool IsEmail(this string str)
        {
            const string MatchEmailPattern = 
                    @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
            + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
                        [0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
            + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
                        [0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
            + @"([a-zA-Z0-9]+[\w-]+\.)+[a-zA-Z]{1}[a-zA-Z0-9-]{1,23})$";

            if (str == null) return false;
            return Regex.IsMatch(str, MatchEmailPattern);
        }       
    }
}