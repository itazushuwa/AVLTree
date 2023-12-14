using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AVLTree
{
    internal class AVLFunctions
    {
        private Node root;

        public AVLFunctions()
        {
            root = null;
        }
        public static Node Balance(Node node)
        {
            UpdateHeight(node);

            if (_BalanceFactor(node) > 1)
            {
                if (_BalanceFactor(node.Right) < 0)
                {
                    node.Right = _SmallRightRotate(node.Right);
                }
                return _SmallLeftRotate(node);
            }
            if (_BalanceFactor(node) < -1)
            {
                if (_BalanceFactor(node.Left) > 0)
                {
                    node.Left = _SmallLeftRotate(node.Left);
                }
                return _SmallRightRotate(node);
            }
            return node;
        }
        private static int Height(Node node)
        {
            if (node != null) return node.Height;
            else return 0;
        }
        public static int BalanceFactor(Node node)
        {
            return _BalanceFactor(node);
        }
        private static int _BalanceFactor(Node node)
        {
            if (node == null) return 0;

            return Height(node.Right) - Height(node.Left);
        }
        public static void UpdateHeight(Node root)
        {
            if (root != null)
            {
                root.Height = Math.Max(Height(root.Left!), Height(root.Right!)) + 1;
            }
        }
        public static Node SmallRightRotate(Node node)
        {
            return _SmallRightRotate(node);
        }
        private static Node _SmallRightRotate(Node node)
        {
            if (node == null || node.Left == null) return node;
            Node newRoot = node.Left;
            node.Left = newRoot.Right;
            newRoot.Right = node;

            UpdateHeight(node);
            UpdateHeight(newRoot);
            if (node.Left != null) node.Left.Parent = node;
            newRoot.Parent = node.Parent;
            node.Parent = newRoot;

            return newRoot;
        }
        public static Node SmallLeftRotate(Node node)
        {
            return _SmallLeftRotate(node);
        }
        private static Node _SmallLeftRotate(Node node)
        {
            if (node == null || node.Right == null) return node;
            Node newRoot = node.Right;
            node.Right = newRoot.Left;
            newRoot.Left = node;
            UpdateHeight(node);
            UpdateHeight(newRoot);

            if (node.Right != null) node.Right.Parent = node;
            newRoot.Parent = node.Parent;
            node.Parent = newRoot;

            return newRoot;
        }
    }
}