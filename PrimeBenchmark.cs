using System;
using System.Diagnostics;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using PrimeCheckers;

public class PrimeBenchmark
{
    private int number = 2575723;

    [Benchmark]
    public void TestSimpleAlgorithm()
    {
        PrimeCheckerSimple simpleChecker = new PrimeCheckerSimple();
        simpleChecker.IsPrime(number);
    }

    [Benchmark]
    public void TestOptimizedAlgorithm()
    {
        PrimeCheckerOptimized optimizedChecker = new PrimeCheckerOptimized();
        optimizedChecker.IsPrime(number);
    }

    [Benchmark]
    public void TestSieveAlgorithm()
    {
        PrimeCheckerSieve sieveChecker = new PrimeCheckerSieve();
        sieveChecker.IsPrime(number);
    }
}

class Program
{
    static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<PrimeBenchmark>();

        Console.Write("Lütfen bir sayı girin: ");
        int number;
        while (!int.TryParse(Console.ReadLine(), out number) || number < 1)
        {
            Console.WriteLine("Lütfen geçerli bir pozitif tam sayı girin:");
        }

        PrimeCheckerSimple simpleChecker = new PrimeCheckerSimple();
        PrimeCheckerOptimized optimizedChecker = new PrimeCheckerOptimized();
        PrimeCheckerSieve sieveChecker = new PrimeCheckerSieve();

        Stopwatch stopwatch = new Stopwatch();

        stopwatch.Start();
        bool simpleResult = simpleChecker.IsPrime(number);
        stopwatch.Stop();
        Console.WriteLine($"Basit Algoritma Süresi: {stopwatch.ElapsedTicks} ticks, Sonuç: {simpleResult}");

        stopwatch.Restart();
        bool optimizedResult = optimizedChecker.IsPrime(number);
        stopwatch.Stop();
        Console.WriteLine($"Gelişmiş Algoritma Süresi: {stopwatch.ElapsedTicks} ticks, Sonuç: {optimizedResult}");

        stopwatch.Restart();
        bool sieveResult = sieveChecker.IsPrime(number);
        stopwatch.Stop();
        Console.WriteLine($"Sieve Algoritması Süresi: {stopwatch.ElapsedTicks} ticks, Sonuç: {sieveResult}");
    }
}
