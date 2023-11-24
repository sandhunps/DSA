
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

// Creating nodes
var rootNode = new BinaryTreeNode(4);
var leftChild =  new BinaryTreeNode(3);
var rightChild =  new BinaryTreeNode(5);
var l1 = new BinaryTreeNode(6);
var l2 = new BinaryTreeNode(7);
var r1 = new BinaryTreeNode(8);
var r2 = new BinaryTreeNode(9);

// Connecting Nodes to form a Binary Tree
//            4
//          /   \
//         3     5
//        / \   / \
//       6   7 8   9
rootNode.left = leftChild;
rootNode.right = rightChild;

leftChild.left = l1;
leftChild.right = l2;

rightChild.left = r1;
rightChild.right = r2;

//rootNode.PrintTree(rootNode);

//var root = rootNode.InputTree();
rootNode.PrintTreeWithDetails(rootNode);
//Console.WriteLine($"Count of nodes = {rootNode.CountofNodes(root)}");
//var sum = rootNode.SumOfNodes(root);
//Console.WriteLine($"Sum = {sum}");
rootNode.PreOrderPrint(rootNode);
Console.WriteLine();
rootNode.InOrderPrint(rootNode);
Console.WriteLine();
rootNode.PostOrderPrint(rootNode);
Console.WriteLine($"Largest number is {rootNode.LargestNum(rootNode)}");