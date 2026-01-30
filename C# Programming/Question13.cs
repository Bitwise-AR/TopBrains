using System;

class Program
{
    static void Main()
    {
        int[] nums = { 5, -2, 3, 0, 10, 4 };
        int sum = SumPositiveUntilZero(nums);
        Console.WriteLine(sum);
    }

    static int SumPositiveUntilZero(int[] nums)
    {
        int sum = 0;

        foreach (int num in nums)
        {
            if (num == 0)
                break;

            if (num < 0)
                continue;

            sum += num;
        }

        return sum;
    }
}
