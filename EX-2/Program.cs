Console.Write("Введите количество строк: ");
int strings = int.Parse(Console.ReadLine());

Console.Write("Введите количество столбцов: ");
int columns = int.Parse(Console.ReadLine());

int[,] matrix1 = new int[strings, columns];
int[,] matrix2 = new int[strings, columns];
int[,] matrixSumm = new int[strings, columns]; //Три матрицы с заданным количеством строк

Random rand = new Random();

Console.WriteLine("Первая матрица"); //Первая матрица
for (int i = 0; i < strings; i++)
{
    for (int j = 0; j < columns; j++)
    {
        matrix1[i, j] = rand.Next(-10, 10);
        Console.Write($"{matrix1[i, j],3}");
    }
    Console.WriteLine();
}
Console.WriteLine();


Console.WriteLine("Вторая матрица"); //Вторая матрица
for (int i = 0; i < strings; i++)
{
    for (int j = 0; j < columns; j++)
    {
        matrix2[i, j] = rand.Next(-10, 10);
        Console.Write($"{matrix2[i, j],3}");
    }
    Console.WriteLine();
}
Console.WriteLine();


Console.WriteLine("Сумма матриц"); //Сумма матриц
for (int i = 0; i < strings; i++)
{
    for (int j = 0; j < columns; j++)
    {
        matrixSumm[i, j] = matrix1[i, j] + matrix2[i, j]; //Суммируем значения элементов первых двух матриц
        Console.Write($"{matrixSumm[i, j],4}");
    }
    Console.WriteLine();
}

