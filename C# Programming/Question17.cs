using System;

class Program
{
    static void Main()
    {
        int initialBalance = int.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());

        int[] transactions = new int[n];
        for (int i = 0; i < n; i++)
        {
            transactions[i] = int.Parse(Console.ReadLine());
        }

        int finalBalance = SimulateBankAccount(initialBalance, transactions);
        Console.WriteLine(finalBalance);
    }

    static int SimulateBankAccount(int initialBalance, int[] transactions)
    {
        int balance = initialBalance;

        foreach (int tx in transactions)
        {
            if (tx >= 0)
            {
                balance += tx;
            }
            else
            {
                int withdrawal = -tx;
                if (balance >= withdrawal)
                {
                    balance -= withdrawal;
                }
            }
        }

        return balance;
    }
}
