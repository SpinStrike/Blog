using System;
using System.Text;
using System.Linq;
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

        public static IEnumerable<string> SplitToTags(this string s)
        {
            var resultStrings = new List<string>(new StringBuilder(s).Replace("\r\n", ",")
                .ToString()
                .Split(new string[] { ",", " ", ";", "/"}, StringSplitOptions.RemoveEmptyEntries));

            return resultStrings as IEnumerable<string>;
        }
    }
}