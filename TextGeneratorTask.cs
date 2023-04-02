using System.Collections.Generic;
using System.Linq;

namespace TextAnalysis
{
    static class TextGeneratorTask
    {
        public static string ContinuePhrase(
            Dictionary<string, string> nextWords,
            string phraseBeginning,
            int wordsCount)
        {
            for (int i = 0; i < wordsCount; i++)
            {
                var tempString = phraseBeginning.Split(' ');
                if(tempString.Length > 1)
                {
                   
                    if (nextWords.ContainsKey(tempString[tempString.Length - 2]+" "+ tempString[tempString.Length - 1]))
                    {
                        phraseBeginning += " " + nextWords[tempString[tempString.Length - 2] + " " + tempString[tempString.Length - 1]];

                    }
                    else if (nextWords.ContainsKey(tempString[tempString.Length - 1].ToString()))
                    {
                        phraseBeginning +=" "+ nextWords[tempString[tempString.Length - 1].ToString()];
                    }
                }
                else
                {
                    if (nextWords.ContainsKey(tempString[tempString.Length - 1].ToString()))
                    {
                        phraseBeginning += " " + nextWords[tempString[tempString.Length - 1].ToString()];
                    }
                }
            }
            return phraseBeginning;
        }
    }
}