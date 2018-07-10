using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MiscApp
{
    public static class MostCommon
    {
        public static List<string> MostCommonWords(string s, List<string> wordsToExclude)
        {
            var words = s.Split(' ');
            Dictionary<string, int> wordMap = new Dictionary<string, int>();
            int maxCount = 0;
            HashSet<string> mostUsedWords = new HashSet<string>();
            foreach (string str in words)
            {

                if (!wordMap.ContainsKey(str.ToLower()))
                {
                    if (!wordsToExclude.Contains(str.ToLower()))
                    {
                        wordMap.Add(str.ToLower(), 1);
                        if (maxCount == 0)
                        {
                            maxCount++;
                        }
                        if (maxCount == 1)
                        {
                            mostUsedWords.Add(str);
                        }
                    }
                }
                else
                {
                    wordMap[str.ToLower()] += 1;
                    if (maxCount < wordMap[str.ToLower()])
                    {
                        maxCount = wordMap[str.ToLower()];
                        mostUsedWords = new HashSet<string>();
                    }
                    if (maxCount == wordMap[str.ToLower()])
                    {
                        mostUsedWords.Add(str);
                    }
                }

            }

            return mostUsedWords.ToList();

        }



        public static string MostCommonWord(string paragraph, string[] banned)
        {
            Dictionary<string, int> wordsCount = new Dictionary<string, int>();
            string pattern = @"[!?',;.]";
            paragraph = Regex.Replace(paragraph, pattern, " ");
            var allWords = paragraph.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.ToLower());

            int max = Int32.MinValue;
            string maxRepeatedWord = "";
            foreach (var word in allWords)
            {
                if (!banned.Contains(word))
                {
                    if (wordsCount.ContainsKey(word))
                    {
                        wordsCount[word]++;
                    }
                    else
                    {
                        wordsCount.Add(word, 1);
                    }
                    if (max < wordsCount[word])
                    {
                        max = wordsCount[word];
                        maxRepeatedWord = word;
                    }
                }
            }

            return maxRepeatedWord;
        }
    }
}
//class CustomComparer : IComparer<string>
//{

//    Dictionary<string, int> dict;
//    public CustomComparer(ref Dictionary<string, int> wordMap)
//    {
//        dict = wordMap;
//    }

//    public int Compare(string s1, string s2)
//    {
//        if (dict[s1] > dict[s2]) return 1;
//        else if (dict[s1] < dict[s2]) return -1;
//        else
//        {
//            return s2.CompareTo(s1);
//        }
//    }
//}
