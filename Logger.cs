using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestDemo
{
    public interface ILogger
    {
        void Log(string message);
    }
    public interface IFormatter
    {
        string Format(string str);
    }

    public class TimeFormatter : IFormatter
    {
        public string Format(string str)
        {
            return string.Format("{0}: {1}", DateTime.Now.ToShortTimeString(), str);
        }
    }

    public class ConsoleLogger : ILogger
    {
        private IFormatter _formatter;
        public ConsoleLogger(IFormatter formatter)
        {
            _formatter = formatter;
        }

        public void Log(string message)
        {
            if (_formatter != null)
            {
                message = _formatter.Format(message);
            }
            Console.WriteLine(message);
        }
    }

}
