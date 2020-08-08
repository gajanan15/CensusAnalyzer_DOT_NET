using System;
using System.Collections.Generic;
using System.Text;

namespace CensusProblem
{
   public class CensusAnalyserException : Exception
    {

        public enum ExceptionType
        {
            FILE_NOT_FOUND, INVALID_TYPE, INVALID_DELIMITER, INVALID_HEADER
        }

        public ExceptionType type;

        public CensusAnalyserException(String message, ExceptionType type) : base(message)
        {
            this.type = type;
        }

    }
}
