using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;

public class Benchmark
{
    public static double MeasureSortingTime(Action<List<string>> sortFunc, List<string> arr)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        sortFunc(arr);
        stopwatch.Stop();
        return stopwatch.Elapsed.TotalMilliseconds;
    }

    public static string CalculateMD5(string filePath)
    {
        using (var md5 = MD5.Create())
        {
            using (var stream = File.OpenRead(filePath))
            {
                var hashBytes = md5.ComputeHash(stream);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
    }
}
