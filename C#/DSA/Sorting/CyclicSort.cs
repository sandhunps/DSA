public class CyclicSort
{
    /// <summary>
    /// Code for Cyclic Sort. 
    /// Sort an Arry contains numbers [1,N]
    /// </summary>
    /// <param name="arr"></param>
     public void Cyclic_Sort(int[] arr)
    {
        var n = arr.Length;
        for (int i = 0; i < n;)
        {
            if (arr[i] != i + 1)
            {
                var pos = arr[i]-1;
                Swap(arr,i, pos);
            }
            else
            {
                i++;
            }
        }
    }
    
    /// <summary>
    /// Leetcode : 268. Missing Number (Cyclic Sort implementation)
    /// Link : https://leetcode.com/problems/missing-number/description/
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
     public int MissingNumber(int[] nums) 
    {
        
        var len = nums.Length;
        int i = 0;
        while(i < len)
        {   
            // if value at index is equal to index
            // if value at index is greater than or equal to length of array
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
        
        // Loop for finding missing index
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