using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodedMilePlanner.Services
{
    public interface ICodedMileServiceHelper
    {
        string GenerateRandomAlphaNumeric(int length);
    }

    public class CodedMileServiceHelper : ICodedMileServiceHelper
    {
        private static Random random = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ01234567898765432111121314151617181920ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public string GenerateRandomAlphaNumeric(int length)
        {
            return new string(Enumerable.Repeat(chars, length - 1)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
