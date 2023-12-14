using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AVLTree
{
    internal class Tree
    {
        public Node root;

        public void Insert(int data)
        {
            root = InsertRec(root, data, null);
        }
        private Node InsertRec(Node node, int data, Node parent)
        {
            if (node == null)
            {
                Node newNode = new Node(data)
                {
                    Parent = parent,
                };
                AVLFunctions.UpdateHeight(newNode);
                return newNode;
            }
            if (data < node.Data)
            {
                node.Left = InsertRec(node.Left, data, node);
            }
            else if (data > node.Data)
            {
                node.Right = InsertRec(node.Right, data, node);
            }

            return AVLFunctions.Balance(node);
        }
        public bool Search(int data)
        {
            return SearchRec(root, data);
        }
        private bool SearchRec(Node root, int data)
        {
            if (root == null)
            {
                return false;
            }
            if (data == root.Data)
            {
                return true;
            }
            if (data < root.Data)
            {
                return SearchRec(root.Left, data);
            }
            else
            {
                return SearchRec(root.Right, data);
            }
        }
        public void Delete(int data)
        {
            root = DeleteRec(root, data);
        }
        private int MinValue()
        {
            if (root == null) throw new InvalidOperationException("Дерево пустое.");
            Node current = root;
            while (current.Left != null)
            {
                current = current.Left;
            }
            return current.Data;
        }
        private int MaxValue()
        {
            if (root == null) throw new InvalidOperationException("Дерево пустое.");
            Node current = root;
            while (current.Right != null)
            {
                current = current.Right;
            }
            return current.Data;
        }


        private Node DeleteRec(Node root, int data)
        {
            if (root == null)
            {
                return root;
            }
            if (data < root.Data)
            {
                root.Left = DeleteRec(root.Left, data);
                if (root.Left != null)
                {
                    root.Left.Parent = root;
                }
            }
            else if (data > root.Data)
            {
                root.Right = DeleteRec(root.Right, data);
                if (root.Right != null)
                {
                    root.Right.Parent = root;
                }
            }
            else
            {
                if (root.Left == null)
                {
                    return root.Right;
                }
                else if (root.Right == null)
                {
                    return root.Left;
                }
                root.Data = MinValue();

                root.Right = DeleteRec(root.Right, root.Data);
                if (root.Right != null)
                {
                    root.Right.Parent = root;
                }
            }
            return root;
        }
        public static string InOrderTraversal(Node root)
        {
            if (root == null)
            {
                return string.Empty;
            }
            string output = InOrderTraversal(root.Left);
            output += root.Data + " ";
            output += InOrderTraversal(root.Right);
            return output;
        }
        public static string PreOrderTraversal(Node root)
        {
            if (root == null)
            {
                return string.Empty;
            }
            string output = "";
            output += root.Data + " ";
            output += InOrderTraversal(root.Left);
            output += InOrderTraversal(root.Right);
            return output;
        }
        public static string PostOrderTraversal(Node root)
        {
            if (root == null)
            {
                return string.Empty;
            }
            string output = PostOrderTraversal(root.Left);
            output += PostOrderTraversal(root.Right);
            output += root.Data + " ";
            return output;
        }
        //public static Tree operator +(Tree tree, int value)
        //{
        //    Tree newTree = new Tree();
        //    IncreasedCopy(newTree, tree.root, value);
        //    return newTree; 
        //}

        //private static Node IncreasedCopy(Tree tree, Node node, int value)
        //{
        //    if (node == null)
        //    {
        //        return null;
        //    }
        //    Node newNode = new Node(node.Data + value);
        //    newNode.Left = IncreasedCopy(tree, node, value);
        //    newNode.Right = IncreasedCopy(tree, node, value);
        //    tree.Insert(newNode.Data);

        //    return newNode;
        //} 
        //public static Tree operator +(Tree tree, int value)
        //{
        //    return new Tree
        //    {
        //        root = IncreasedCopy(tree.root, value)
        //    };
        //}

        //private static Node IncreasedCopy(Node node, int value)
        //{
        //    if (node == null)
        //    {
        //        return null;
        //    }

        //    Node newNode = new Node()
        //    {
        //        Data = node.Data + value,
        //        Left = IncreasedCopy(node.Left, value),
        //        Right = IncreasedCopy(node.Right, value)
        //    };

        //    return newNode;
        //}
        public Tree Clone()
        {
            Tree clonedTree = new Tree();
            clonedTree.root = root.InOrderTraversal();
            return clonedTree;
        }
        public static Tree operator +(Tree left, Tree right)
        {
            if (left is null) return right.Clone();
            if (right is null) return left.Clone();

            int maxValueLeft = left.MaxValue();
            int minValueRight = right.MinValue();
            int maxValueRight = right.MaxValue();
            int minValueLeft = left.MinValue();
            Tree resultTree = new Tree();
            if (maxValueLeft <= minValueRight)
            {
                resultTree = MergeLeftRight(left, right);
            }
            else if (maxValueRight <= minValueLeft)
            {
                resultTree = MergeLeftRight(right, left);
            }
            else
            {
                MergeTrees(left.root, resultTree);
                MergeTrees(right.root, resultTree);
            }

            return resultTree;
        }
        private static void MergeTrees(Node node, Tree resultTree)
        {
            if (node != null)
            {
                resultTree.Insert(node.Data);
                MergeTrees(node.Left!, resultTree);
                MergeTrees(node.Right!, resultTree);
            }
        }
        private Node MinValueNode()
        {
            if (root == null) throw new InvalidOperationException("Дерево пустое.");
            Node current = root;
            while (current.Left != null)
            {
                current = current.Left;
            }
            return current;
        }
        private Node MaxValueNode()
        {
            if (root == null) throw new InvalidOperationException("Дерево пустое.");
            Node current = root;
            while (current.Right != null)
            {
                current = current.Right;
            }
            return current;
        }
        //static Tree MergeLeftRight(Tree left, Tree right)
        //{
        //    Tree resultTree = new Tree();
        //    Node rightMin = right.MinValueNode();

        //    resultTree.root = rightMin;

        //    rightMin.Left = left.root;
        //    if (left.root != null)
        //    {
        //        left.root.Parent = rightMin;
        //    }
        //    rightMin.Right = right.root;

        //    if (rightMin.Parent != null)
        //    {
        //        if (rightMin.Parent.Left == rightMin)
        //        {
        //            rightMin.Parent.Left = null;
        //            rightMin.Parent.Parent = rightMin;
        //        }
        //        else if (rightMin.Parent.Right == rightMin)
        //        {
        //            rightMin.Parent.Right = null;
        //            rightMin.Parent.Parent = rightMin;
        //        }
        //    }
        //    rightMin.Parent = null;
        //    AVLFunctions.UpdateHeight(rightMin);

        //    return resultTree;
        //}
        static Tree MergeLeftRight(Tree left, Tree right)
        {
            Tree resultTree = new Tree();
            Node leftMaxNode = left.MaxValueNode(); //узел x

            Node leftMaxNodeParent = leftMaxNode.Parent;
            leftMaxNodeParent!.Right = null;
            leftMaxNode.Parent = null;

            Node rightEqualHeightNode = right.root; //узел p
            while (rightEqualHeightNode.Height != left.root.Height && rightEqualHeightNode.Left != null)
            {
                rightEqualHeightNode = rightEqualHeightNode.Left;
            }
            Node rightEqualHeightNodeParent = rightEqualHeightNode.Parent;
            rightEqualHeightNodeParent.Left = null;
            rightEqualHeightNode.Parent = null;

            Tree changedTree = new Tree();
            changedTree.root = leftMaxNode;
            leftMaxNode.Left = left.root;
            leftMaxNode.Right = rightEqualHeightNode;

            resultTree.root = right.root;
            Node resultTreeRootLeft = right.root.Left;
            while (resultTreeRootLeft.Height != rightEqualHeightNodeParent.Height)
            {
                resultTreeRootLeft = resultTreeRootLeft.Left;
            }
            resultTreeRootLeft.Left = changedTree.root;

            return resultTree;
        }
    }
}