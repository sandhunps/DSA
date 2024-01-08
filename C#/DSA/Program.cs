
// See https://aka.ms/new-console-template for more information
using System.Reflection.Metadata.Ecma335;


Console.WriteLine("Hello, World!");
int[] arr = {3,4,-1,1};

var sort = new CyclicSort();
var missng = sort.FirstMissingPositive(arr);
Console.WriteLine("Array elements: " + string.Join(" ", missng));


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
}