Console.Write("Введите количество строк: ");
int strings = int.Parse(Console.ReadLine());

Console.Write("Введите количество столбцов: ");
int columns = int.Parse(Console.ReadLine());

int[,] matrix= new int[strings, columns]; //Инициализируем матрицу с заданным количеством строк

Random rand = new Random(); 
int summ = 0;


for (int i = 0; i < strings; i++)
{
    for (int j = 0; j < columns; j++)
    {
        matrix[i, j] = rand.Next(0, 100);
        Console.Write($"{matrix[i, j], 3}");
        summ += matrix[i, j]; //Суммируем каждый элемент
    }
    Console.WriteLine();    
}

Console.WriteLine($"Сумма всех элементов = {summ}");