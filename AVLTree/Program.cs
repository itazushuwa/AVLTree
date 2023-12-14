using System;
namespace AVLTree;

class Program
{
    static void Main()
    {
        try
        {
            Tree tree = new Tree();
            Tree tree2 = new Tree();
            tree.Insert(1);
            tree.Insert(2);
            tree.Insert(3);
            tree.Insert(4);
            tree.Insert(5);
            tree.Insert(6);
            //tree.Insert(12);
            //Tree increasedTree = tree + 5;
            tree.Search(2);

            tree2.Insert(9);
            tree2.Insert(10);
            tree2.Insert(11);
            tree2.Insert(12);
            tree2.Insert(13);
            tree2.Insert(14);
            tree2.Insert(15);
            tree2.Insert(16);
            tree2.Insert(17);

            Tree mergedTree = tree + tree2;
            Console.WriteLine("Инфиксный обход: ");
            Console.WriteLine(Tree.InOrderTraversal(tree.root));
            Console.WriteLine("Инфиксный обход 2: ");
            Console.WriteLine(Tree.InOrderTraversal(tree2.root));
            Console.WriteLine("Инфиксный обход 3: ");
            //Console.WriteLine(Tree.InOrderTraversal(increasedTree.root));
            Console.WriteLine(Tree.InOrderTraversal(mergedTree.root));

            Console.WriteLine("Префиксный обход: ");
            Console.WriteLine(Tree.PreOrderTraversal(tree.root));
            Console.WriteLine("Префиксный обход 2: ");
            Console.WriteLine(Tree.PreOrderTraversal(mergedTree.root));
            Console.WriteLine("Постфиксный обход: ");
            Console.WriteLine(Tree.PostOrderTraversal(tree.root));
            Console.WriteLine("Постфиксный обход 2: ");
            Console.WriteLine(Tree.PostOrderTraversal(mergedTree.root));
            //tree.Delete(2);
            //tree.Search(2);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}