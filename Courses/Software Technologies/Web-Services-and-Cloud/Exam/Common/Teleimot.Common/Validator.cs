namespace Teleimot.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Contracts;

    public class Validator : IValidator
    {
        // (?!(.).*\1) - negative lookahead, ensures no character repeats anywhere, before
        // consuming and matching characters 
        // (\d{4}) - matches exactly four digits
        public const string numberPattern = @"^(?!.*(.).*\1)(\d{4})$";

        public bool ValidateGameNumber(string number)
        {
            var match = Regex.Match(number, numberPattern);
            return match.Success;
        }
    }
}
