using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PrimeFinder
{
    internal class Program
    {
        private static void Main()
        {
            var primeFinder = new PrimeFinder();
            var primes = primeFinder.GetPrimes();
            var sum = 0;
            var below = 10u;
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            while (below <= 10000000)
            {
                sum += primes.TakeWhile(p => p < below).Count();
                Console.WriteLine($"There are {sum:N0} primes below {below:N0}");
                below *= 10;
            }
            stopwatch.Stop();
            Console.WriteLine($"And it took me {stopwatch.Elapsed:g} to calculate it");
            Console.ReadLine();
        }

    }

    public class PrimeFinder
    {
        private ulong _currentNumber;

        public IEnumerable<ulong> GetPrimes()
        {
            while (true)
            {
                if (IsPrime(_currentNumber)) yield return _currentNumber;
                _currentNumber++;
            }
        }

        private bool IsPrime(ulong number)
        {
            if (number < 1) return false;
            if (number <= 3) return true;
            if ((number % 2 == 0) || (number % 3 == 0)) return false;
            var i = 5u;
            while (i*i <= number)
            {
                if ((number % i == 0) || (number % (i+2) == 0)) return false;
                i += 6;
            }
            return true;
        }

    }
}
