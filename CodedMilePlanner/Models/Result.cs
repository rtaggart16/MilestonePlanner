using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodedMilePlanner.Models
{
    public class Result
    {
        [Required]
        public bool Success { get; set; }

        [Required]
        public string Message { get; set; }

        public Result()
        {
        }

        public Result(bool success, string message)
        {
            this.Success = success;
            this.Message = message;
        }

        public Result CreateResult(bool success, string message)
        {
            return new Result(success, message);
        }
    }


}
