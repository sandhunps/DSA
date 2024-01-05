
// See https://aka.ms/new-console-template for more information
using System.Reflection.Metadata.Ecma335;

Console.WriteLine("Hello, World!");
int[] arr = {3, 0, 1};

var sort = new Sort();
var missng = sort.MissingNumber(arr);
Console.WriteLine(missng);

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

rootNode.PrintTree(rootNode);

var root = rootNode.InputTree();
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

public class Solution {
    public bool Check(int[] nums) {

        var breaks = 0;

        // [3,4,5,1,2]
        for(int i = 1; i< nums.Length; i++)
        {
            if(nums[i] < nums[i-1])
            {
                breaks = breaks+1;
            }
        }

        if(breaks == 1 || breaks == 0)
            return true;
        else
            return false;
        
    }
}

public class Sort
{
    public void InsertionSort(int[] arr)
    {
        var len = arr.Length;

        for (int i = 0; i < len-1; i++)
        {
            for(int j = i+1; j > 0; j--)
            {
                if(arr[j] < arr[j-1])
                {
                    var temp =  arr[j-1];
                    arr[j-1] = arr[j];
                    arr[j] = temp;
                }
                else{
                    break;
                }
            }
        }

    }

    public void CyclicSort(int[] arr)
    {
        var n = arr.Length;
        for (int i = 0; i < n;)
        {
            if (arr[i] != i + 1)
            {
                var pos = arr[i]-1;
                var temp = arr[pos];
                arr[pos] = arr[i];
                arr[i] = temp;
            }
            else
            {
                i++;
            }
        }
    }

    public int MissingNumber(int[] nums) 
    {
        
        var len = nums.Length;
        int i = 0;
        while(i < len)
        {
            if(nums[i]==i || nums[i]>=len)
            {
                i++;
            }
            else
            {
                Swap(nums, i, nums[i]);
            }
        }
        var j = 0;
        
        while(j < len)
        {
            if(nums[j]!= j)
            {
                break;
            }
            j++;
        }
        return j;
    }

    public void Swap(int[] arr, int first, int sec)
    {
        var temp = arr[sec];
        arr[sec] = arr[first];
        arr[first] = temp;
    }
}