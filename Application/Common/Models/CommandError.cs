using System;
using System.Collections.Generic;
using System.Text;

namespace MyMoon.Application.Common.Models
{
    public class CommandError
    {
        public CommandError()
        {

        }

        public CommandError(string errorCode, string errorMessage)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
        }

        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}
