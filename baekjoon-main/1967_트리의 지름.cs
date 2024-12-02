using System;
using System.Collections.Generic;
using System.Linq;

class TreeNode<T>
{
    public T Value { get; set; }
    public TreeNode<T> Parent { get; set; } // 부모 노드
    public int Weight { get; set; } // 부모와의 가중치
    public TreeNode<T> Left { get; set; }
    public TreeNode<T> Right { get; set; }

    public TreeNode(T value, TreeNode<T> parent = null, int weight = 0)
    {
        Value = value;
        Parent = parent;
        Weight = weight;
        Left = null;
        Right = null;
    }
}

class BinaryTree<T>
{
    public TreeNode<T> Root { get; private set; }

    public void Add(T childValue, T parentValue, int weight)
    {
        if (Root == null)
        {
            // 루트 노드 생성
            Root = new TreeNode<T>(childValue);
            return;
        }

        // 부모 노드를 찾아서 추가
        TreeNode<T> parent = FindNode(Root, parentValue);
        if (parent != null)
        {
            TreeNode<T> child = new TreeNode<T>(childValue, parent, weight);

            if (parent.Left == null)
            {
                parent.Left = child;
            }
            else if (parent.Right == null)
            {
                parent.Right = child;
            }
            else
            {
                throw new InvalidOperationException("부모 노드에 자리를 추가할 공간이 없습니다.");
            }
        }
        else
        {
            throw new InvalidOperationException("부모 노드를 찾을 수 없습니다.");
        }
    }

    private TreeNode<T> FindNode(TreeNode<T> node, T value)
    {
        if (node == null) return null;

        if (EqualityComparer<T>.Default.Equals(node.Value, value))
            return node;

        // 왼쪽과 오른쪽에서 부모 노드를 찾음
        TreeNode<T> foundNode = FindNode(node.Left, value);
        if (foundNode == null)
            foundNode = FindNode(node.Right, value);

        return foundNode;
    }

    public void PrintTree()
    {
        PrintNode(Root, 0);
    }

    private void PrintNode(TreeNode<T> node, int depth)
    {
        if (node == null) return;

        Console.WriteLine(new string(' ', depth * 2) + $"{node.Value} (Weight: {node.Weight})");
        PrintNode(node.Left, depth + 1);
        PrintNode(node.Right, depth + 1);
    }
}

class Program
{
    static void Main(string[] args)
    {
        BinaryTree<int> tree = new BinaryTree<int>();

        
        int a = int.Parse(Console.ReadLine()); // 입력할 노드 개수
        tree.Add(1, 0, 0)
        for (int i = 1; i < a; i++)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            tree.Add(input[0], input[1], input[2]); // child, parent, weight
        }

        tree.PrintTree();
    }
}
