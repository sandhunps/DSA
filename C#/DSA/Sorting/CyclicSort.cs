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

    /// <summary>
    /// LeetCode : 448. Find All Numbers Disappeared in an Array
    /// Link : https://leetcode.com/problems/find-all-numbers-disappeared-in-an-array/description/
    /// </summary>
    /// <param name="arr">Input Array</param>
    /// <returns></returns>
    public int[] MissingElements(int[] arr)
    {
        var i  = 0;
        while(i < arr.Length)
        {
            var current = arr[i]- 1;
            if(arr[i] == arr[current])
            {
                i++;
            }
            else
            {
                Swap(arr,i,current);
            }
        }

        return arr;
    }

    /// <summary>
    /// Leetcode :  287. Find the Duplicate Number
    /// Link : https://leetcode.com/problems/find-the-duplicate-number/description/
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int FindDuplicate(int[] nums) {
        int i = 0;
        while(i < nums.Length)
        {
            if(nums[i] != i+1)
            {   

                var corr = nums[i]-1;
                if(nums[i] != nums[corr])
                {
                    //Swap
                    var temp = nums[corr];
                    nums[corr] = nums[i];
                    nums[i] = temp;
                }
                else
                {
                    return nums[i];
                }
            }
            else 
            {
                i++;
            }
        }
        return -1;  
    }

    /// <summary>
    /// Leetcode : 41. First Missing Positive
    /// Link : https://leetcode.com/problems/first-missing-positive/description/
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int FirstMissingPositive(int[] nums) {
        var i = 0;
        while(i < nums.Length)
        {
            var corr_index = nums[i] - 1;
            if(nums[i] <= 0 || nums[i] > nums.Length)
            {
                i++;
            }
            else if(nums[i] == nums[corr_index])
            {
                i++;
            }
            else
            {
                //swap
                var temp = nums[i];
                nums[i] = nums[corr_index];
                nums[corr_index] = temp;
            }
            
        }
        int j = 0;
        while(j < nums.Length)
        {
            if(nums[j] != j + 1 )
            {
                return j+1;
            }
            j++;
        }
        return -1;    
    }


    private void Swap(int[] arr, int first, int sec)
    {
        var temp = arr[sec];
        arr[sec] = arr[first];
        arr[first] = temp;
    }
}