using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {

        string directoryPath = @"D:\PROJET PI\Benchmark\Benchmark\file";
        string csvFilePath = "results.csv";
        StreamWriter csvFile = new StreamWriter(csvFilePath);
        csvFile.WriteLine("Fichier,Tri par sélection (ms),Tri à bulle (ms),Tri par insertion (ms),Quicksort (ms)");

        string[] fileNames = Directory.GetFiles(directoryPath, "*.txt");

        foreach (string filePath in fileNames)
        {
            string fileName = Path.GetFileName(filePath);
            List<string> words = new List<string>(File.ReadAllLines(filePath));

            double[] executionTimes = new double[4];

            Action<List<string>>[] sortingAlgorithms = {
                SortingAlgorithms.SelectionSort,
                SortingAlgorithms.BubbleSort,
                SortingAlgorithms.InsertionSort,
                SortingAlgorithms.QuickSort
            };

            for (int i = 0; i < sortingAlgorithms.Length; i++)
            {
                List<string> copy = new List<string>(words);
                double executionTime = Benchmark.MeasureSortingTime(sortingAlgorithms[i], copy);
                executionTimes[i] = executionTime;
            }

            csvFile.WriteLine($"{fileName},{executionTimes[0]},{executionTimes[1]},{executionTimes[2]},{executionTimes[3]}");

            // Tri et hash du fichier pour validation
            SortingAlgorithms.SelectionSort(words); // Utilisez n'importe quel algorithme de tri ici
            string sortedFileName = Path.Combine(directoryPath, "sorted_" + fileName);
            File.WriteAllLines(sortedFileName, words);
            string md5Hash = CalculateMD5(sortedFileName);
            Console.WriteLine($"MD5 Hash of the sorted file {fileName}: {md5Hash}");
        }

        csvFile.Close();
        Console.WriteLine("The results have been saved to the CSV file.");
    }

    static string CalculateMD5(string filePath)
    {
        using (var md5 = MD5.Create())
        {
            using (var stream = File.OpenRead(filePath))
            {
                byte[] hash = md5.ComputeHash(stream);
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }
    }
}