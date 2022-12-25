/*Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, 
которая будет находить строку с наименьшей суммой элементов.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7
Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка*/

//получить число с консоли
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
            array[i, j] = rnd.Next(1, 10);
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

int m = GetNumber("Введите количество строк: ");
int n = GetNumber("Введите количество столбцов: ");

int[,] array = GetArray(m,n);
PrintArray(array);

//находим сумму строк элементов
int FindSumm(int[,] array, int i)
{
  int summ = array[i,0];
  for (int j = 1; j < array.GetLength(1); j++)
  {
    summ += array[i,j];
  }
  return summ;
}

//находим минимальную сумму строк
int minSumm = 0;
int summ = FindSumm(array, 0);
for (int i = 1; i < array.GetLength(0); i++)
{
  int tempsumm = FindSumm(array, i);
  if (summ > tempsumm)
  {
    summ = tempsumm;
    minSumm = i;
  }
}

Console.WriteLine($"{minSumm+1} - строкa с наименьшей суммой элементов, сумма  = {summ}");
