using System;
using System.Linq;

namespace Qcet.Helpers
{
    static class StringExtensions
    {
        public static bool MatchesPhrase(this string str, string phrase)
        {
            var strWords = str.Split(
                new[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);
            var phraseWords = phrase.Split(
                new[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);

            return phraseWords.All(
                pattern =>strWords.Any(
                    word => word.StartsWith(
                        pattern,
                        StringComparison.InvariantCultureIgnoreCase)));
        }
    }
}
