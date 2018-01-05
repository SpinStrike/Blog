using System;
using System.Collections.Generic;

namespace Blog.Models.ExtensionsMethods
{
    public static class StringExtensions
    {
        public static IEnumerable<string> SplitToParagraphs(this string s)
        {
            var resultSet = new List<string>(s.Split(new string[] { "\r\n" },StringSplitOptions.RemoveEmptyEntries));

            return resultSet;
        }
    }
}