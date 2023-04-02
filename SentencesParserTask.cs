using NUnit.Framework;
using System.Collections.Generic;

namespace TextAnalysis
{
    static class SentencesParserTask
    {
        public static List<List<string>> ParseSentences(string text)
        {
            var sentencesList = new List<List<string>>();
            char[] seporator = { '.', '!', '?', ';', ':', '(', ')' };
            string[] linesText = text.Split(seporator);
            foreach (var line in linesText)
            {
                if (line != "")
                {
                    var list = SplitLineText(line);
                    if (list.Count != 0)
                        sentencesList.Add(list);
                }

            }

            return sentencesList;
        }

        public static List<string> SplitLineText(string text)
        {
            var splitLineText = new List<string>();
            char[] seporator = 

            {   '/', '‘', '…', '“', '”', '.', 
                '!', '?', ';', ':', '(', ')',
                '—', '-', '"', ' ','\r', '\n',
                ',', '\\', '\t','@', '#', '$', 
                '%', '^', '&', '*', '+', '=', '_',
                '1', '2', '3', '4', '5',
                '6', '7', '8', '9', '0' 
            };
            string[] lineText = text.Split(seporator);
            foreach (var item in lineText)
            {
                if (item != "")
                {
                    splitLineText.Add(item.Trim().ToLower());
                }
            };

            return splitLineText;
        }
    }

}
