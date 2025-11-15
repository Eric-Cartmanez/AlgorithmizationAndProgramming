using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Tasks.Common;

class Program
{
    static void Main(string[] args)
    {
        var solutionTypes = new List<Type>();
        string executableLocation = AppContext.BaseDirectory;
        var assemblyFiles = Directory.GetFiles(executableLocation, "*.dll");

        foreach (var file in assemblyFiles)
        {
            try
            {
                var assembly = Assembly.LoadFrom(file);
                var typesInAssembly = assembly.GetTypes()
                    .Where(t => typeof(ISolution).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);
                solutionTypes.AddRange(typesInAssembly);
            }
            catch
            {
                continue;
            }
        }
        
        var sortedSolutionTypes = solutionTypes
            .OrderBy(t => t.Namespace)
            .ThenBy(t => t.Name)
            .ToList();

        if (!sortedSolutionTypes.Any())
        {
            Console.WriteLine("Не найдено ни одного решения. Проверьте, что:");
            Console.WriteLine("1. Ссылка на проект с задачей добавлена в Runner.");
            Console.WriteLine("2. Проект с задачей успешно компилируется.");
            Console.WriteLine("3. В папке с Runner.exe лежит .dll файл проекта с задачей.");
            return;
        }

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Выберите решение для запуска:");
            
            for (int i = 0; i < sortedSolutionTypes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {sortedSolutionTypes[i].Namespace} -> {sortedSolutionTypes[i].Name}");
            }
            Console.WriteLine("0. Выход");

            Console.Write("\nВведите номер: ");
            if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 0 || choice > sortedSolutionTypes.Count)
            {
                Console.WriteLine("Неверный ввод. Нажмите Enter для повтора.");
                Console.ReadLine();
                continue;
            }

            if (choice == 0) break;

            var selectedType = sortedSolutionTypes[choice - 1];
            var solution = (ISolution)Activator.CreateInstance(selectedType)!;
            
            Console.Clear();
            solution.Run();

            Console.WriteLine("Нажмите Enter, чтобы вернуться в главное меню.");
            Console.ReadLine();
        }
    }
}