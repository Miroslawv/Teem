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



Student st = new Student();
Console.WriteLine(st.ToShortString());
Console.WriteLine(st[Education.Specialist]);
Console.WriteLine(st[Education.Bachelor]);
Console.WriteLine(st[Education.SecondEducation]);
st.Pers = new Person("Ажлорф", "Ашпеп", new DateTime(2008, 8, 14));
st.Educ = Education.Bachelor;
st.NumGroup = 666;
st.Exams = new Exam[]
{
    new Exam("№1", 5, new DateTime(2025, 12, 1)),
    new Exam("№1", 6, new DateTime(2026, 1, 1))
};
Console.WriteLine(st);
st.AddExam(new Exam("#3", 7, new DateTime(2025, 2, 1)), new Exam("#4", 8, new DateTime(2025, 3, 1)), new Exam("#5", 10, new DateTime(2025, 4, 1)));
Console.WriteLine(st);

nrow = 0;
ncolumn = 0;
do { nrow = setIntValueByUser("Введите количество строк в массивах: "); } while (nrow < 1);
do { nrow = setIntValueByUser("Введите столбцов строк в массивах: "); } while (ncolumn < 1);

Exam[] arr1 = new Exam[nrow * ncolumn];
Exam[,] arr2 = new Exam[nrow, ncolumn];
Exam[][] arr3 = new Exam[nrow][];
for(int i = 0; i < nrow; i++)
{
    arr3[i] = new Exam[ncolumn];
}

double s1 = Environment.TickCount;
for (int i = 0; i < nrow * ncolumn; i++)
{
    arr1[i] = new Exam();
}
double e1 = Environment.TickCount;

double s2 = Environment.TickCount;
for (int i = 0; i < nrow; i++)
{
    for (int j = 0; j < ncolumn; j++)
    {
        arr2[i, j] = new Exam();
    }
}
double e2 = Environment.TickCount;

double s3 = Environment.TickCount;
for (int i = 0; i < nrow; i++)
{
    for (int j = 0; j < ncolumn; j++)
    {
        arr3[i][j] = new Exam();
    }
}
double e3 = Environment.TickCount;

Console.WriteLine($"Время обработки одномерного массива: {e1 - s1}");
Console.WriteLine($"Время обработки двумерного массива: {e2 - s2}");
Console.WriteLine($"Время обработки ступенчатого массива: {e3 - s3}");

static int setIntValueByUser(string line = "")
{
    try
    {
        Console.Write(line);
        int n = Convert.ToInt32(Console.ReadLine());
        return n;
    }
    catch (FormatException)
    {
        Console.WriteLine("Ошибка. Введено некорректное значение. Необходимо число. Будет возвращён 0.");
    }
    catch (OverflowException)
    {
        Console.WriteLine("Ошибка. Введено некоректное значение. Нужно меньшее число. Будет возвращён 0.");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.ToString());
    }
    return 0;
}
