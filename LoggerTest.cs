using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

using Moq;

namespace UnitTestDemo
{
    [TestFixture]
    class TimerFormatterTest
    {
        [Test]
        public void FormatTest()
        {
            // setup:
            var timeFormatter = new TimeFormatter();
            string testString = "FORMAT";

            // act:
            string formatedString = timeFormatter.Format(testString);
            
            // assert:
            Assert.AreEqual(formatedString.Substring(formatedString.Length - testString.Length), testString, $"The formated text should contain the '{testString}' text");
        }

        [Test]
        public void FormatTest_WithEmptyString()
        {
            var timeFormatter = new TimeFormatter();
            string formatedString = timeFormatter.Format("");
            Assert.AreEqual(": ", formatedString.Substring(formatedString.Length - 2));
        }
    }

    [TestFixture]
    class ConsoleLoggerTest
    {
        [Test]
        public void LogTest_FormatterIsNull()
        {
            // setup
            string message = "message";
            var formatterMock = new Mock<IFormatter>();
            formatterMock.Setup(f => f.Format(message)).Returns(message);
            var logger = new ConsoleLogger(null); // the formatter parameter is null

            // act
            logger.Log(message);

            // assert
            formatterMock.Verify(f => f.Format(message), Times.Never());
        }

        [TestCase("Hello", "Date: Hello")]
        public void LogTest_FormatterIsNotNull(string message, string formattedMessage)
        {
            // setup
            var formatterMock = new Mock<IFormatter>();
            formatterMock.Setup(f => f.Format(message)).Returns(formattedMessage);
            var logger = new ConsoleLogger(formatterMock.Object);

            // act
            logger.Log(message);

            // assert
            formatterMock.Verify(f => f.Format(message), Times.Once());
        }
    }
}
