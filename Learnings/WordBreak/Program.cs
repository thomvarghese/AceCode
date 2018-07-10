using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace WordBreak
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = UInt64.MaxValue;
            string s = "bedbathandbeyond";
            List<string> words = new List<string>() { "be","bed", "bath", "and", "beyond", "d", "a"};
            Stopwatch sw = Stopwatch.StartNew();
            var segmentedWords = segmentWords(s, words);
            Console.WriteLine("Input  : " + s);
            Console.WriteLine("Output : " + segmentedWords + " in " + sw.ElapsedMilliseconds);

            sw = Stopwatch.StartNew();
            var msegmentedWords = segmentWordsWithMemo(s, words, new Dictionary<string, string>());
            Console.WriteLine("Input  : " + s);
            Console.WriteLine("Output : " + msegmentedWords + " in " + sw.ElapsedMilliseconds);
            Console.ReadLine();
        }

        
        public static string segmentWords(string input, List<string> wordDict)
        {
            //this has a compexity of 2^n
            if (wordDict.Contains(input))
                return input;

            int len = input.Length;
            for (int i = 1; i < len; i++)
            {
                var prefix = input.Substring(0, i);
                if (wordDict.Contains(prefix))
                {
                    var suffix = input.Substring(i, len - i);
                    var segmentedSuffix = segmentWords(suffix, wordDict);
                    if(segmentedSuffix != null)
                        return prefix + " " + segmentedSuffix;
                    
                }
            }
            return null;
        }

        public static string segmentWordsWithMemo(string input, List<string> wordDict, Dictionary<string, string> memo = null)
        {
            //this has a compexity of 2^n
            if (wordDict.Contains(input))
                return input;
            
            if (memo.ContainsKey(input))
            {
                return memo[input];
            }
            int len = input.Length;
            for (int i = 1; i < len; i++)
            {
                var prefix = input.Substring(0, i);
                if (wordDict.Contains(prefix))
                {
                    var suffix = input.Substring(i, len - i);
                    var segmentedSuffix = segmentWords(suffix, wordDict);
                    if (segmentedSuffix != null)
                        return prefix + " " + segmentedSuffix;
                    
                }
            }

            memo.Add(input, null); // in the memo, we only need to store those cases that dont work
            return null;
        }
    }

    
}
