
// See https://aka.ms/new-console-template for more information
using System.Reflection.Metadata.Ecma335;

class Program
{
    static void Main(string[] args)
    {
        var sol = new ArraysDsa();
        var nums  = new int[] {1,2,3,4,5,6,7,8,9};
        var ans = sol.SecondMinMax_Brute(nums);

        Console.WriteLine(string.Join(",",ans));
    }
   
}