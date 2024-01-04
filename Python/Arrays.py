def check(nums):
        breaks = 0

        for i in range(len(nums)):
            if nums[i] < nums[i-1]:
                breaks += 1
        
        if(breaks <= 1 ):
            return True
        else:
            False


nums = [3,4,5,1,2]
print (check(nums))