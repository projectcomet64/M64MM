using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace M64MM.Utils
{
    public static class MarkdownRegex
    {
        public static Regex italics = new Regex(@"(?:[\*|\_])([^\*|\_|~|\n|\\*|\\_]+)(?:[\*|\_])", RegexOptions.ECMAScript);
        public static Regex bold = new Regex(@"([\*]{2})([^\*|\_|~]+)([\*]{2})", RegexOptions.ECMAScript);
        public static Regex strike = new Regex(@"([~]{2})([^\*|\_|~]+?)([~]{1,2})", RegexOptions.ECMAScript);
        public static Regex mono = new Regex(@"(?:``)(.*?)(?:``)", RegexOptions.ECMAScript);
        public static Regex mdLinks = new Regex(@"\[(.+)\]\((.+)\)");
        public static Regex escapeCharacters = new Regex(@"(\\)[*|~|_]");
        public static Regex linebreaks = new Regex(@"(\n\n)|(\r\n)");

        public static string MarkdownToRtf(string input)
        {
            string result = input;
            result = mono.Replace(result, @"\f1 $1\f0 ");
            result = strike.Replace(result, @"\strike $1\strike0 ");
            result = bold.Replace(result, @"\b $1\b0 ");
            result = italics.Replace(result, @"\i $1\i0 ");
            result = mdLinks.Replace(result, @"{$1 (link here: $2)}");
            result = linebreaks.Replace(result, @"\line ");
            result = escapeCharacters.Replace(result, @"$1");
            return result;
        }
    }
}
