using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoComplete
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Node
    {
        public string prefix;
        public Dictionary<char, Node> children;
        public bool isWord;
        public Node(string prefix)
        {
            this.prefix = prefix;
            children = new Dictionary<string, Node>();
        }

    }

    public class AutoComplete
    {
        public Node trie;
        public AutoComplete(string[] dict)
        {
            trie = new Node("");
            foreach(var word in dict)
            {
                InsertWord(word);
            }
        }

        private void InsertWord(string word)
        {
            Node curr = trie;
            for(int i = 0; i < word.Length; i++)
            {
                if (!curr.children.ContainsKey(word[i]))
                {
                    curr.children.Add(word[i], new Node(word.Substring(0, i + 1)));
                }
                curr = curr.children[word[i]];
                if (i == word.Length - 1)
                    curr.isWord = true;
            }
        }

        public List<string> GetWordsForPrefix(string prefix)
        {
            var results = new List<string>();
            var curr = trie;
            for(int i = 0; i < prefix.Length; i++)
            {
                if (curr.children.ContainsKey(prefix[i]))
                    curr = curr.children[prefix[i]];
                else
                    return results;
            }

            FindAllChildWords(curr, results);
            return results;
        }

        private void FindAllChildWords(Node n, List<string> results)
        {
            if (n.isWord)
                results.Add(n.prefix);
            foreach(var c in n.children.Keys)
            {
                FindAllChildWords(n.children[c], results);
            }
        }
    }
}
