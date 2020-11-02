using System;
using System.Linq;
using System.IO;

namespace MatrixCalc.Reader
{
    /// <summary>
    /// Класс MReader осуществляет считывание матрицы с консоли/файла.
    /// </summary>
    public static class MReader
    {
        /// <summary>
        /// Осуществляет считывание матрицы из файла.
        /// </summary>
        /// <param name="path"> Параметр в виде string, хранящий путь до файла. </param>
        /// <returns> Объект типа Matrix, содержащий в себе считанные значения. </returns>
        public static Matrix FileFormatInput(string path)
        {
            string realPath = Path.Combine(path);
            string[] input = File.ReadAllLines(realPath);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Reading {realPath}");
            Console.ForegroundColor = ConsoleColor.Gray;
            double[][] lines = new double[0][];
            int index = 0;
            try
            {
                while (true)
                {
                    if (index > 9 || index == input.Length)
                    {
                        break;
                    }
                    string curLine = input[index].Trim();
                    if (curLine == "")
                    {
                        break;
                    }
                    else
                    {
                        Array.Resize(ref lines, index + 1);
                        lines[index] = curLine.Split().Select(x => double.Parse(x)).ToArray();
                        index++;

                    }
                }
                return new Matrix(lines);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.Gray;
                return null;
            }
        }
        /// <summary>
        /// Осуществляет считывание из консоли.
        /// </summary>
        /// <returns> Объект типа Matrix, содержащий в себе считанные значения. </returns>
        public static Matrix MultilineFormatInput()
        {
            double[][] lines = new double[0][];
            int index = 0;
            try
            {
                while (true)
                {
                    if (index > 9)
                    {
                        break;
                    }
                    string input = Console.ReadLine().Trim();
                    if (input == "")
                    {
                        break;
                    }
                    else
                    {
                        string[] check = input.Split();
                        if (check[0] == "random" && Int32.Parse(check[1]) > 0 && Int32.Parse(check[2]) > 0)
                        {
                            Matrix temp = Matrix.GenerateRandomMatrix(Int32.Parse(check[1]), Int32.Parse(check[2]));
                            temp.Show();
                            return temp;
                        }
                        else if (check[0] == "elem" && Int32.Parse(check[1]) > 0)
                        {
                            Matrix temp = Matrix.CreateElementaryMatrix(Int32.Parse(check[1]));
                            temp.Show();
                            return temp;
                        }
                        Array.Resize(ref lines, index + 1);
                        lines[index] = input.Split().Select(x => double.Parse(x)).ToArray();
                        index++;
                    }
                }

                return new Matrix(lines);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.Gray;
                return null;
            }
        }
    }
}
