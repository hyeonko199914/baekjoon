using System;
using System.Collections.Generic; // Comparer<T>를 사용하기 위해 필요

class TreeNode<T>
{
    public T Value { get; set; }
    public TreeNode<T> Left { get; set; } // ? 제거
    public TreeNode<T> Right { get; set; } // ? 제거

    public TreeNode(T value)
    {
        Value = value;
        Left = null;
        Right = null;
    }
}

class BinaryTree<T>
{
    public TreeNode<T> Root { get; private set; }

    public void Add(T value)
    {
        if (Root == null)
        {
            Root = new TreeNode<T>(value);
        }
        else
        {
            AddTo(Root, value);
        }
    }

    private void AddTo(TreeNode<T> node, T value)
    {
        if (Comparer<T>.Default.Compare(value, node.Value) < 0)
        {
            if (node.Left == null)
                node.Left = new TreeNode<T>(value);
            else
                AddTo(node.Left, value);
        }
        else
        {
            if (node.Right == null)
                node.Right = new TreeNode<T>(value);
            else
                AddTo(node.Right, value);
        }
    }

    public void InOrderTraversal(TreeNode<T> node)
    {
        if (node != null)
        {
            InOrderTraversal(node.Left);
            InOrderTraversal(node.Right);
            Console.Write(node.Value + " ");
            
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        BinaryTree<int> tree = new BinaryTree<int>();
        while(true){
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input)) break;
            
            // 입력 처리
            if (int.TryParse(input, out int value))
            {
                tree.Add(value);
            }
        }

        
        tree.InOrderTraversal(tree.Root);
    }
}
