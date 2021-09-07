using System;
using System.Collections.Generic;
using System.IO;

namespace Trie
{
    class Program
    {
        static void Main(string[] args)
        {
            Trie trie = new Trie();

            string[] words = File.ReadAllLines("words.txt");
            
            foreach(string word in words)
            {
                trie.AddWord(word);
            }

            string search = Console.ReadLine();
            List<string> autocomplete = trie.AutoComplete(search);

            if (autocomplete != null)
            {
                foreach (string s in autocomplete)
                {
                    Console.WriteLine(search + s);
                }
            }

            Console.ReadLine();
        }
    }
}
