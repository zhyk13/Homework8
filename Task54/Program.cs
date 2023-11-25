// Реализуйте класс MatrixOperations, который содержит следующие статические методы:
// PrintMatrix(int[,] matrix): Метод для вывода матрицы на экран. Он принимает на вход
// двумерный массив целых чисел matrix и выводит его элементы в виде таблицы.
// SortRowsDescending(int[,] matrix): Метод для сортировки строк матрицы по убыванию.
// Он принимает на вход двумерный массив целых чисел matrix и сортирует каждую строку
// матрицы так, чтобы элементы в каждой строке шли по убыванию.

using System.ComponentModel.DataAnnotations;

int InputIntNumber(string msg)
{
    System.Console.Write(msg);
    return Convert.ToInt32(Console.ReadLine());
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

int[,] SortRowsDescending(int[,] matrix)
{
    int[] tmp = new int[matrix.GetLength(1)];
    int min = matrix[0,0];
    //int indeximin = 0;
    int indexjmin = 0;
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            min = matrix[i,j];
            //int indeximin = i;
            indexjmin = j;
            for (int k = j; k < matrix.GetLength(1); k++)
            {
                if (matrix[i,k] < min)
                {
                    min = matrix[i,k];
                    indexjmin = k;
                }
            }
            matrix[i,indexjmin] = matrix[i,j];
            matrix[i,j] = min;
        }
    }
    return matrix;
}


int n = InputIntNumber("Введите кол-во строк массива: ");
Console.WriteLine();
int m = InputIntNumber("Введите кол-во столбцов массива: ");
Console.WriteLine();
int[,] matrix = new int[n,m];
matrix = FillMatrixWhithRandom(matrix);
PrintMatrix(matrix);
Console.WriteLine();
matrix = SortRowsDescending(matrix);
PrintMatrix(matrix);

