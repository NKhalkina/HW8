/*Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 18*/
int GetNumber(string message)
{
    int result = 0;
    while(true)
    {
        Console.WriteLine(message);
        if(int.TryParse(Console.ReadLine(), out result))
        {
            break;
        }
        else
        {
            Console.WriteLine("Ввели не число");
        }
    }
    return result;
}

//задать матрицу и заполнить ее числами
int[,] GetArray(int m, int n)
{
    int[,] array = new int[m,n];
    Random rnd = new Random();

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = rnd.Next(1, 3);
        }
    }
    return array;
}

//распечатать матрицу
void PrintArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]} ");
        }
        Console.WriteLine();
    }  
}

int m = GetNumber("Введите количество строк первой матрицы: ");
int n = GetNumber("Введите количество столбцов первой матрицы и строк втрой матрицы: ");
int k = GetNumber("Введите количество столбцов второй матрицы: ");

int[,] firstMartrix = GetArray(m,n);
PrintArray(firstMartrix);
Console.WriteLine();
int[,] secomdMartrix = GetArray(n,k);
PrintArray(secomdMartrix);

//произведение первой матрицы на вторую
void resultMatrix(int[,] firstMartrix, int[,] secomdMartrix, int[,] thirdMatrix)
{
  for (int i = 0; i < thirdMatrix.GetLength(0); i++)
  {
    for (int j = 0; j < thirdMatrix.GetLength(1); j++)
    {
      int sum = 0;
      for (int k = 0; k < firstMartrix.GetLength(1); k++)
      {
        sum += firstMartrix[i,k] * secomdMartrix[k,j];
      }
      thirdMatrix[i,j] = sum;
    }
  }
}
int[,] thirdMatrix = new int[m,k];

resultMatrix(firstMartrix, secomdMartrix, thirdMatrix);
Console.WriteLine($"Результирующая матрица будет: ");
PrintArray(thirdMatrix);
