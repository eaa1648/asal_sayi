namespace PrimeCheckers
{
    // Basit asal kontrol algoritması
    public class PrimeCheckerSimple
    {
        public bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;

            for (int i = 2; i <= number / 2; i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }
    }

    // Optimizasyonlu asal kontrol algoritması
    public class PrimeCheckerOptimized
    {
        public bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2 || number == 3) return true;
            if (number % 2 == 0 || number % 3 == 0) return false;

            for (int i = 5; i * i <= number; i += 6)
            {
                if (number % i == 0 || number % (i + 2) == 0) return false;
            }
            return true;
        }
    }

    // Sieve algoritması
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
}
