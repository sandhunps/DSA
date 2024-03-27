
// See https://aka.ms/new-console-template for more information
using System.Reflection.Metadata.Ecma335;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("This project is running  fine..... ");
        int[] nums = {1,2,0,1};
        var res = ArraysDsa.LongestConsecutiveSort(nums);

        
        Console.Write(res);
       
    }
}

