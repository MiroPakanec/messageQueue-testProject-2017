using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities
{
    public static class LoremIpsum
    {
        public static string CreateRandom()
        {
            Random rand = new Random();

            int minWords = rand.Next(0, 10);
            int maxWords = rand.Next(minWords, minWords + 10);
            int minSentences = rand.Next(0, 10);
            int maxSentences = rand.Next(minSentences, minSentences + 10);
            int numParagraphs = rand.Next(0, 10);

            return Create(minWords, maxWords, minSentences, maxSentences, numParagraphs);
        }

        public static string Create(int minWords, int maxWords, int minSentences, int maxSentences, int numParagraphs)
        {
            // http://stackoverflow.com/questions/4286487/is-there-any-lorem-ipsum-generator-in-c

            var words = new[]{"lorem", "ipsum", "dolor", "sit", "amet", "consectetuer",
        "adipiscing", "elit", "sed", "diam", "nonummy", "nibh", "euismod",
        "tincidunt", "ut", "laoreet", "dolore", "magna", "aliquam", "erat"};

            var rand = new Random();
            int numSentences = rand.Next(maxSentences - minSentences)
                + minSentences + 1;
            int numWords = rand.Next(maxWords - minWords) + minWords + 1;

            StringBuilder result = new StringBuilder();

            for (int p = 0; p < numParagraphs; p++)
            {
                //  result.Append("<p>");
                for (int s = 0; s < numSentences; s++)
                {
                    for (int w = 0; w < numWords; w++)
                    {
                        if (w > 0) { result.Append(" "); }
                        result.Append(words[rand.Next(words.Length)]);
                    }
                    result.Append(". ");
                }
                //   result.Append("</p>");
            }

            return result.ToString();
        }
    }
}
