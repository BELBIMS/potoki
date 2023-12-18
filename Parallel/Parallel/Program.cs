internal class Program
{
    public static double[] a;
    public static int th;
    private static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        th = int.Parse(Console.ReadLine());
        Random rnd = new Random();
        a = new double[N];
        for (int i = 0; i < a.Length; i++)
        {
            a[i] = rnd.Next(1, 100);
        }
        DateTime dt1, dt2;
        dt1 = DateTime.Now;
        Parallel.For(0, th, i =>
        {
            Run(th, i);
        });


        dt2 = DateTime.Now;
        TimeSpan ts = dt2 - dt1;
        Console.WriteLine("Total time: {0}", ts.TotalMilliseconds);
    }



    public static void Run(int th, int nember)
    {
        int x = 0;
        int y = 0;
        if (nember == 1)
        {
            x = 0;
            y = (a.Length - 1) / th;
        }
        if (nember != 1 && nember != th)
        {
            x = (a.Length - 1) / th * nember + 1;
            y = (a.Length - 1) / th * (nember + 1);

        }
        if (nember == th)
        {
            x = (a.Length - 1) / th * (th - 1) + 1;
            y = a.Length - 1;
        }
        while (x <= y)
        {
            a[x] = Math.Pow(a[x], 1.789);
            x++;
            for (int i = 0; i < 100; i++)
            {
                int f = 0;
                f += i;
            }
        }

    }
}