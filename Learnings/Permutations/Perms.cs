using System.Collections.Generic;

namespace Permutations
{
    public class Perms
    {
        public List<string> GetPerms(string str)
        {
            List<string> permutations = new List<string>();
            if (str == null) return permutations;
            if (str.Length == 0)
            {
                permutations.Add(""); //base case
                return permutations;
            }
                        
            //Approach 1
            /*char first = str[0];
            string remainder = str.Substring(1);
            List<string> words = GetPerms(remainder);
            foreach(string word in words)
            {
                for(int j = 0; j < word.Length; j++)
                {
                    string s = InsertCharToString(word, first, j);
                    permutations.Add(s);
                }
            }
            return permutations;
            */

            // Approach 2
            for (int i = 0; i < str.Length; i++)
            {
                //remove char i and find the perms of remaining chars
                string before = str.Substring(0, i);
                string after = str.Substring(i);
                List<string> partials = GetPerms(before + after);
                //prepend char i to each permutation
                foreach (string s in partials)
                {
                    permutations.Add(str[i] + s);
                }
            }
            return permutations
        }

        private string InsertCharToString(string word, char c, int position)
        {
            string start = word.Substring(0, position);
            string end = word.Substring(position);
            return start + c + end;
        }


        public List<string> GetPermsWithDuplicateChars(string str)
        {
            //use the above approach with Hastable is an option
            //However creating the permution and then checking if its a dup is not the best
            //alternatively, check if the count of each chars and use that with a dictionary

            List<string> permutations = new List<string>();
            if (str == null) return permutations;
            Dictionary<char, int> charMap = BuildCharFrequencyTable(str);
            FindPerms(charMap, "", str.Length, permutations);
            return permutations;
        }

        private void FindPerms( Dictionary<char, int> map, string prefix, int remaining, List<string> result)
        {
            if (remaining == 0)
            {
                //base case
                result.Add(prefix);
                return;
            }

            foreach( char c in map.Keys)
            {
                int count = map[c];
                if (count > 0)
                {
                    map[c]--;
                    FindPerms(map, prefix + c, remaining - 1, result);
                    map[c] = count;
                }
            }
        }

        private Dictionary<char, int> BuildCharFrequencyTable(string s)
        {
            Dictionary<char, int> charMap = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if (charMap.ContainsKey(c))
                    charMap[c]++;
                else
                    charMap.Add(c, 1);
            }
            return charMap;
        }
    }
}
