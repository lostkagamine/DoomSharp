using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoomSharp
{
    public static class Assert
    {
        public class AssertionFailedException : Exception
        {
            public string Why = null;

            public AssertionFailedException(string msg)
            {
                Why = msg;
            }

            public AssertionFailedException()
            {
                Why = null;
            }

            new public string Message
            {
                get
                {
                    if (Why == null)
                        return "assertion failed";
                    else
                        return $"assertion failed: {Why}";
                }
            }

            public override string ToString()
            {
                return $"AssertionFailedException: '{Message}'";
            }
        }

        public static void That(bool condition)
        {
            if (!condition)
                throw new AssertionFailedException();
        }

        public static void That(Func<bool> d)
        {
            Assert.That(d());
        }
    }
}
