// Класс программы для вычисления суммы квадратов и нормы вектора
class Program
{
    static void Main(string[] args)
    {
        var vector = new double[] { 2, 3, 4, 5, 6 }; // Вектор

        var taskCount = 2; // Число параллельных задач

        var sum = CalculateSum(vector, taskCount); // Параллельный подсчет суммы

        var norm = Math.Sqrt(sum); // Вычисление нормы вектора
        Console.WriteLine("Сумма квадратов: " + sum + "; Норма вектора: " + norm); // Вывод результатов

        DateTime dt1, dt2;
        dt1 = DateTime.Now;
        // Вызов вычислительной процедуры
        dt2 = DateTime.Now;
        TimeSpan ts = dt2 - dt1;
        Console.WriteLine("Total time: {0}", ts.TotalMilliseconds); // Вывод времени выполнения
    }

    
    // Метод для вычисления суммы квадратов с использованием параллельных задач
    private static double CalculateSum(double[] vector, int taskCount)
    {
        var len = vector.Length;

        // Не может быть задач больше числа элементов вектора
        if (taskCount > len)
            throw new ArgumentException();

        var step = (len + 1) / taskCount; // Интервал для суммы
        var tasks = new Task<double>[taskCount];
        
        // Запуск параллельных задач для подсчета суммы
        for (var i = 0; i < taskCount; i++)
        {
            tasks[i] = Task<double>.Factory.StartNew((obj) => Sum(vector, (int)obj * step, ((int)obj + 1) * step - 1), i);
        }
        Task.WaitAll(tasks); // Ожидание завершения всех задач
        var sum = tasks.Select(x => x.Result).Sum(); // Вычисление общей суммы
        return sum;
    }



    // Метод для подсчета суммы квадратов элементов вектора
    static double Sum(IEnumerable<double> vector, int index1, int index2)
    {
        index2 = index2 >= vector.Count() ? vector.Count() : index2;
        return vector.Skip(index1).Take(index2 - index1 + 1).Select(x => x * x).Sum();
    }
}
