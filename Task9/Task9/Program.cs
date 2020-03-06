using System;

namespace Task9
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите число строк массива: ");
            string row = Console.ReadLine();
            Console.Write("Введите число столбцов массива: ");
            string column = Console.ReadLine();

            if (!int.TryParse(row, out int parsedRow) || !int.TryParse(column, out int parsedColumn))
            {
                Console.WriteLine("\nОшибка при вводе значений.");
                Console.ReadKey(true);
                return;
            }
            int[,] array = new int[parsedRow, parsedColumn];
            int[] elementsArray = new int[parsedRow * parsedColumn];

            for (int i = 0; i < elementsArray.Length; i++)
            {
                Console.Write($"Введите {i + 1}-й элемент массива: ");
                if (!int.TryParse(Console.ReadLine(), out elementsArray[i]))
                {
                    Console.WriteLine("\nОшибка при вводе значений.");
                    Console.ReadKey(true);
                    return;
                }
            }

            int m = 0;
            int checkElements = parsedRow * parsedColumn - 1;
            for (int count = 0, rowInArray = parsedRow - 1, columnInArray = parsedColumn - 1; count < 8; count++, rowInArray--, columnInArray--)
            {
                for (int i = count, j = count; j <= columnInArray && m <= checkElements; j++)
                {
                    array[i, j] = elementsArray[m];
                    m++;
                }

                for (int i = count + 1, j = columnInArray; i <= rowInArray - 1 && m <= checkElements; i++)
                {
                    array[i, j] = elementsArray[m];
                    m++;
                }

                for (int i = rowInArray, j = columnInArray; j >= count && m <= checkElements; j--)
                {
                    array[i, j] = elementsArray[m];
                    m++;
                }
                
                for (int i = rowInArray - 1, j = count; i >= count + 1 && m <= checkElements; i--)
                {
                    array[i, j] = elementsArray[m];
                    m++;
                }
            }
            Console.WriteLine();
            for (int i = 0; i < parsedRow; i++)
            {
                for (int j = 0; j < parsedColumn; j++)
                {
                    Console.Write($"{array[i, j]} \t");
                }
                Console.WriteLine();
            }

            Console.ReadKey(true);
        }
    }
}
