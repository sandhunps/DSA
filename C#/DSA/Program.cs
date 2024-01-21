
// See https://aka.ms/new-console-template for more information
using System.Reflection.Metadata.Ecma335;

int[] num = {1,2,3};
var cls = new Solution();
cls.GetConcatenation(num);

public class Solution {
    public int[] GetConcatenation(int[] nums) {

        var len = nums.Length;
        int[] res = new int[2*len]; 
        for (int i = 0; i < 2*len ; i++)
        {
            var index  = i%len;
            res[i] = nums[index];
        }

        return res; 
    }
}
public class Person
{
    public int Age; 
}
class Program
{
    static void Main(string[] args)
    {
        var number  = 1;
        Increment(number);
        Console.WriteLine(number);
        // OUTPUT : 1

        var person = new Person() {Age = 10};
        MakeOld(person);
        Console.WriteLine(person.Age);
        // OUTPUT : 20

    }

    public static void Increment(int number)
    {
        number += 10;
    }

    public static void MakeOld(Person person)
    {
        person.Age += 10;
    }
}