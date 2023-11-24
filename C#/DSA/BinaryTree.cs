
public class BinaryTreeNode
{
    public int data { get; set; }
    public BinaryTreeNode? left { get; set; }
    public BinaryTreeNode? right { get; set; }
    
    public BinaryTreeNode(int data)
    {
        this.data = data;
        this.left = null;
        this.right = null;
    }

    public void PrintTree(BinaryTreeNode node)
    {
        if(node == null)
        {
            return;
        }
        Console.WriteLine(node.data);
        PrintTree(node.left);
        PrintTree(node.right);
    }
    
    public void PrintTreeWithDetails(BinaryTreeNode node)
    {
        if(node == null)
        {
            return;
        }
        Console.Write($"{node.data} : ");
        if(node.left != null)
        {
            Console.Write($"{node.left.data} ,");
        }
        if(node.right != null)
        {
            Console.Write($"{node.right.data} .");
        }
        Console.WriteLine();
        PrintTreeWithDetails(node.left);
        PrintTreeWithDetails(node.right);

    }

    public BinaryTreeNode? InputTree()
    {
        var rootdata = Convert.ToInt32(Console.ReadLine());

        if (rootdata == -1)
        {
            return null;
        }
        var root = new BinaryTreeNode(rootdata);

        Console.Write($"Enter Left Node Data :");
        var leftnode = InputTree();
        Console.Write($"Enter Right Node Data :");
        var rightnode = InputTree();

        root.left = leftnode;
        root.right = rightnode;

        return root;
    }

    public int CountofNodes(BinaryTreeNode node)
    {
        if(node == null)
            return 0;
        var leftNodes = CountofNodes(node.left);
        var rightnodes = CountofNodes(node.right);

        return 1 + leftNodes + rightnodes;
    }

    public long SumOfNodes(BinaryTreeNode node)
    {
        if(node == null)
            return 0;
        var leftSum = SumOfNodes(node.left);
        var rightSum = SumOfNodes(node.right);
        var rootdata = Convert.ToInt64(node.data);
        return rootdata + leftSum + rightSum;
    }

    public void PreOrderPrint(BinaryTreeNode root)
    {
        if (root == null)
        {
            return;
        }
        Console.Write($"{root.data} ");
        PreOrderPrint(root.left);
        PreOrderPrint(root.right);

    }

    public void InOrderPrint(BinaryTreeNode root)
    {
        if(root != null)
        {
            InOrderPrint(root.left);
            Console.Write($"{root.data} ");
            InOrderPrint(root.right);
        }
    }

    public void PostOrderPrint(BinaryTreeNode root)
    {
        if(root != null)
        {
            PostOrderPrint(root.left);
            PostOrderPrint(root.right);
            Console.Write($"{root.data} ");
        }

    }

    public int LargestNum(BinaryTreeNode root)
    {
        if(root == null)
        {
            return -1;
        }
        var leftMax = LargestNum(root.left);
        var rightMax = LargestNum(root.right);
        var largest = Math.Max(root.data,Math.Max(leftMax,rightMax));
        return largest;
    }
    
}