using System;

namespace DataStructuresPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(5);
            root.InsertNode(root, 1);
            root.InsertNode(root, 2);
            root.InsertNode(root, 3);
            root.InsertNode(root, 4);
            root.InsertNode(root, 6);
            root.InsertNode(root, 7);
            root.InsertNode(root, 8);
            root.InsertNode(root, 9);

            root.PrettyPrint(root);
            Console.WriteLine(root.Height(root));
            //              5
            //          1       6
            //              2       7
            //                  3       8
            //                      4       9
        }
    }
}
