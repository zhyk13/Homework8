// Напишите программу для работы с матрицей целых чисел.
// Реализуйте класс Answer, который содержит следующие статические методы:
// SumOfRow(int[,] matrix, int row): Метод для вычисления суммы элементов в
// заданной строке row матрицы matrix.
// Метод принимает двумерный массив целых чисел matrix и номер строки row,
// а возвращает целое число - сумму элементов в данной строке.
// MinimumSumRow(int[,] matrix): Метод для определения строки с наименьшей
// суммой элементов. Метод принимает двумерный массив целых чисел matrix и
// возвращает массив из двух элементов: номер строки с наименьшей суммой
// (нумерация начинается с 0) и саму сумму.

using System.ComponentModel.DataAnnotations;

int InputIntNumber(string msg)
{
    System.Console.Write(msg);
    return Convert.ToInt32(Console.ReadLine());
}

int[,] FillMatrixWhithRandom(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = new Random().Next(0, 10);
        }
    }
    return matrix;
}


void PrintMatrix(int[,] printmatrix)
{
    for (int i = 0; i < printmatrix.GetLength(0); i++)
    {
        for (int j = 0; j < printmatrix.GetLength(1); j++)
        {
            System.Console.Write($"{printmatrix[i, j]} ");
        }
        System.Console.WriteLine();
    }
}

int SumOfRow(int[,] matrix, int row)
{
    int sum = 0;
    for (int i = 0; i < matrix.GetLength(1); i++)
    {
        sum = sum + matrix[row, i];
    }
    return sum;
}

int[] MinimumSumRow(int[,] matrix)
{
    int[] numminrow = new int[2];
    numminrow[0] = 0;
    numminrow[1] = SumOfRow(matrix, 0);
    for (int i = 0; i < matrix.GetLength(1); i++)
    {
        if (numminrow[1] > SumOfRow(matrix, i))
        {
            numminrow[1] = SumOfRow(matrix, i);
            numminrow[0] = i;
        }
    }
    return numminrow;
}

int n = InputIntNumber("Введите кол-во строк массива: ");
Console.WriteLine();
int m = InputIntNumber("Введите кол-во столбцов массива: ");
Console.WriteLine();
int[,] matrix = new int[n,m];
matrix = FillMatrixWhithRandom(matrix);
PrintMatrix(matrix);
Console.WriteLine();
int[] rezult = new int[2];
rezult = MinimumSumRow(matrix);
Console.WriteLine($"Номер строки с минимальной суммой элементов - {rezult[0]}");
Console.WriteLine($"Минимальная сумма элементов строки = {rezult[1]}");

