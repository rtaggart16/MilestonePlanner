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
        public List<string> Messages { get; set; }

        public Result()
        {
        }

        public Result(bool success, List<string> messages)
        {
            this.Success = success;
            this.Messages = messages;
        }

        public Result CreateResult(bool success, List<string> messages)
        {
            return new Result(success, messages);
        }
    }


}
