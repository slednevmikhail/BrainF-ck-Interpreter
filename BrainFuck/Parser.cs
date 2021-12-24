using System;
using System.Linq;

namespace Brainfuck
{
    public static class ContainsExtension
    {
        public static bool Contains(this char[] array, char[] values)
        {
            var flag = false;
            foreach (var e in values)
                if (array.Contains(e)) flag = true;
            return flag;
        }
    }
    public static class Parser
    {
        private static char[] inputtext;
        public static char[] ParsedCode
        {
            get
            {
                return inputtext;
            }
            set
            {
                if (!value.Contains(new[] { '>', '<', '.', ',', '[', ']', '+', '-' })) throw new ArgumentException();
                inputtext = value;
            }
        }
        public static void Parse(this string text)
        {
            ParsedCode = text.ToCharArray();
        }
    }

}
