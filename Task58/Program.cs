// Реализуйте класс MatrixOperations, который содержит следующие статические методы:
// MultiplyIfPossible(int[,] matrixA, int[,] matrixB): Метод для проверки, возможно
// ли умножения двух матриц matrixA и matrixB. Если число столбцов в матрице matrixA
// не равно числу строк в матрице matrixB, то выводится
// сообщение "It is impossible to multiply." В противном случае, вызывается метод
// MatrixMultiplication для умножения матриц, и результат выводится с помощью метода
// PrintMatrix.
// MatrixMultiplication(int[,] matrixA, int[,] matrixB): Метод для умножения двух
// матриц matrixA и matrixB. Метод возвращает новую матрицу, которая представляет
// собой результат умножения матрицы matrixA на матрицу matrixB.
// PrintMatrix(int[,] matrix): Метод для вывода матрицы на консоль.
// Если аргументы не переданы, программа использует матрицы по умолчанию.
// Если аргументы переданы, программа парсит их в двумерные массивы целых чисел и
// выполняет умножение матриц.

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

int[,] MatrixMultiplication(int[,] matrixA, int[,] matrixB)
{
    int[,] multmatr = new int[matrixA.GetLength(0), matrixB.GetLength(1)];
    for (int i = 0; i < multmatr.GetLength(0); i++)
    {
        for (int j = 0; j < multmatr.GetLength(1); j++)
        {
            for (int k = 0; k < matrixA.GetLength(1); k++)
            {
                multmatr[i,j] = multmatr[i,j] + matrixA[i,k]*matrixB[k,j];
            }
        }
    }
    return multmatr;
}

void MultiplyIfPossible(int[,] matrixA, int[,] matrixB)
{
   if (matrixA.GetLength(1) == matrixB.GetLength(0))
   {
    PrintMatrix(MatrixMultiplication(matrixA, matrixB));
   }
   else
   {
    Console.WriteLine("It is impossible to multiply.");
   }
}

int na = InputIntNumber("Введите кол-во строк массива A: ");
Console.WriteLine();
int ma = InputIntNumber("Введите кол-во столбцов массива A: ");
Console.WriteLine();
int[,] matrixA = new int[na,ma];
matrixA = FillMatrixWhithRandom(matrixA);
PrintMatrix(matrixA);
Console.WriteLine();
int nb = InputIntNumber("Введите кол-во строк массива B: ");
Console.WriteLine();
int mb = InputIntNumber("Введите кол-во столбцов массива B: ");
Console.WriteLine();
int[,] matrixB = new int[nb,mb];
matrixB = FillMatrixWhithRandom(matrixB);
PrintMatrix(matrixB);
Console.WriteLine();
MultiplyIfPossible(matrixA, matrixB);

