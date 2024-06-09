using System;
using System.Collections.Generic;
using System.Diagnostics;

public class Benchmark
{
    public static double MeasureSortingTime(Action<List<string>> sortingAlgorithm, List<string> data)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        sortingAlgorithm(data);
        stopwatch.Stop();
        return stopwatch.Elapsed.TotalMilliseconds;
    }
}
