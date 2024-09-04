public class PrimeCheckerSieve
{
    public bool IsPrime(int number)
    {
        if (number <= 1) return false;

        bool[] isPrime = new bool[number + 1];
        for (int i = 2; i <= number; i++)
        {
            isPrime[i] = true;
        }

        for (int i = 2; i * i <= number; i++)
        {
            if (isPrime[i])
            {
                for (int j = i * i; j <= number; j += i)
                {
                    isPrime[j] = false;
                }
            }
        }

        return isPrime[number];
    }
}
