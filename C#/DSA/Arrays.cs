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
        var len1 = nums1.Length;
        var len2 = nums2.Length;
        var pnt1 = 0;
        var pnt2= 0;
        var res = new List<int>();
        while(len1> 0 && len2 >0)
        {
            if(nums1[pnt1] == nums2[pnt2])
            {
                if(res[res.Count - 1] != nums1[pnt1])
                {
                    res.Add(nums1[pnt1]);  
                }
                
            }
        }
        return nums1;
    }
    #endregion
    
    #region Union of Two Sorted Arrays
    
        public List<int> Union_Brute(int[] nums1, int[] nums2) {
    
        var union =  new List<int>();

        var dct = new SortedDictionary<int,int>();

        for(var i = 0; i < nums1.Length; i++)
        {
            dct[nums1[i]] = 1;
        }

        for(var i = 0; i < nums2.Length; i++)
        {
            dct[nums2[i]] =1;
        }

       foreach (var key in dct)
       {
          union.Add(key.Key);
       }


        return union;

    }

        public List<int> Union_Twopointer(int[] nums1,int[] nums2)
    {
        var union = new List<int>();
        var i = 0;
        var j = 0;
        var len1 = nums1.Length;
        var len2 = nums2.Length;

        while(i < len1 && j < len2)
        {
            if(nums1[i] < nums2[j])
            {
                union.Add(nums1[i]);
                i++;
            }
            else if(nums1[i]> nums2[j])
            {
                union.Add(nums2[j]);
                j++;
            }
            else
            {
                union.Add(nums1[i]);
                i++;
                j++;
            }
        }

        if(len1>len2)
        {
            for(var k = i; i<len1-1;i++)
            {
                union.Add(nums1[k]);
            }
        }
        else{
            for(var k = j; k<len2-1;k++)
            {
                union.Add(nums2[k]);
            }
        }

        return union;
    }

    #endregion
}