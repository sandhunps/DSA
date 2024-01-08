
// See https://aka.ms/new-console-template for more information
using System.Reflection.Metadata.Ecma335;


Console.WriteLine("Hello, World!");
int[] arr = {3,4,-1,1};

var sort = new InsertionSort();
sort.Sort(arr);
Console.WriteLine("Array elements: " + string.Join(" ", arr));


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
