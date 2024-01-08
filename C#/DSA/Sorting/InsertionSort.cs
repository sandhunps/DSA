public class InsertionSort
{
    /*
    Insertion Sort divides the given array into two : Sorted and unsorted.
    At each pass , it will insert first elemet from unsorted to sorted array.
    Hence the end of N-1 passes, the array will be sorted
    */
    public void Sort(int[] nums)
    {
        //i selects the index of sorted portion
        var i = 0;
        while(i < nums.Length -1)
        {
            // j starts from then very next element after the sorted section
			// initially i will be 0, and j will be 1
            var j = i+1;
            while(j > 0)
            {
                if(nums[j] < nums[j-1])
                {
                    //swap
                    var temp = nums[j];
                    nums[j] = nums[j-1];
                    nums[j-1] = temp;
                }
                else 
                {
                    // Since left side is already sorted
                    break;
                }
                j--;
            }
            i++;
        }
    }

}