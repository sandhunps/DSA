
// See https://aka.ms/new-console-template for more information
using System.Reflection.Metadata.Ecma335;

class Program
{
    static void Main(string[] args)
    {
        int[] array = {2, 2, 4, 1, 2 };
        var longest = LongestSubarray.LongestSubarrayWithGivenSum_K_Brute(array,2);
        Console.WriteLine("This project is running  fine..... ");
        Console.WriteLine("Longest subarray is of length {0}",longest);
    }
   
}

public static class LongestSubarray
{
    /// <summary>
    /// https://takeuforward.org/data-structure/longest-subarray-with-given-sum-k/
    /// </summary>
    /// <param name="array">Given Array</param>
    /// <param name="k">Required Sum</param>
    /// <returns></returns>
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
}

