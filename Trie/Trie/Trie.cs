using System;
using System.Collections.Generic;
using System.Text;

namespace Trie
{
    class Trie
    {

        Node root;

        /// <summary>
        /// Constructor for the Trie
        /// </summary>
        public Trie()
        {
            root = new Node(' ');
        }

        /// <summary>
        /// Adds word into the trie
        /// </summary>
        /// <param name="word">The word being inserted into the Trie</param>
        public void AddWord(string word)
        {
            AddWord(word, root);
        }

        /// <summary>
        /// Uses recursion to add the word into the tree
        /// </summary>
        /// <param name="word">The word that is being inserted into the tree</param>
        /// <param name="current">The node parent node of the first character inside the word.</param>
        private void AddWord(string word, Node current)
        {
            char letter = word[0];
            if (current.hasChildren)
            {
                Node temp = current.GetChild(letter);
                if (temp != null)
                {

                }
                else
                {
                    current.AddChild(letter);
                    temp = current.GetChild(letter);
                    temp.parent = current;
                }
                if (word.Length > 1)
                {
                    AddWord(word.Substring(1), temp);
                }
                else
                {
                    temp.isEnd = true;
                }
            }
            else
            {
                Node temp;
                current.AddChild(letter);
                temp = current.GetChild(letter);
                temp.parent = current;

                if (word.Length > 1)
                {
                    AddWord(word.Substring(1), temp);
                }
                else
                {
                    temp.isEnd = true;
                }
            }
        }

        /// <summary>
        /// Gets the Node of the last character in a word recursively.
        /// </summary>
        /// <param name="word">The word being searched for</param>
        /// <param name="current">The Node it is currently on</param>
        /// <returns></returns>
        public Node GetNode(string word, Node current)
        {
            if (word.Length == 0)
            {
                return current;
            }
            Node temp = current.GetChild(word[0]);
            if (temp == null)
            {
                return null;
            }
            return GetNode(word.Substring(1), temp);
        }


        /// <summary>
        /// Returns a list of possible autocompleted words using the current word.
        /// </summary>
        /// <param name="word">The word that has been typed so far</param>
        /// <returns></returns>
        public List<string> AutoComplete(string word)
        {
            Node temp = GetNode(word, root);
            if(temp == null)
            {
                return null;
            }
            if(!temp.hasChildren)
            {
                return null;
            }

            List<string> list = new List<string>();

            Stack<Node> stack = new Stack<Node>();
            
            stack.Push(temp);
            Node current;
            while(stack.Count > 0)
            {
                current = stack.Pop();
                for(int i = current.children.Length-1; i >= 0; i--)
                {
                    stack.Push(current.children[i]);
                    if (current.children[i].isEnd == true)
                    {
                        string w = "";
                        Node n = current.children[i];
                        while (n != temp)
                        {
                            w += n.value;
                            n = n.parent;
                        }
                        string a = "";
                        for(int x = w.Length-1; x>=0;x--)
                        {
                            a += w[x];
                        }
                        list.Add(a);

                    }
                }
            }

            return list;
        }


    }
}
