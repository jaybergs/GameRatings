using System;

namespace WebSite.Validators
{
    public class BaseValidator : IBaseValidator
    {
        public bool Validate(string input)
        {
            return true;
        }

        public void ValidateThrow(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentOutOfRangeException("Input must not be null or white space or empty.");
            }
        }
    }
}