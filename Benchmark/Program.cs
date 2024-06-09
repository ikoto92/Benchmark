using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string directoryPath = "file";

        string csvFilePath = "results.csv";
        StreamWriter csvFile = new StreamWriter(csvFilePath);
        csvFile.WriteLine("Algorithme,Temps d'exécution (ms)");

        Console.WriteLine("Choisissez un fichier à traiter (1, 2, 3 ou 4) :");
        Console.WriteLine("1. FR_trie.txt");
        Console.WriteLine("2. FR_EN_ES_concat.txt");
        Console.WriteLine("3. FR_EN_ES_shuffle.txt");
        Console.WriteLine("4. DE_shuffle.txt");

        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4)
        {
            Console.WriteLine("Veuillez entrer un nombre valide (1, 2, 3 ou 4) :");
        }


        string[] fileNames = {"08b49b5f34fdc2c28191b45749c365a8.txt", "0e303ef7354aab60637e09a5fae96fa8.txt", "9264a7c4e7251fc75910c4155e5c489a.txt", "e001e8d4317c1db1d6a0f3d3f6d03d25.txt" };

        string fileName = fileNames[choice - 1];
        string filePath = Path.Combine(directoryPath, fileName);

        if (File.Exists(filePath))
        {
            List<string> words = new List<string>(File.ReadAllLines(filePath));

            Action<List<string>>[] sortingAlgorithms = {
                SortingAlgorithms.SelectionSort,
                SortingAlgorithms.BubbleSort,
                SortingAlgorithms.InsertionSort,
                SortingAlgorithms.QuickSort
            };

            foreach (var algorithm in sortingAlgorithms)
            {
                List<string> wordsCopy = new List<string>(words);
                Benchmark.MeasureSortingTime(algorithm, wordsCopy);
                double executionTime = Benchmark.MeasureSortingTime(algorithm, wordsCopy);
                csvFile.WriteLine($"{algorithm.Method.Name},{executionTime}");
            }

            Console.WriteLine("Les résultats ont été enregistrés dans le fichier CSV.");
        }
        else
        {
            Console.WriteLine($"Le fichier {fileName} n'existe pas dans le répertoire.");
        }

        csvFile.Close();
    }
}
