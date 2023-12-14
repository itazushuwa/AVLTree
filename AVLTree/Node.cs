using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVLTree
{
    internal class Node
    {
        public Node? Parent { get; set; }
        public Node? Left { get; set; }
        public Node? Right { get; set; }
        public int Data { get; set; }
        public int Height { get; set; }

        public Node InOrderTraversal()
        {
            Node newNode = new Node(this.Data);
            if (this.Left != null) this.Left.InOrderTraversal();
            if (this.Right != null) this.Right.InOrderTraversal();
            return newNode;
        }

        //public Node? Parent;
        //public Node? Left;
        //public Node? Right;
        //public int Data;
        //public int Height;

        public Node(int data)
        {
            Height = 1;
            Data = data;
            Parent = null;
            Left = null;
            Right = null;
        }
    }
}