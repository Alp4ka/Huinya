using System;
using System.Collections.Generic;
using System.Linq;

namespace MatrixCalc
{
    public class Matrix
    {
        private List<List<double>> matrix;
        private Dictionary<string, int> size;
        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public Matrix()
        {
            size.Add("width", 0);
            size.Add("height", 0);
            matrix = new List<List<double>>(0);
        }
        /// <summary>
        /// Конструктор, копирующий Matrix matrix в себя.
        /// </summary>
        /// <param name="matrix"> Матрица, которую нужно скопировать. </param>
        public Matrix(Matrix matrix)
        {
            if (CheckIfMatrix(matrix.ToTwoDimArray()))
            {
                size = GetSizeOf(matrix.ToTwoDimArray());
                this.matrix = new List<List<double>>();
                for (int i = 0; i < size["height"]; ++i)
                {
                    this.matrix.Add(new List<double>());
                    for (int j = 0; j < size["width"]; ++j)
                    {
                        this.matrix[i].Add(matrix.ToTwoDimArray()[i][j]);
                    }
                }
            }
            else
            {
                throw new Exception("Не является матрицей.");
            }
        }
        /// <summary>
        /// Конструктор, копирующий double[][] arraToConvert в Matrix.matrix;
        /// </summary>
        /// <param name="matrix"> Матрица, которую нужно скопировать. </param>
        public Matrix(double[][] arrayToConvert)
        {
            if (CheckIfMatrix(arrayToConvert))
            {
                size = GetSizeOf(arrayToConvert);
                matrix = new List<List<double>>();
                for (int i = 0; i < size["height"]; ++i)
                {
                    matrix.Add(new List<double>());
                    for (int j = 0; j < size["width"]; ++j)
                    {
                        matrix[i].Add(arrayToConvert[i][j]);
                    }
                }
            }
            else
            {
                throw new Exception("Не является матрицей.");
            }
        }
        /// <summary>
        /// Вывод матрицы с \t.
        /// </summary>
        public void Show()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(ToString());
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        /// <summary>
        /// Перегруженный operator + для сложения матриц.
        /// </summary>
        /// <param name="a"> Матрица, стоящая слева от +. </param>
        /// <param name="b"> Матрица, стоящая справа от +. </param>
        /// <returns> Matrix - результат сложения B и A. </returns>
        public static Matrix operator +(Matrix a, Matrix b)
        {
            if (a.Size["width"] == b.Size["width"] && a.Size["height"] == b.Size["height"])
            {
                double[][] matrixC = a.ToTwoDimArray();
                double[][] matrixB = b.ToTwoDimArray();
                for (int i = 0; i < a.Size["height"]; ++i)
                {
                    for (int j = 0; j < a.Size["width"]; ++j)
                    {
                        matrixC[i][j] += matrixB[i][j];
                    }
                }
                return new Matrix(matrixC);
            }
            else
            {
                throw new Exception("Введенные матрицы разного размера.");
            }
        }
        /// <summary>
        /// Перегруженный operator - для вычитания матриц.
        /// </summary>
        /// <param name="a"> Матрица, стоящая слева от -. </param>
        /// <param name="b"> Матрица, стоящая справа от -. </param>
        /// <returns> Matrix - результат вычитания B из A. </returns>
        public static Matrix operator -(Matrix a, Matrix b)
        {
            if (a.Size["width"] == b.Size["width"] && a.Size["height"] == b.Size["height"])
            {
                return a + (-1 * b);
            }
            else
            {
                throw new Exception("Введенные матрицы разного размера.");
            }
        }
        /// <summary>
        /// Перегруженный operator * для умножения матриц.
        /// </summary>
        /// <param name="a"> Матрица, стоящая слева от *. </param>
        /// <param name="b"> Матрица, стоящая справа от *. </param>
        /// <returns> Matrix - результат умножения A на B. </returns>
        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a.Size["width"] == b.Size["height"])
            {
                double[][] matrixA = a.ToTwoDimArray();
                double[][] matrixB = b.ToTwoDimArray();
                double[][] matrixC = CreateNullArrayMatrix(a.Size["height"], b.Size["width"]);
                for (int i = 0; i < a.Size["height"]; ++i)
                {
                    for (int j = 0; j < b.Size["width"]; ++j)
                    {
                        matrixC[i][j] = 0;
                        for (int k = 0; k < a.Size["width"]; ++k)
                        {
                            matrixC[i][j] += matrixA[i][k] * matrixB[k][j];
                        }
                    }
                }
                return new Matrix(matrixC);
            }
            else
            {
                throw new Exception("Ширина матрицы А должна равняться высоте матрицы Б.");
            }
        }
        /// <summary>
        /// Перегруженный operator * для умножения числа на матрицу.
        /// </summary>
        /// <param name="num"> Коэффициент при матрице. </param>
        /// <param name="a"> Матрица. </param>
        /// <returns> Matrix - результат умножения числа на А. </returns>
        public static Matrix operator *(double num, Matrix a)
        {
            try
            {
                double[][] matrixC = a.ToTwoDimArray();
                for (int i = 0; i < a.Size["height"]; ++i)
                {
                    for (int j = 0; j < a.Size["width"]; ++j)
                    {
                        matrixC[i][j] *= num;
                    }
                }
                return new Matrix(matrixC);
            }
            catch
            {
                throw new Exception("Неверный размер матрицы.");
            }
        }
        /// <summary>
        /// Получить след матрицы.
        /// </summary>
        /// <returns> double - след матрицы. </returns>
        public double Trace()
        {
            try
            {
                double summ = 0;
                for (int i = 0; i < Math.Min(Size["height"], Size["width"]); ++i)
                {
                    summ += matrix[i][i];
                }
                return summ;
            }
            catch
            {
                throw new Exception("Неверный размер матрицы.");
            }
        }
        public Matrix Transpose()
        {
            double[][] matrixA = ToTwoDimArray();
            double[][] matrixC = new double[Size["width"]][];
            for (int i = 0; i < Size["width"]; ++i)
            {
                matrixC[i] = new double[Size["height"]];
                for (int j = 0; j < Size["height"]; j++)
                {
                    matrixC[i][j] = matrixA[j][i];
                }
            }
            return new Matrix(matrixC);
        }
        /// <summary>
        /// Перегруженная ToString(), чтобы можно было представить матрицу как строку.
        /// </summary>
        /// <returns> string - строковое отображение матрицы. </returns>
        public override string ToString()
        {
            try
            {
                string lineToReturn = "";
                foreach (List<double> line in matrix)
                {
                    lineToReturn += String.Join('\t', line) + "\n";
                }
                return lineToReturn;
            }
            catch
            {
                throw new Exception("Какая-то странная у Вас матрица.");
            }
        }
        /// <summary>
        /// Вытягивает matrix из Matrix.
        /// </summary>
        /// <returns> double[][] - matrix. </returns>
        public double[][] ToTwoDimArray()
        {
            try
            {
                double[][] arrayMatrix = new double[size["height"]][];
                for (int i = 0; i < size["height"]; ++i)
                {
                    arrayMatrix[i] = matrix[i].ToArray();
                }
                return arrayMatrix;
            }
            catch
            {
                throw new Exception("Неверный размер матрицы.");
            }
        }
        /// <summary>
        /// Свойство для получения размера Matrix.
        /// </summary>
        public Dictionary<string, int> Size
        {
            get { return size; }
        }
        /// <summary>
        /// Создает нулевую матрицу height x width.
        /// </summary>
        /// <param name="height"> Высота требуемой матрицы. </param>
        /// <param name="width"> Ширина требуемой матрицы.</param>
        /// <returns></returns>
        public static double[][] CreateNullArrayMatrix(int height, int width)
        {
            if (height <= 0 || width <= 0)
            {
                throw new Exception("Неверные размеры матрицы.");
            }
            else
            {
                double[][] result = new double[height][];
                for (int i = 0; i < height; ++i)
                {
                    result[i] = new double[width];
                }
                return result;
            }
        }
        /// <summary>
        /// Причесывает ужасные дроби Matrix.
        /// </summary>
        private void Normalize()
        {
            for (int i = 0; i < Size["height"]; ++i)
            {
                for (int j = 0; j < Size["width"]; ++j)
                {
                    matrix[i][j] = Math.Round(matrix[i][j], 2);
                }
            }
        }
        /// <summary>
        /// Причесывает ужасные дроби в matrixA.
        /// </summary>
        /// <param name="matrixA"> Матрица для причесывания. </param>
        private void Normalize(ref double[][] matrixA)
        {
            Dictionary<string, int> size_matrixA = GetSizeOf(matrixA);
            for (int i = 0; i < size_matrixA["height"]; ++i)
            {
                for (int j = 0; j < size_matrixA["width"]; ++j)
                {
                    matrixA[i][j] = Math.Round(matrixA[i][j], 2);
                }
            }
        }
        /// <summary>
        /// Решает СЛАУ методом Гаусса.
        /// </summary>
        /// <param name="slau"> СЛАУ, заданная в виде Matrix. </param>
        /// <returns> double[] - массив ответов x0, x1...</returns>
        public static double[] GaussMethod(Matrix slau)
        {
            double[][] matrix = slau.ToTwoDimArray();
            double temp;
            int k;
            double[] x = new double[slau.Size["width"]];
            for (int i = 0; i < slau.Size["height"]; i++)
            {
                temp = matrix[i][i];
                for (int j = slau.Size["height"]; j >= i; j--)
                {
                    matrix[i][j] /= temp;
                }
                for (int j = i + 1; j < slau.Size["height"]; j++)
                {
                    temp = matrix[j][i];
                    for (k = slau.Size["height"]; k >= i; k--)
                    {
                        matrix[j][k] -= (temp * matrix[i][k]);
                    }
                }
            }
            x[slau.Size["height"] - 1] = matrix[slau.Size["height"] - 1][slau.Size["height"]];
            for (int i = slau.Size["height"] - 2; i >= 0; i--)
            {
                x[i] = matrix[i][slau.Size["height"]];
                for (int j = i + 1; j < slau.Size["height"]; j++)
                {
                    x[i] -= matrix[i][j] * x[j];
                }
            }
            Console.WriteLine(String.Join("\t", x[0..(x.Length - 1)].Select((x, y) => $"x{y}")));
            Console.WriteLine(String.Join("\t", x[0..(x.Length - 1)].Select(x => Math.Round(x, 2))));
            return x;
        }
        /// <summary>
        /// Решает СЛАУ текущей матрицы методом Гаусса.
        /// </summary>
        /// <returns> double[] - массив ответов x0, x1...</returns>
        public double[] GaussMethod()
        {
            double[][] matrix = ToTwoDimArray();
            double temp;
            int k;
            double[] x = new double[Size["width"]];

            for (int i = 0; i < Size["height"]; i++)
            {
                temp = matrix[i][i];
                for (int j = Size["height"]; j >= i; j--)
                {
                    matrix[i][j] /= temp;
                }
                for (int j = i + 1; j < Size["height"]; j++)
                {
                    temp = matrix[j][i];
                    for (k = Size["height"]; k >= i; k--)
                    {
                        matrix[j][k] -= (temp * matrix[i][k]);
                    }
                }
            }
            x[Size["height"] - 1] = matrix[Size["height"] - 1][Size["height"]];
            for (int i = Size["height"] - 2; i >= 0; i--)
            {
                x[i] = matrix[i][Size["height"]];
                for (int j = i + 1; j < Size["height"]; j++)
                {
                    x[i] -= matrix[i][j] * x[j];
                }
            }
            Console.WriteLine(String.Join("\t", x[0..(x.Length - 1)].Select((x, y) => $"x{y}")));
            Console.WriteLine(String.Join("\t", x[0..(x.Length - 1)].Select(x => Math.Round(x, 2))));
            return x;
        }
        /// <summary>
        /// Поиск детерминанта.
        /// </summary>
        /// <returns> double - детерминант текущей Matrix. </returns>
        public double FindDeterminator()
        {
            if (Size["height"] == Size["width"])
            {
                double determinator = 1;
                double[][] matrixA = Transpose().ToTwoDimArray();
                double[][] rows = new double[1][];
                rows[0] = new double[Size["height"]];
                for (int i = 0; i < Size["height"]; ++i)
                {
                    int k = i;
                    for (int j = i + 1; j < Size["height"]; ++j)
                    {
                        if (Math.Abs(matrixA[j][i]) > Math.Abs(matrixA[k][i]))
                        {
                            k = j;
                        }
                    }
                    if (Math.Abs(matrixA[k][i]) <= 0.01)
                    {
                        determinator = 0;
                        break;
                    }
                    rows[0] = matrixA[i];
                    matrixA[i] = matrixA[k];
                    matrixA[k] = rows[0];
                    if (i != k)
                    {
                        determinator = -determinator;
                    }
                    determinator *= matrixA[i][i];
                    for (int j = i + 1; j < Size["height"]; ++j)
                    {
                        matrixA[i][j] /= matrixA[i][i];
                    }
                    for (int j = 0; j < Size["height"]; ++j)
                    {
                        if ((j != i) && (Math.Abs(matrixA[j][i]) >= 0.01))
                        {
                            for (k = i + 1; k < Size["height"]; ++k)
                            {
                                matrixA[j][k] -= matrixA[i][k] * matrixA[j][i];

                            }
                        }
                    }
                }
                return Math.Round(determinator, 2);
            }
            else
            {
                throw new Exception("Матрица должна быть квадратной.");
            }

        }
        /// <summary>
        /// Создает единичную матрицу nxn.
        /// </summary>
        /// <param name="n"> Размерность матрицы. </param>
        /// <returns> Matrix в формате единичной матрицы. </returns>
        public static Matrix CreateElementaryMatrix(int n)
        {
            double[][] nullArrayMatrix = CreateNullArrayMatrix(n, n);
            for (int i = 0; i < n; ++i)
            {
                nullArrayMatrix[i][i] = 1;
            }
            Matrix temp = new Matrix(nullArrayMatrix);
            return temp;

        }
        /// <summary>
        /// Проверяет, если double[][] является матрицей.
        /// </summary>
        /// <param name="inputArray"> Зубчатый массив. </param>
        /// <returns> True, если введенный зубчатый массив - матрица, false - если нет. </returns>
        public static bool CheckIfMatrix(double[][] inputArray)
        {
            try
            {
                int commonLength = inputArray[0].Length;
                foreach (double[] line in inputArray)
                {
                    if (line.Length != commonLength)
                    {
                        return false;
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }

        }
        /// <summary>
        /// Узнать размерность двумерного массива.
        /// </summary>
        /// <param name="inputArray"> Зубчатый массив. </param>
        /// <returns> Dictinoray. "height" -> высота, "width" -> ширина. </returns>
        public static Dictionary<string, int> GetSizeOf(double[][] inputArray)
        {
            if (CheckIfMatrix(inputArray))
            {
                Dictionary<string, int> result = new Dictionary<string, int>();
                int cnt = 0;
                foreach (double[] line in inputArray)
                {
                    cnt++;
                }
                result.Add("width", inputArray[0].Length);
                result.Add("height", cnt);
                return result;
            }
            else
            {
                throw new Exception("Не является матрицей.");
            }
        }
        /// <summary>
        /// Генерирует рандомную матрицу heightxwidth.
        /// </summary>
        /// <param name="height"> Требуемая высота. </param>
        /// <param name="width"> Требуемая ширина. </param>
        /// <param name="leftBorder"> Граница рандома слева. </param>
        /// <param name="rightBoder"> Граница рандома справа. </param>
        /// <returns> Matrix с рандомными значениями в ячейках. </returns>
        public static Matrix GenerateRandomMatrix(int height, int width, int leftBorder = 0, int rightBoder = 50)
        {
            Random rnd = new Random();
            double[][] matrixArray = new double[height][];
            for (int i = 0; i < height; ++i)
            {
                matrixArray[i] = new double[width];
                for (int j = 0; j < width; ++j)
                {
                    matrixArray[i][j] = rnd.Next(leftBorder, rightBoder);
                }
            }
            Console.WriteLine("Для проверки в вольфраме: ");
            GetWolframAdaptedForm(matrixArray);
            return new Matrix(matrixArray);
        }
        /// <summary>
        /// Возвращает двумерный массив в приемлемой для вольфрама форме.
        /// </summary>
        /// <param name="matrixToForm"> Зубчатый массив. </param>
        /// <returns> Строку формата {{a, b},{c, d}}. </returns>
        public static string GetWolframAdaptedForm(double[][] matrixToForm)
        {
            string lineToReturn = "{";
            foreach (double[] line in matrixToForm)
            {
                lineToReturn += "{" + String.Join(",", (String.Join(' ', line).Replace(",", ".")).Split()) + "},";
            }
            lineToReturn = lineToReturn[..(lineToReturn.Length - 1)] + "}";
            Console.WriteLine(lineToReturn);
            return lineToReturn;
        }
    }
}
