using System;
using System.Collections.Generic;
using System.IO;
using NUnitLite;


namespace TextAnalysis
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            
            var testsToRun = new string[]
            {
                "TextAnalysis.SentencesParser_Tests",
                "TextAnalysis.FrequencyAnalysis_Tests",
                "TextAnalysis.TextGenerator_Tests",
            };
            new AutoRun().Execute(new[]
            {
                "--stoponerror", 
                "--noresult",
                "--test=" + string.Join(",", testsToRun)
            });

            var text = File.ReadAllText("yolochka-i-beryozka.txt");
            var sentences = SentencesParserTask.ParseSentences(text);
            var frequency = FrequencyAnalysisTask.GetMostFrequentNextWords(sentences);
         
           
            
            while (true)
            {
                Console.Write("Введите первое слово (например, harry): ");
                var beginning = Console.ReadLine();
                Console.Write("Введите количество слово: ");
                var countWord = Int32.Parse( Console.ReadLine());
                if (string.IsNullOrEmpty(beginning)) return;
                var phrase = TextGeneratorTask.ContinuePhrase(frequency, beginning.ToLower(), countWord);
                Console.WriteLine(phrase);
            }
        }
    }
}