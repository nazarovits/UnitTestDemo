using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace UnitTestDemo
{
    [TestFixture]
    class StringHelperTest
    {
        [TestCase(null, -1)]
        [TestCase("", -1)]
        [TestCase("   ", 0)]                      // remove spaces
        [TestCase("hello", 1)]
        [TestCase("hello world", 2)]
        [TestCase("  hello  ", 1)]                // remove spaces
        [TestCase("the TDD style is cool :)", 5)] // remove "the" from the sentence
        public void GetCountOfWordsTest(string sentence, int expected)
        {
            // setup + act
            int count = StringHelper.GetCountOfWords(sentence);

            // assert
            Assert.AreEqual(expected, count, $"Should be returned {expected}");
        }

        [TestCase("", "", 0)]
        [TestCase("any", "", 0)]
        [TestCase("", "any", -1)]
        [TestCase("any", "any", 0)]
        [TestCase("any", "Any", -1)]
        [TestCase("The quick brown fox jumps over the lazy dog", "brown", 10)]
        public void FindInContentTest(string contentValue, string searchValue, int expectedValue)
        {
            int actualValue = StringHelper.FindInContent(contentValue, searchValue);
            
            Assert.AreEqual(expectedValue, actualValue, 
                $"FindInContent(\"{contentValue}\", \"{searchValue}\") should be return \"{expectedValue}\"");
        }

        [TestCase(null, "any string")]
        [TestCase("any string", null)]
        public void FindInContentTest_NullReference(string contentValue, string searchValue)
        {
            // setup + act + assert
            Assert.Throws<ArgumentNullException>(() => StringHelper.FindInContent(contentValue, searchValue));
        }
    }
}
