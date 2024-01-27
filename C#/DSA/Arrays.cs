public class ArraysDsa
{
    #region find-second-smallest-and-second-largest-element-in-an-array
    /// <summary>
    /// https://takeuforward.org/data-structure/find-second-smallest-and-second-largest-element-in-an-array/
    /// </summary>
    /// <param name="nums">Any array</param>
    /// <returns></returns>
    public int[] SecondMinMax_Optimal(int[] nums)
    {
        if(nums.Length < 2)
        {
            return new int[]{-1,-1};
        }
        int largest = int.MinValue;
        int sec_largest = int.MinValue;
        int smallest = int.MaxValue;
        int sec_smalleest = int.MaxValue;

        for(int i = 0; i < nums.Length; i++)
        {
            if(nums[i] > sec_largest && nums[i] <largest)
            {
                sec_largest = nums[i];
            }
            else if(nums[i] > largest)
            {
                sec_largest = largest;
                largest = nums[i];
            }

            if(nums[i] < sec_smalleest & nums[i] > smallest )
            {
                sec_smalleest = nums[i];
            }
            else if(nums[i] < smallest)
            {
                sec_smalleest = smallest;
                smallest = nums[i];
            }
        }
        return new int[] {sec_smalleest, sec_largest};
    }

    public int[] SecondMinMax_Brute(int[] nums)
    {
        //Initailay sort the arrau
        Array.Sort(nums);
        var sec_largest = nums[nums.Length-2];
        var sec_smallest = nums[1];
        return new int[]{sec_smallest, sec_largest};
    
    }

    #endregion

    #region union-of-two-sorted-arrays

    /// <summary>
    /// https://takeuforward.org/data-structure/union-of-two-sorted-arrays/
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int[] ArrayUnion(int[] nums1, int[] nums2)
    {
       
        return nums1;
    }
    #endregion
    
}