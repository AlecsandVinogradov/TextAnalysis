using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace TextAnalysis
{
    static class FrequencyAnalysisTask
    {
        public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> text)
        {
            var result = new Dictionary<string, string>();
            result = FinalDictionary(text);
            return result;
        }
        
        public static Dictionary<string, Dictionary<string, int>> CreateFrequencyDictionaryNGrams( List<List<string>> text,int countNGramm )
        {
            Dictionary<string, Dictionary<string, int>> frequensDiction = new Dictionary<string, Dictionary<string, int>>();
            foreach (var textItem in text)
            {
                for (int i = 0; i < textItem.Count - countNGramm; i++)
                {
                    var key = String.Join(" ", textItem.GetRange(i, countNGramm).Select(x => x).ToArray()).Trim();
                    var value = String.Join(" ", textItem.GetRange(i + countNGramm, 1).Select(x => x).ToArray()).Trim();
                    if (!frequensDiction.ContainsKey(key))
                    {
                        frequensDiction[key] = new Dictionary<string, int> { { value, 1 } };

                    }
                    else
                    {
                        if (!frequensDiction[key].ContainsKey(value))
                        {

                            frequensDiction[key].Add(value, 1);
                        }
                        else
                        {
                            frequensDiction[key][value]++;
                        }
                    }

                }
            }
            return frequensDiction;
        }
        public static Dictionary<string, string> CreateDictionaryNGrams(Dictionary<string, Dictionary<string, int>> dictionary)
        {
            string[] keys = dictionary.Keys.ToArray();
            var finalDictionary = new Dictionary<string, string>();
            var s = new Dictionary<string, int>();
            foreach (var key in keys)
            {
                s = dictionary[key].ToDictionary(x => x.Key, x => x.Value);
                var keyD = s.Keys.ToArray();
                var valye = s.Values.ToArray();
                var tempValue = valye[0];
                var tempKey = keyD[0];
                SortDictionary(keyD, valye, ref tempValue, ref tempKey);
                finalDictionary.Add(key, tempKey);
            }
            return finalDictionary;
            
        }

        private static void SortDictionary(string[] keyD, int[] valye, ref int tempValue, ref string tempKey)
        {
            for (int i = 0; i < valye.Length; i++)
            {
                if (tempValue < valye[i])
                {
                    tempValue = valye[i];
                    tempKey = keyD[i];

                }
                else if (tempValue == valye[i])
                {
                    if (String.CompareOrdinal(tempKey, keyD[i]) > 0)
                    {
                        tempKey = keyD[i];
                    }
                }
            }
        }

        public static Dictionary<string, string> FinalDictionary(List<List<string>> text)
        {
            
            var finalDictionary = new Dictionary<string,string>();
           
                var dictionaryNGramm = CreateFrequencyDictionaryNGrams(text,1);
                var dictionaryNGramm1 = CreateFrequencyDictionaryNGrams(text, 2);
                var dictionaryNGramm2 = CreateFrequencyDictionaryNGrams(text, 3);
                var dictionaryNGramm3 = CreateFrequencyDictionaryNGrams(text, 4);
            CreateDictionaryNGrams(dictionaryNGramm).ToList().ForEach(x=>finalDictionary.Add(x.Key, x.Value));
            CreateDictionaryNGrams(dictionaryNGramm1).ToList().ForEach(x => finalDictionary.Add(x.Key, x.Value));
            CreateDictionaryNGrams(dictionaryNGramm2).ToList().ForEach(x => finalDictionary.Add(x.Key, x.Value));
            CreateDictionaryNGrams(dictionaryNGramm3).ToList().ForEach(x => finalDictionary.Add(x.Key, x.Value));

            return finalDictionary;

        }  
    }

}