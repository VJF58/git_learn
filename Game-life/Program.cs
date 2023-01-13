public class LifeSimulation
{
    private int _heigth;
    private int _width;
    private bool[,] cells;

    /// <summary>
    /// Создаем новую игру
    /// </summary>
    /// <param name="Heigth">Высота поля.</param>
    /// <param name="Width">Ширина поля.</param>

    public LifeSimulation(int Heigth, int Width)
    {
        _heigth = Heigth;
        _width = Width;
        cells = new bool[Heigth, Width];
        GenerateField();
    }

    /// <summary>
    /// Перейти к следующему поколению и вывести результат на консоль.
    /// </summary>
    public void DrawAndGrow()
    {
        DrawGame();
        Grow();
    }

    /// <summary>
    /// Двигаем состояние на одно вперед, по установленным правилам
    /// </summary>

    private void Grow()
    {
        Random rand = new Random();

        for (int i = 0; i < _heigth; i++)
        {
            for (int j = 0; j < _width; j++)
            {

                if (cells[i, j]) // Клетка заражает две или одну соседнюю клетку или сохраняет энергию и не умирает
                {
                    cells[i, j] = false; // Вот и все условие(сделано через костыли, в силу имеющихся знаний)
                    int ii = rand.Next(-1, 2); // Концепт вируса, который распространяется по чашке петри
                    int jj = rand.Next(-1, 2);

                    if ((i + ii) < _heigth & (i + ii) > 0) 
                        cells[i + ii, j] = true;
                    else 
                        cells[i - ii, j] = true;

                    if ((j + jj) < _width & (j + jj) > 0) 
                        cells[i, j + jj] = true;
                    else 
                        cells[i, j - jj] = true;
                }
            }
        }
    }

    /// <summary>
    /// Смотрим сколько живых соседий вокруг клетки.
    /// </summary>
    /// <param name="x">X-координата клетки.</param>
    /// <param name="y">Y-координата клетки.</param>
    /// <returns>Число живых клеток.</returns>

    private int GetNeighbors(int x, int y)
    {
        int NumOfAliveNeighbors = 0;

        for (int i = x - 1; i < x + 2; i++)
        {
            for (int j = y - 1; j < y + 2; j++)
            {
                if (!((i < 0 || j < 0) || (i >= _heigth || j >= _width)))
                {
                    if (cells[i, j] == true) NumOfAliveNeighbors++;
                }
            }
        }
        return NumOfAliveNeighbors;
    }

    /// <summary>
    /// Нарисовать Игру в консоле
    /// </summary>

    private void DrawGame()
    {
        for (int i = 0; i < _heigth; i++)
        {
            for (int j = 0; j < _width; j++)
            {
                Console.Write(cells[i, j] ? "x" : " ");
                if (j == _width - 1) Console.WriteLine("\r");
            }
        }
        Console.SetCursorPosition(0, Console.WindowTop);
    }

    /// <summary>
    /// Инициализируем случайными значениями
    /// </summary>

    private void GenerateField()
    {
        Random generator = new Random();
        int number;
        for (int i = 8; i < 12; i++)
        {
            for (int j = 23; j < 27; j++)
            {
                number = generator.Next(2);
                cells[i, j] = ((number == 0) ? false : true);
            }
        }
    }
}

internal class Program
{

    // Ограничения игры
    private const int Heigth = 30; // Я создал для себя огрмное поле и увеличил число итераций
    private const int Width = 100;
    private const uint MaxRuns = 30000;

    private static void Main(string[] args)
    {
        int runs = 0;
        LifeSimulation sim = new LifeSimulation(Heigth, Width);

        while (runs++ < MaxRuns)
        {
            sim.DrawAndGrow();

            // Дадим пользователю шанс увидеть, что происходит, немного ждем
            System.Threading.Thread.Sleep(100);
        }
    }
}
