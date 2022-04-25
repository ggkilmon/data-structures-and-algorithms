using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresPractice
{
    public class TreeNode
    {
        private const int INDENT_SPACES = 4;
        public TreeNode(int value, TreeNode left = null, TreeNode right = null)
        {
            Value = value;
            Left = left;
            Right = right;
        }

        public int Height(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            return 1 + Math.Max(Height(root.Left), Height(root.Right));
        }

        public TreeNode FindNode(TreeNode root, int searchValue)
        {
            if (root == null || root.Value == searchValue)
            {
                return root;
            }

            if (searchValue > root.Value)
            {
                return FindNode(root.Right, searchValue);
            }

            return FindNode(root.Left, searchValue);
        }

        public TreeNode InsertNode(TreeNode root, int insertValue)
        {
            if (root == null)
            {
                root = new TreeNode(insertValue);
                return root;
            }

            if (insertValue > root.Value)
            {
                root.Right = InsertNode(root.Right, insertValue);
            }
            else if (insertValue < root.Value)
            {
                root.Left = InsertNode(root.Left, insertValue);
            }

            return root;
        }

        public TreeNode RemoveNode(TreeNode root, int deleteValue)
        {
            if (root == null)
            {
                return root;
            }

            if (deleteValue > root.Value)
            {
                root.Right = RemoveNode(root.Right, deleteValue);
            }
            else if (deleteValue < root.Value)
            {
                root.Left = RemoveNode(root.Left, deleteValue);
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

                root.Value = getMinValueInTree(root.Right);
                root.Right = RemoveNode(root.Right, root.Value);
            }

            return root;
        }

        public void PrettyPrint(TreeNode root, int indent = 0)
        {
            if (root != null)
            {
                if (root.Left != null)
                {
                    PrettyPrint(root.Left, indent + INDENT_SPACES);
                }
                if (root.Right != null)
                {
                    PrettyPrint(root.Right, indent + INDENT_SPACES);
                }
                if (indent > 0)
                {
                    Console.Write("".PadLeft(indent));
                }
                Console.WriteLine($"{root.Value}");
            }
        }

        private int getMinValueInTree(TreeNode root) 
        {
            var minValue = root.Value;
            var minNode = root;
            while (minNode.Left != null)
            {
                minValue = minNode.Left.Value;
                minNode = minNode.Left;
            }

            return minValue;
        }

        public int Value { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }
    }
}
