using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FunWithTasks
{
    public static class PrimesCalculator
    {
        private static bool _isPrime(int number)
        {
            for (int i = 2; i < number; i++)
            {
                if (number % i == 0) return false;
            }

            return true;
        }

        public static IEnumerable<int> GetAllPrimes(int start, int finish, CancellationToken token, IProgress<double>? progress = null)
        {
            for (int i = start; i <= finish; i++)
            {
                if (i % 1000 == 0)
                {
                    var ratio = (double)(i - start) / (finish - start);
                    progress?.Report(ratio);
                }


                if (token.IsCancellationRequested)
                {
                    throw new OperationCanceledException();
                }
                if (_isPrime(i)) yield return i;
            }
        }

        public static IEnumerable<int> GetAllPrimesParallel(int start, int finish, CancellationToken token, IProgress<double>? progress = null)
        {
            return Enumerable
                .Range(start, finish)
                .AsParallel()
                .AsOrdered()
                .WithCancellation(token)
                .Select(i =>
                {
                    if (i % 1000 == 0)
                    {
                        var ratio = (double)(i - start)/ (finish - start);
                        progress?.Report(ratio);
                    }
                    return i;
                })
                .Where(i => _isPrime(i));
        }

    }
}
