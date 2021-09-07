using System;
using System.Collections.Generic;
using System.Text;

namespace Trie
{
    class Node
    {
        public Node[] children { get; private set; }

        public Node parent { get; set; }
        
        public bool hasChildren { get; private set; }

        public bool isEnd { get; set; }

        public char value { get; private set; }

        /// <summary>
        /// Constructor for the Node.
        /// </summary>
        /// <param name="val">Character being inserted into the Node.</param>
        public Node(char val)
        {
            children = new Node[0];
            isEnd = false;
            value = val;
            hasChildren = false;
            parent = null;
        }

        /// <summary>
        /// Takes in the character and returns the child Node if it exists within the array.
        /// Otherwise it returns null
        /// </summary>
        /// <param name="c">Character that needs to be checked within the children</param>
        /// <returns>Returns the child if it exists.  Otherwise return null</returns>
        public Node GetChild(char c)
        {
            foreach(Node a in children)
            {
                if(c == a.value)
                {
                    return a;
                }
            }
            return null;
        }

        /// <summary>
        /// Increases the size of the array off children.
        /// Adds the character to a new child in the array.
        /// </summary>
        /// <param name="c">Character inserted into new Child node</param>
        public void AddChild(char c)
        {
            hasChildren = true;
            IncrementChildren(c);
            //children[children.Length - 1] = new Node(c);
            //add child for specific letter
        }

        /// <summary>
        /// Increases the size of the children and inserts char in the location it should be
        /// </summary>
        void IncrementChildren(char c)
        {
            Node[] temp = new Node[children.Length + 1];
            int count = 0;
            int cLocation = -1;
            foreach(Node t in children)
            {
                if (cLocation == -1)
                {
                    if (t.value > c)
                    {
                        temp[count] = new Node(c);
                        cLocation = count;
                        count++;
                        temp[count] = t;
                    }
                    else
                    {
                        temp[count] = t;
                    }
                }
                else
                {
                    temp[count] = t;
                }
                count++;
            }
            if(cLocation == -1)
            {
                temp[children.Length] = new Node(c);
            }
            children = temp;
        }
    }
}
