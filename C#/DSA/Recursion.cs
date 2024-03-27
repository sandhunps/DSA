using System.Globalization;

public class Recursion
{

    #region Find all perumtations
    /// <summary>
    /// Recursive method 
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public static IList<IList<int>> FindAllPermutations(int[] nums)
    {
        IList<IList<int>> res = new List<IList<int>>();
        bool[] map = new bool[nums.Length];
        List<int> ds = new List<int>();
        PremutationsRecursive(nums,res,map,ds);
        return res;
    }

    private static void PremutationsRecursive(int[] nums,IList<IList<int>> result, bool[] map, List<int> ds)
    {
        if(ds.Count == nums.Length)
        {
            result.Add(new List<int>(ds));
            return;
        }

        for(int i = 0; i < nums.Length; i++)
        {
            if(!map[i])
            {
                map[i] = true;
                ds.Add(nums[i]);
                PremutationsRecursive(nums, result,map,ds);
                ds.RemoveAt(ds.Count -1);
                map[i] = false;
            }
        }

        
    }
    #endregion
}