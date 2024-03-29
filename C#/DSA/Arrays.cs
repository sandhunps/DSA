using System.Data;
using System.Globalization;

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

    #region Longest Subarray with given Sum K(Positives)
    
    /// <summary>
    /// https://takeuforward.org/data-structure/longest-subarray-with-given-sum-k/
    /// </summary>
    /// <param name="array">Given Array</param>
    /// <param name="k">Required Sum</param>
    /// <returns>Length of longest subarray</returns>
    public static int LongestSubarrayWithGivenSum_K_Brute(int[] array, long k)
    {
       
        int len = 0;
        for(int i = 0; i < array.Length; i++)
        {
             long sum = 0;
            for(int j = i; j < array.Length; j++)
            {
                sum += array[j];

                if (sum == k)
                {
                    len = Math.Max(len, j - i + 1);
                }
            }
        }
        return len;
    }

    /// <summary>
    /// https://takeuforward.org/data-structure/longest-subarray-with-given-sum-k/#optimal-approach-1
    /// Cannot use this approch if the array contains zeros or negatives
    /// </summary>
    /// <param name="array">Given Array</param>
    /// <param name="k">Required Sum</param>
    /// <returns>Length of longest subarray</returns>
    public static int LongestSubarrayWithGivenSum_K_Hashmap(int[] array, long k)
    {
        long sum = 0;
        int len = 0;
        Dictionary<long, int> presum = new Dictionary<long, int>();
        for(int i = 0; i< array.Length; i++)
        {
            sum += array[i];

            if (sum ==k)
            {
                len = Math.Max(len, i+1);
            }

            long compliment =  sum - k;

            if(presum.ContainsKey(compliment))
            {
                int subarrayLen = i - presum[compliment];
                len = Math.Max(len, subarrayLen);
            }
            // Finally, update the map checking the conditions:
            if (!presum.ContainsKey(sum))
            {
                presum.Add(sum, i);
            }
        }
        return len;
    }

    /// <summary>
    /// https://takeuforward.org/data-structure/longest-subarray-with-given-sum-k/#optimal-approach-2
    /// </summary>
    /// <param name="array"></param>
    /// <param name="k"></param>
    /// <returns></returns>
    public static int LongestSubarrayWithGivenSum_K_TwoPointer(int[] array, long k)
    {
        int left =0,right =0;
        long sum = array[0];
        int maxLen = 0;
        int n = array.Length;

        while(right < n)
        {
            while(left <= right && sum > k)
            {
                sum -= array[left];
                left++;
            }
            if(sum == k)
            {
                maxLen = Math.Max(maxLen, right - left +1);
            }

            right++;
            if(right < n)
            {
                sum += array[right];
            }

        }

        return maxLen;
    }

    #endregion

    #region Subarray Sum Equals K(Negatives included)

    /// <summary>
    /// https://leetcode.com/problems/subarray-sum-equals-k/description/
    /// Here the array may contain negatives and zeros
    /// </summary>
    /// <param name="array"></param>
    /// <param name="k"></param>
    /// <returns>Count of Subarrays with sum K</returns>
    public static int SubarraySumCount_Brute(int[] array, int k)
    {
        int count = 0;

        for(int i = 0; i < array.Length; i++)
        {
            int sum = 0;
            for(int j = i; j < array.Length; j++)
            {
                sum += array[j];
                if(sum == k)
                {
                    count += 1;
                }
            }
        }
        return count;
    }

   /// <summary>
    /// https://leetcode.com/problems/subarray-sum-equals-k/description/
    /// Here the array may contain negatives and zeros
    /// </summary>
    /// <param name="array"></param>
    /// <param name="k"></param>
    /// <returns>Count of Subarrays with sum K</returns>
    public static int SubarraySumCount_Optimal_Preixsum(int[] array, int k)
    {
        int count = 0;
        Dictionary<int,int> preSumMap = new Dictionary<int, int>();
        int sum = 0;
        // initialising the preSumMap with {0,1} detoting that sum of 0 has occoured once
        preSumMap.Add(0,1);

        for (int i =0; i < array.Length; i++)
        {
            sum += array[i];
            int rem = sum - k;

            if(preSumMap.ContainsKey(rem))
            {
                count += preSumMap[rem];
            }

            preSumMap[sum] = preSumMap.GetValueOrDefault(sum, 0)+1;

        }
        return count;
    }
    #endregion

    #region Kadane's Algorithm : Maximum Subarray Sum in an array

    /// <summary>
    /// https://leetcode.com/problems/maximum-subarray/
    /// </summary>
    /// <param name="nums"></param>
    /// <returns>Maximum Sum of subarray</returns>
    public static int MaxSumSubArray_Brute(int[] nums)
    {
        int maxSum = int.MinValue;

        for(int i = 0; i < nums.Length; i++)
        {
            int sum =0;
            for (int j = i; j< nums.Length; j++)
            {
                sum += nums[j];
                maxSum = Math.Max(maxSum, sum);
            }
        }
        return maxSum;
    }

    /// <summary>
    /// Kadane’s Algorithm
    /// </summary>
    /// <param name="nums"></param>
    /// <returns>Maximum sum of subarray</returns>
    public static int MaxSumSubArray_Optimal(int[] nums)
    {   
        int global_max = int.MinValue;
        int current_max = 0;

        for(int i =1; i < nums.Length; i++)
        {
            current_max = Math.Max(nums[i], current_max + nums[i]);

            global_max = Math.Max(global_max, current_max);
        }
        return global_max;
    }
    #endregion 

    #region Kadan's Algorithm : Print Maximum Subarray (Followup Question) 
    
    public static void PrintMaxSumSubArray_Optimal(int[] array)
    {
        int global_max = int.MinValue;
        int current_max = array[0];
        int start = 0;
        int end = 0;
        int ptr = 0;

        for(int i = 1; i < array.Length; i++)
        {
            if( array[i] > current_max + array[i])
            {
                current_max = array[i];
                ptr = i;
            }
            else
            {
                current_max = current_max + array[i];
            }

            if (current_max > global_max)
            {
                global_max = current_max;
                start = ptr;
                end = i;
            }
        }

        for(int i = start; i <= end; i++)
        {
            Console.WriteLine(array[i] +  " ");
        }

    }
    #endregion

    #region  Buy and Sell Stock

    /// <summary>
    /// https://takeuforward.org/data-structure/stock-buy-and-sell/
    /// </summary>
    /// <param name="prices"></param>
    /// <returns></returns>
    public static int MaxProfit_Brute(int[] prices) 
    {
        int maxProfit = 0;
        for(int i = 0; i < prices.Length; i++)
        {
            for(int j = i+1; j< prices.Length; j++)
            {
                if(prices[j]>prices[i])
                {
                    int profit = prices[j] - prices[i];
                    maxProfit = Math.Max(maxProfit, profit);
                }
               
            }
        }
        
        return maxProfit;
    }

    public static int MaxProfit_Optimal(int[] prices) 
    {   
        int maxProfit = 0;
        int minValue = int.MaxValue;
        for(int i = 0; i < prices.Length; i++)
        {
            minValue = Math.Min(minValue, prices[i]);

            maxProfit = Math.Max(maxProfit, prices[i] - minValue);
        }
        
        return maxProfit;
    }
    #endregion

    #region Rearrange Array Elements by Sign

    /// <summary>
    /// https://takeuforward.org/arrays/rearrange-array-elements-by-sign/
    /// </summary>
    /// <param name="nums"></param>
    /// <returns>Rearrange array</returns>
    public static int[] RearrangeArray_Brute(int[] nums)
    {
        var pos = new List<int>();
        var neg =  new List<int>();
        var res =  new int[nums.Length];

        for(int i = 0; i < nums.Length; i++)
        {
            if(nums[i] > 0)
            {
                pos.Add(nums[i]);
            }
            else{
                neg.Add(nums[i]);
            }
        }

        for (int i = 0; i < (nums.Length)/2; i++)
        {
            res[2*i] = pos[i];
            res[2*i + 1] = neg[i];
        }
        return res;
    }

    /// <summary>
    /// https://takeuforward.org/arrays/rearrange-array-elements-by-sign/
    /// </summary>
    /// <param name="nums"></param>
    /// <returns>Rearrange array</returns>
    public static int[] RearrangeArray_Optimal(int[] nums)
    {
        var res =  new int[nums.Length];
        int posIndex = 0, negIndex =1;

        for(int i = 0; i < nums.Length; i++)
        {
            if(nums[i] < 0)
            {
                res[negIndex] = nums[i];
                negIndex += 2;
            }
            else{
                res[posIndex] = nums[i];
                posIndex += 2;
            }
        }
        return res;

    }
    #endregion

    #region Rearrange Array Elements by Sign - Unequal Postitives and negatives

    public static int[] RearrangeArrayUnequal(int[] nums)
    {
        var ans = new int[nums.Length];
        var pos = new List<int>();
        var neg = new List<int>();

        for(int i = 0; i < nums.Length; i++)
        {
            if(nums[i] > 0)
            {
                pos.Add(nums[i]);
            }
            else
            {
                neg.Add(nums[i]);
            }
        }
        
        if(pos.Count > neg.Count)
        {
            for(int i = 0; i < neg.Count; i++)
            {
                ans[2*i] = pos[i];
                ans[2*i +1] = neg[i];
            }

            var index = 2* neg.Count;
            for(int i = neg.Count; i < pos.Count; i++)
            {
                ans[index] = pos[i];
                index++;
            }
        }
        else
        {
            for(int i = 0; i < pos.Count; i++)
            {
                ans[2*i] = pos[i];
                ans[2*i +1] = neg[i];
            }

            var index = 2* pos.Count;
            for(int i = pos.Count; i < neg.Count; i++)
            {
                ans[index] = neg[i];
                index++;
            }
        }
        return ans;
    } 
    #endregion

    #region Next Permunatation
    public void NextPermutation(int[] nums) {
        int index = -1;
        int n = nums.Length;
        for(int i = n -2; i>=0;i--)
        {
            if(nums[i]<nums[i+1]){
                index=i;
                break;
            }
        }
        if(index == -1){
            Array.Reverse(nums,0,n-1); 
            return;
        }
        for(int i = n -1; i>=0;i--)
            {
                if(nums[index]<nums[i])
                {
                    int swap = 0;
                    swap = nums[i];
                    nums[i] = nums[index];
                    nums[index] = swap;
                    break;
                }
            }
        Array.Reverse(nums, index+1, n-1-index);    
    }
    #endregion
    
    #region Leader in an array
    
    /// <summary>
    /// https://takeuforward.org/data-structure/leaders-in-an-array/
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public static List<int> LeaderArrayBrute(int[] nums)
    {
        var res = new List<int>();
        

        for(int i = 0; i < nums.Length; i++)
        {
            bool isLeader = true;
            for (int j = i + 1; j < nums.Length; j++)
            {
                if(nums[j] > nums[i])
                {
                    isLeader =false;
                    break;
                }

            }
            if(isLeader)
            {
                res.Add(nums[i]);
            }
        }
    return res;
    }

    /// <summary>
    /// https://takeuforward.org/data-structure/leaders-in-an-array/
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public static List<int> LeaderArrayOptimal(int[] nums)
    {
        var res = new List<int> ();

        // Last element will always be a leader
        int max = nums[nums.Length-1];
        res.Add(max);

        for(int i = nums.Length-2; i >= 0; i--)
        {
            if(nums[i] > max)
            {
                res.Add(nums[i]);
                max = nums[i];
            }
        }
        return res;
    }
    #endregion

    #region Longest Consecutive Sequence
    /// <summary>
    /// https://takeuforward.org/data-structure/longest-consecutive-sequence-in-an-array/
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public static int LongestConsecutiveBrute(int[] nums) {
        int longest = 1;
        
        for(int i = 0; i< nums.Length; i++)
        {
            var x =nums[i];
            var ctr = 1;

            while(LinearSearch(nums,x+1))
            {
                x += 1;
                ctr += 1;
            }
            
            longest = Math.Max(longest,ctr);
        }
        return longest;
    }

    private static bool LinearSearch(int[] nums, int ele)
    {
        var res = false;
        for(int i = 0; i < nums.Length; i++)
        {
            if(nums[i] == ele)
            {
                res = true;
                break;
            }
        }
        return res;
    }

    /// <summary>
    /// https://takeuforward.org/data-structure/longest-consecutive-sequence-in-an-array/
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public static int LongestConsecutiveSort(int[] nums)
    {
        Array.Sort(nums);
        var longest = 1;
        var ctr = 1;
        for(int i = 0; i < nums.Length-1; i++)
        {   
            if(nums[i+1] == nums[i]+1)
            {
                ctr += 1;
                longest = Math.Max(longest,ctr);
            }
            else if(!(nums[i] == nums[i+1]))
            {
                
                ctr = 1;
            }
            
        }
        return longest;
    }

    /// <summary>
    /// https://takeuforward.org/data-structure/longest-consecutive-sequence-in-an-array/
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public static int LongestConsecutiveOptimal(int[] nums)
    {
        int n = nums.Length;
        if (n == 0)
            return 0;

        int longest = 1;
         HashSet<int> set = new HashSet<int>();

         for (int i = 0; i < nums.Length; i++)
         {
            set.Add(nums[i]);
         }

         foreach (int ele in set)
         {
            if(!set.Contains(ele-1))
            {
                // find consecutive numbers
                int cnt = 1;
                int x = ele;
                while (set.Contains(x + 1))
                {
                    x = x + 1;
                    cnt = cnt + 1;
                }
                longest = Math.Max(longest, cnt);

            }
         }
        return longest;
    }
    #endregion

    #region  Set Matrix Zeroes

    /// <summary>
    /// https://takeuforward.org/data-structure/set-matrix-zero/
    /// </summary>
    /// <param name="matrix"></param>
    public void SetZeroesBinary(int[][] matrix) {
        // Row length
        var m = matrix.Length;
        // Column length
        var n = matrix[0].Length;

        for(int i = 0; i < m; i++)
        {
            for(int j = 0; j < n; j++)
            {
                if(matrix[i][j] == 0)
                {
                    // mark entire row -1
                    for(int k = 0; k < n; k++ )
                    {
                        if(matrix[i][k] != 0)
                        {
                            matrix[i][k] = int.MinValue;
                        }
                    }
                    // mark entire column -1
                    for(int k = 0; k < m; k++)
                    {
                        if(matrix[k][j] != 0)
                        {
                            matrix[k][j] = int.MinValue;
                        }
                    }
                }
            }
        }

        // mark all -1 to 0
        for(int i = 0; i < m; i++)
        {
            for(int j = 0; j < n; j++)
            {
                if(matrix[i][j] == int.MinValue)
                {
                    matrix[i][j] = 0;
                }
            }
        }
    }

    /// <summary>
    /// https://takeuforward.org/data-structure/set-matrix-zero/
    /// </summary>
    /// <param name="matrix"></param>
    public void SetZeroesBetter(int[][] matrix) {
        // Row length
        var m = matrix.Length;
        // Column length
        var n = matrix[0].Length;

        // row array
        var row = new int[m];
        // col array
        var col = new int[n];

        for(int i = 0; i < m; i++)
        {
            for(int j = 0; j < n; j++)
            {
                if(matrix[i][j] == 0)
                {
                    row[i] = 1;
                    col[j] = 1;
                }
            }
        }

        // mark all elements 0 based on row array and col array
        for(int i = 0; i < m; i++)
        {
            for(int j = 0; j < n; j++)
            {
                if(row[i] == 1 || col [j] == 1)
                {
                    matrix[i][j] = 0;
                }
            }
        }
    }

    /// <summary>
    /// https://takeuforward.org/data-structure/set-matrix-zero/
    /// </summary>
    /// <param name="matrix"></param>
    public void SetZeroesOptimal(int[][] matrix) {
        // Row length
        var m = matrix.Length;
        // Column length
        var n = matrix[0].Length;

        var firstrowZero = false;
        var firstcolZero = false;

        // check if first row contains zero
        for(int i = 0; i < n; i++)
        {
            if(matrix[0][i] == 0)
            {
                firstrowZero = true;
                break;
            }
        }

        // check if first col contains zero
        for(int i = 0; i < m; i++)
        {
            if(matrix[i][0] == 0)
            {
                firstcolZero = true;
                break;
            }
        }
         // Use the first row and first column to mark rows and columns containing zeros
        for(int i = 1; i < m; i++)
        {
            for(int j = 1; j < n; j++)
            {
                if(matrix[i][j] == 0)
                {
                    matrix[0][j] = 0;
                    matrix[i][0] = 0;
                }
            }
        }

        // Set elements to zero based on markings in the first row and first column
        for(int i = 1; i < m; i++)
        {
            for(int j = 1; j < n; j++)
            {
                if(matrix[i][0] == 0 || matrix[0][j] == 0)
                {
                    matrix[i][j] = 0;
                }
            }
        }

        // Handle the first row and first column separately
        if (firstrowZero)
        {
            for (int j = 0; j < n; j++)
            {
                matrix[0][j] = 0;
            }
        }

        if (firstcolZero)
        {
            for (int i = 0; i < m; i++)
            {
                matrix[i][0] = 0;
            }
        }
    }
    #endregion
}
