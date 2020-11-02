using System;
using MatrixCalc.Reader;

namespace MatrixCalc
{
    class Program
    {
        /// <summary>
        /// Вызывает Matrix.operator *(double, Matrix) для нужных матриц.
        /// </summary>
        private static void SolveByGauss()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Найти определитель");
            Console.ForegroundColor = ConsoleColor.Gray;
            Matrix a;
            switch (ChoiceOfInput())
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("Введите полный путь до текстового файла: ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    string path = Console.ReadLine();
                    a = MReader.FileFormatInput(path);
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("Начинайте вводить матрицу A, разделяя элементы пробелами, а строки переносом строки: ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    a = MReader.MultilineFormatInput();
                    break;
                default:
                    return;
            }
            a.GaussMethod();
        }
        private static void FindDet()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Найти определитель");
            Console.ForegroundColor = ConsoleColor.Gray;
            Matrix a;
            switch (ChoiceOfInput())
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("Введите полный путь до текстового файла: ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    string path = Console.ReadLine();
                    a = MReader.FileFormatInput(path);
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("Начинайте вводить матрицу A, разделяя элементы пробелами, а строки переносом строки: ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    a = MReader.MultilineFormatInput();
                    break;
                default:
                    return;
            }
            Console.WriteLine(a.FindDeterminator());
        }
        /// <summary>
        /// Вызывает Matrix.operator *(double, Matrix) для нужных матриц.
        /// </summary>
        private static void MultipleNumToA()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Число * A");
            Console.ForegroundColor = ConsoleColor.Gray;
            Matrix a;
            double k;
            switch (ChoiceOfInput())
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("Введите полный путь до текстового файла: ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    string path = Console.ReadLine();
                    a = MReader.FileFormatInput(path);
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("Введите множитель k: ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    if (!double.TryParse(Console.ReadLine(), out k))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Чиселко не парсится:c");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        return;
                    }
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("Начинайте вводить матрицу A, разделяя элементы пробелами, а строки переносом строки: ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    a = MReader.MultilineFormatInput();
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("Введите множитель k: ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    if (!double.TryParse(Console.ReadLine(), out k))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Чиселко не парсится:c");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        return;
                    }
                    break;
                default:
                    return;
            }
            (k * a).Show();
        }
        /// <summary>
        /// Вызывает Matrix.operator *(Matrix, Matrix) для нужной матрицы.
        /// </summary>
        private static void MultipleAToB()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("A*B");
            Console.ForegroundColor = ConsoleColor.Gray;
            Matrix a, b;
            switch (ChoiceOfInput())
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("Введите полный путь до текстового файла с матрицей A: ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    string path = Console.ReadLine();
                    a = MReader.FileFormatInput(path);
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("Введите полный путь до текстового файла с матрицей B: ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    path = Console.ReadLine();
                    b = MReader.FileFormatInput(path);
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("Начинайте вводить матрицу A, разделяя элементы пробелами, а строки переносом строки: ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    a = MReader.MultilineFormatInput();
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("Начинайте вводить матрицу B, разделяя элементы пробелами, а строки переносом строки: ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    b = MReader.MultilineFormatInput();
                    break;
                default:
                    return;
            }
            (a * b).Show();
        }
        /// <summary>
        /// Вызывает Matrix.operator -(Matrix, Matrix) для нужных матриц.
        /// </summary>
        private static void MatrixDifference()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("A-B");
            Console.ForegroundColor = ConsoleColor.Gray;
            Matrix a, b;
            switch (ChoiceOfInput())
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("Введите полный путь до текстового файла с матрицей A: ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    string path = Console.ReadLine();
                    a = MReader.FileFormatInput(path);
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("Введите полный путь до текстового файла с матрицей B: ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    path = Console.ReadLine();
                    b = MReader.FileFormatInput(path);
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("Начинайте вводить матрицу A, разделяя элементы пробелами, а строки переносом строки: ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    a = MReader.MultilineFormatInput();
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("Начинайте вводить матрицу B, разделяя элементы пробелами, а строки переносом строки: ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    b = MReader.MultilineFormatInput();
                    break;
                default:
                    return;
            }
            (a - b).Show();
        }
        /// <summary>
        /// Вызывает Matrix.operator +(Matrix, Matrix) для нужных матриц.
        /// </summary>
        private static void MatrixSum()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("A+B");
            Console.ForegroundColor = ConsoleColor.Gray;
            Matrix a, b;
            switch (ChoiceOfInput())
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("Введите полный путь до текстового файла с матрицей A: ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    string path = Console.ReadLine();
                    a = MReader.FileFormatInput(path);
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("Введите полный путь до текстового файла с матрицей B: ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    path = Console.ReadLine();
                    b = MReader.FileFormatInput(path);
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("Начинайте вводить матрицу A, разделяя элементы пробелами, а строки переносом строки: ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    a = MReader.MultilineFormatInput();
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("Начинайте вводить матрицу B, разделяя элементы пробелами, а строки переносом строки: ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    b = MReader.MultilineFormatInput();
                    break;
                default:
                    return;
            }
            (a + b).Show();
        }
        /// <summary>
        /// Вызывает Matrix.Trace() для нужной матрицы.
        /// </summary>
        private static void Trace()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("След");
            Console.ForegroundColor = ConsoleColor.Gray;
            Matrix a;
            switch (ChoiceOfInput())
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("Введите полный путь до текстового файла: ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    string path = Console.ReadLine();
                    a = MReader.FileFormatInput(path);
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("Начинайте вводить матрицу A, разделяя элементы пробелами, а строки переносом строки: ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    a = MReader.MultilineFormatInput();
                    break;
                default:
                    return;
            }
            Console.WriteLine(a.Trace());
        }
        /// <summary>
        /// Вызывает Matrix.Transpose() для нужной матрицы.
        /// </summary>
        private static void Transpose()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Транспонирование");
            Console.ForegroundColor = ConsoleColor.Gray;
            Matrix a;
            switch (ChoiceOfInput())
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("Введите полный путь до текстового файла: ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    string path = Console.ReadLine();
                    a = MReader.FileFormatInput(path);
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("Начинайте вводить матрицу A, разделяя элементы пробелами, а строки переносом строки: ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    a = MReader.MultilineFormatInput();
                    break;
                default:
                    return;
            }
            a.Transpose().Show();
        }
        /// <summary>
        /// Смотрит, какой формат ввода выбрал пользователь.
        /// </summary>
        /// <returns></returns>
        private static int ChoiceOfInput()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Выбери, каким способом ты введешь матрицу:");
            Console.WriteLine("1) Через указание полного пути к текстовому файлу с матрицей.");
            Console.WriteLine("2) Через консоль.");
            Console.ForegroundColor = ConsoleColor.Gray;
            switch (Console.ReadKey().KeyChar)
            {
                default:
                    Console.SetCursorPosition(0, Console.CursorTop);
                    return -1;
                case '1':
                    Console.SetCursorPosition(0, Console.CursorTop);
                    return 1;
                case '2':
                    Console.SetCursorPosition(0, Console.CursorTop);
                    return 2;
            }
        }
        static void Main(string[] args)
        {

            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Привет! Это калькулятор матриц. Перед тобой есть следующий функционал:");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(">>> Кстати, если не знаешь, что хочешь ввести, можешь воспользоваться рандомом, выбрав внутри " +
                    "каждой функции ввод через консоль и написав random *height* *width*");
                Console.WriteLine(">>> Таким же образом можешь задать единичную размером nxn, написав elem *n*.");
                Console.WriteLine(">>> А еще здесь есть ограничение на размерность матрицы. nxn, где n >10 у тебя посчитать не получится.");
                Console.WriteLine(">>> А еще в папке Program.cs лежат три текстовых файла для теста.");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("1) Найти след матрицы.");
                Console.WriteLine("2) Транспонировать матрицу.");
                Console.WriteLine("3) Найти сумму двух матриц.");
                Console.WriteLine("4) Найти разность двух матриц.");
                Console.WriteLine("5) Найти произведение двух матриц.");
                Console.WriteLine("6) Умножить число на матрицу.");
                Console.WriteLine("7) Найти определитель матрицы.");
                Console.WriteLine("8) Решить СЛАУ, заданное в виде расширенной матрицы.");
                Console.WriteLine("9) Выйти из программы.");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Чтобы выбрать нужный пункт, нажми на соответсвующий ей номер на своей клавиатуре.");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                char key = Console.ReadKey().KeyChar;
                try
                {
                    switch (key)
                    {
                        case '1':
                            Trace();
                            break;
                        case '2':
                            Transpose();
                            break;
                        case '3':
                            MatrixSum();
                            break;
                        case '4':
                            MatrixDifference();
                            break;
                        case '5':
                            MultipleAToB();
                            break;
                        case '6':
                            MultipleNumToA();
                            break;
                        case '7':
                            FindDet();
                            break;
                        case '8':
                            SolveByGauss();
                            break;
                        case '9':
                            Environment.Exit(0);
                            break;
                        default:
                            continue;
                    }
                    Console.WriteLine("Жмякни Enter");
                    Console.Read();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Read();
                }
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
    }
}
