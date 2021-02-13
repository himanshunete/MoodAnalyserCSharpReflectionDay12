using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyserAppWithCore
{
    public class MoodAnalyserCustomException:Exception
    {
        ExceptionType type;
        public enum ExceptionType
        {
            NO_SUCH_CLASS,
            NO_SUCH_METHOD,
            EMPTY_MESSAGE,
            NULL_MESSAGE,
            NO_SUCH_FIELD,

        }

        public MoodAnalyserCustomException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}
