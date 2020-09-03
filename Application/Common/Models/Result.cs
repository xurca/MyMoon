using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMoon.Application.Common.Models
{
    public class Result
    {
        public bool Succeeded { get; set; }
        public List<Error> Errors { get; set; }

        public Result()
        {
            Errors = new List<Error>();
        }

        //public CommandResult(bool succeeded, IEnumerable<string> errors)
        //{
        //    Succeeded = succeeded;
        //    Errors = errors.Select(err => new CommandError
        //    {
        //        ErrorMessage = err
        //    }).ToList();
        //}

        //public CommandResult(bool succeeded, IEnumerable<CommandError> errors)
        //{
        //    Succeeded = succeeded;
        //    Errors = errors.ToList();
        //}

        //public static CommandResult Success()
        //{
        //    return new CommandResult(true, new string[] { });
        //}

        //public static CommandResult Failure(IEnumerable<string> errors)
        //{
        //    return new CommandResult(false, errors);
        //}

        //public static CommandResult Failure(IEnumerable<CommandError> errors)
        //{
        //    return new CommandResult(false, errors);
        //}
    }
}
