using ConsoleApp1;

Console.WriteLine("Введите размер массивов через запятую и пробел: ");
string[] s = Console.ReadLine().Split(", ");
int nrow = Convert.ToInt32(s[0]);
int ncolumn = Convert.ToInt32(s[1]);

Person[] array = new Person[nrow * ncolumn];
Person[,] array2 = new Person[nrow, ncolumn];
Person[][] array3 = new Person[nrow][];
for (int i = 0; i < nrow; i++)
{
    array3[i] = new Person[ncolumn];
}

double start1 = Environment.TickCount;
for (int i = 0; i < nrow * ncolumn; i++)
{
    array[i] = new Person();
}
double end1 = Environment.TickCount;

double start2 = Environment.TickCount;
for (int i = 0; i < nrow; i++)
{
    for (int j = 0; j < ncolumn; j++)
    {
        array2[i, j] = new Person();
    }
}
double end2 = Environment.TickCount;

double start3 = Environment.TickCount;
for (int i = 0; i < nrow; i++)
{
    for (int j = 0; j < ncolumn; j++)
    {
        array3[i][j] = new Person();
    }
}
double end3 = Environment.TickCount;

Console.WriteLine($"Время обработки одномерного массива: {end1 - start1}");
Console.WriteLine($"Время обработки двумерного массива: {end2 - start2}");
Console.WriteLine($"Время обработки ступенчатого массива: {end3 - start3}");
