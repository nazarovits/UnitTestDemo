using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestDemo
{
    public class StringHelper
    {
        public static string[] GetWords(string sentence)
        {
            if (string.IsNullOrEmpty(sentence))
            {
                return new string[0];
            }

            var result = sentence.Replace("the", string.Empty);
            result = result.Trim();

            string[] resultArray = result.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            return resultArray;
        }

        public static int GetCountOfWords(string sentence)
        {
            if (string.IsNullOrEmpty(sentence))
            {
                return -1;
            }

            return GetWords(sentence).Length;
        }

        public static int FindInContent(string content, string search)
        {
            if (search == null || content == null)
            {
                throw new ArgumentNullException();
            }

            return content.IndexOf(search);
        }
    }
}
