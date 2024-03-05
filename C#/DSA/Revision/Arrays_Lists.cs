public class ArraysRevision
{
    public void ArrayInitializaation()
    {
        var nums = new int[5] {1, 2, 3, 4, 5};

        // Array Length
        Console.WriteLine(nums.Length);

        // Index of
        var index = Array.IndexOf(nums, 1);
        Console.WriteLine("Index of  1 is : {0}",index);

        // Clear
        Array.Clear(nums,0,2);
        foreach(var n in nums)
        {
            Console.WriteLine(n);
        }

        var strarray = new string[5] {"test","new","now","oh","y"};

        Array.Clear(strarray, 2, 2);
        foreach(var n in strarray)
        {
            Console.WriteLine(n);
        }

        var booarray = new bool[5] {true, false, true, true, true};

        Array.Clear(strarray, 2, 2);
        foreach(var n in booarray)
        {
            Console.WriteLine(n);
        }

        // Copy
        var dst = new int[3];
        Array.Copy(nums,dst,2);
        foreach(var n in dst)
        {
            Console.WriteLine(n);
        }

        // Sort
        var sot = new int[10] {1,4,5,6,7,6,7,4,8,8};
        Array.Sort(sot);

        foreach(var n in sot)
        {
            Console.Write(n);
            Console.Write(",");
        }        
        
    }
}

public class Lists
{
    public void ListRevision()
    {
        // List initialization
        var ls1 = new List<int>();

        var ls = new List<int>(){1, 2, 3, 4, 5};
        Console.WriteLine(string.Join(",",ls));

        // List add 
        ls.Add(6);
        Console.WriteLine(string.Join(",",ls));

        // List AddRange
        ls.AddRange(new List<int> {7, 1, 9});
        Console.WriteLine(string.Join(",",ls));

        // Remove
        // will remove the first occourance of 1
        ls.Remove(1);
        Console.WriteLine(string.Join(",",ls));

        ls1.AddRange(new int[5]{1, 2, 3, 5, 6});
        ls1.Clear();
        Console.WriteLine("Count of ls1 is : {0}", ls1.Count);

        // C# won't allow us to iterate through a list using foreach 
        //and modify the same within foreach loop
        foreach(var l in ls)
        {
            if(l == 1)
            {
                // This operation will throw an error.
                //ls.Remove(l);
            }
        }

        // Instead we could do that inside a for loop
        for(int i = 0; i < ls.Count; i++)
        {
            if(ls[i] == 1)
            {
                ls.Remove(ls[i]);
            }
        }
        Console.WriteLine(string.Join(",",ls));

        // RemoveAt
        ls.RemoveAt(3);
        Console.WriteLine("List after Remove at 7");
        Console.WriteLine(string.Join(",",ls));

        // Index of
        ls.AddRange(new int[2]{1, 1});
        
        // Prints the index  of first appearance of 1
        Console.WriteLine("Index of 1 : {0}",ls.IndexOf(1));


        // Prints the index  of last appearance of 1
        Console.WriteLine("Last Index of 1 : {0}",ls.LastIndexOf(1));




    }
    
    

    
}