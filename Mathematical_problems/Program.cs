using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mathematical_problems
{
    class Program
    {
        /// <summary>
        /// Метод заполняющий матрицу псевдослучайными числами
        /// </summary>
        /// <param name="matrix">Двумерная матрица</param>
        static void Add_Value (int[,] matrix)
        {
            Random r = new Random();
            for (byte i = 0; i < matrix.GetLength(0); i++)
            {
                for (byte j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = r.Next(1,30);
                }
            }
        }
        /// <summary>
        /// Метод вывода матрицы в консоль
        /// </summary>
        /// <param name="matrix">Двумерная матрица</param>
        static void Print (int[,] matrix)
        {
            for (byte i = 0; i < matrix.GetLength(0); i++)
            {
                for (byte j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j],5}");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        /// <summary>
        /// Метод умножения матрицы на число
        /// </summary>
        /// <param name="Args">Двумерная матрица</param>
        /// <param name="f">Множитель</param>
        /// <returns></returns>
        static int[,] Umnogenie (int[,] Args, int f)
        {
            int[,] matrix3 = new int[Args.GetLength(0),Args.GetLength(1)];

            for (byte i = 0; i < Args.GetLength(0); i++)
            {
                for (byte j = 0; j < Args.GetLength(1); j++)
                {
                    matrix3[i,j] = Args[i, j] * f;
                    Console.Write($"{matrix3[i, j],5} ");
                }
                Console.WriteLine();
            }
            return matrix3;
        }
        /// <summary>
        /// Метод принимает две матрицы и выводит их сумму
        /// </summary>
        /// <param name="Args">Первая двумерная матрица</param>
        /// <param name="Args2">Вторая двумерная матрица</param>
        /// <returns></returns>
        static int[,] Sum (int[,] Args, int[,] Args2)
        {
            int[,] matrix3 = new int[Args.GetLength(0), Args.GetLength(1)];

            for (byte i = 0; i < Args.GetLength(0); i++)
            {
                for (byte j = 0; j < Args.GetLength(1); j++)
                {
                    matrix3[i, j] = Args[i, j] + Args2[i, j];
                    Console.Write($"{matrix3[i, j],5} ");
                }
                Console.WriteLine();
            }
            return matrix3;
        }
        /// <summary>
        /// Метод принимает две матрицы и находит их произведение
        /// </summary>
        /// <param name="Args">Первая двумерная матрица</param>
        /// <param name="Args2">Вторая двумерная матрица</param>
        /// <returns></returns>
        static int[,] Proizvedenie (int[,] Args, int[,] Args2)
        {
            int[,] matrix3 = new int[Args.GetLength(0), Args.GetLength(1)];

            for (byte i = 0; i < Args.GetLength(0); i++)
            {
                for (byte j = 0; j < Args.GetLength(1); j++)
                {
                    matrix3[i, j] = 0;
                    for (byte e = 0; e < Args.GetLength(1); e++)
                    {
                        matrix3[i, j] += Args[i, e] * Args2[e, j];
                    }
                    Console.Write($"{matrix3[i, j],5} ");
                }
                Console.WriteLine();
            }
            return matrix3;
        }
        /// <summary>
        /// Метод, поиска минимального значения в массиве
        /// </summary>
        /// <param name="Col">Переменная типа string, в которой нужно найти слово с минимальным количеством букв</param>
        /// <returns>Слова с минимальной длинной</returns>
        static string Min (string Col)
        {
            string[] matrix = Col.Split(' ', ',', '.' ); //входные данные разбиваем на подстроки согласно разделителям и заносим в новый массив
            int min = matrix[0].Length; //переменная нужна для сравнивания длины слова, по умолчанию присваивае длину первого значения в массиве
            //string[] minlenght = new string[matrix.Length]; //массив для записи найденных минимальных слов
            string minleght = "";

            for (int i = 0; i < matrix.Length; i++) //проходимся циклом по массиву и выясняем минимальную длину значения в массиве
            {
                if (matrix[i].Length <= min) //сравниваем длину первого значения в массиве с переменной min
                {
                    min = matrix[i].Length; //присваиваем новое значение переменной min
                }
                else continue;
            }
            for (int i = 0; i < matrix.Length; i++) //проходимся циклом по массиву и ищем все значения с минимальным кол-вом символов
            {
                if (matrix[i].Length <= min) //сравниваем длину первого значения в массиве с переменной min
                {
                    minleght += matrix[i] +=" "; //добавляем значение в строковую переменную
                    //minlenght[i] = matrix[i]; //записываем слово в массив для минимальных значений
                }
                else continue;
            }

            //string ms = String.Join(" ", minlenght); //создаем строковую переменную и сцепляем весь массив найденных значений
            return minleght; //выводим данные
        }
        /// <summary>
        /// Метод, поиска максимального значения в массиве
        /// </summary>
        /// <param name="Col">Переменная типа string, в которой нужно найти слово с минимальным количеством букв</param>
        /// <returns>Слова с максимальной длинной</returns>
        static string Max(string Col)
        {
            string[] matrix = Col.Split(' ', ',', '.'); //входные данные разбиваем на подстроки согласно разделителям и заносим в новый массив
            int max = matrix[0].Length; //переменная нужна для сравнивания длины слова, по умолчанию присваивае длину первого значения в массиве
            //string[] maxlenght = new string[matrix.Length]; //массив для записи найденных максимальных слов
            string maxleght = "";

            for (int i = 0; i < matrix.Length; i++) //проходимся циклом по массиву и находим максимальную длину слова
            {
                if (matrix[i].Length >= max) //сравниваем длину первого значения в массиве с переменной max
                {
                    max = matrix[i].Length; //присваиваем новое значение переменной min
                }
                else continue;
            }

            for (int i = 0; i < matrix.Length; i++) //проходимся циклом по массиву и записываем слова с максимальным кол-вом букв в новый массив
            {
                if (matrix[i].Length >= max) //сравниваем длину первого значения в массиве с переменной max
                {
                    maxleght += matrix[i] += " "; //добавляем значение в строковую переменную
                    //maxlenght[i] = matrix[i]; //записываем слово в массив для максимальных значений
                }
                else continue;
            }

            //string ms = String.Join(" ", maxlenght); //создаем строковую переменную и сцепляем весь массив найденных значений
            return maxleght; //выводим данные
        }
        /// <summary>
        /// Метод удаления дублируемых символов в строке
        /// </summary>
        /// <param name="Col">Переменная типа string, в которой нужно удалить все дублируемые символы</param>
        /// <returns>Исходная строка из которой удалили дублируемые символы</returns>
        static string Short(string Col)
        {
            char[] matrix = Col.ToCharArray(); //конвертируем строку пользовательских данных в массив символов
            string sw = Convert.ToString(matrix[0]); //создаем строковую переменную для хранения сокращенного текста

            for (int i = 1; i < matrix.Length; i++) //проходим циклом по исхордному массиву начиная со второго значения
            {
                if (matrix[i] == matrix[i - 1]) //если второй символ равен предыдущему, то ничего не делаем
                {
                }
                else //если символ не арвен предыдущему то добавляем в строковую переменную
                {
                    sw += matrix[i];
                }
            }
            return sw; //выводим данные
        }
        /// <summary>
        /// Метод проверки на геометрическую/арифметическую прогрессию
        /// </summary>
        /// <param name="Col">Переменная типа string, в которой содержится пользовательская последовательность/param>
        /// <returns>Название прогрессии</returns>
        static string Progression(string Col)
        {
            string[] str = Col.Split(' '); //входные данные разбиваем на подстроки согласно разделителям и заносим в новый массив
            double[] matrix = new double[str.Length]; //новый массив для чисел
            string ms = ""; //переменная, куда запишем результат

            for (int i = 0; i < str.Length; i++) //цикл для преобразования строкового массива в числовой массив
            {
                matrix[i] = Convert.ToDouble(str[i]); //каждое значение исходного строкового массива конвертируем в int и записываем в новый массив
            }

            for (int i = 1; i < matrix.Length-1; i++)
            {
                if (matrix[i] - matrix[i-1] == matrix[i+1] - matrix[i]) // В арифм. прогр. разность между членами прогрессии остается неизменной
                {
                    ms = "Это арифметическая прогрессия";
                }
                else if (matrix[i] / matrix[i - 1] == matrix[i + 1] / matrix[i]) //В геометр. прогр. отношение между членами прогрессии остается неизменным
                {
                    ms = "Это геометрическая прогрессия";
                }
                else
                {
                    ms = "Это НЕ прогрессия";
                }
            }

            return ms; //выводим данные
        }

        static void Main(string[] args)
        {
            #region Задание 1
            Console.WriteLine("Задание 1: действия с матрицами");
            Console.Write("Введите количество строк матрицы: ");
            int r = int.Parse(Console.ReadLine()); // пользователь вводит кол-во строк матрицы
            Console.Write("Введите количество столбцов матрицы: ");
            int c = int.Parse(Console.ReadLine()); // пользователь вводит кол-во столбцов матрицы

            Console.WriteLine("\nКакое действие будем выполнять? \n[1] умножение матрицы на число \n[2] сумма двух матриц \n[3] произведение двух матриц");
            byte value = byte.Parse(Console.ReadLine()); //получаем пользовательское значение и записываем его в переменную

            int[,] matrix1 = new int[r, c]; //исходная двумерная матрица 1
            int[,] matrix2 = new int[r, c]; //исходная двумерная матрица 2

            switch (value)
            {
                case 1: //умножение матрицы на число
                    Console.Write("Введите множитель: ");
                    int f = int.Parse(Console.ReadLine()); // пользователь вводит множитель
                    Console.WriteLine("Матрица до преобразования");
                    Add_Value(matrix1); //вызываем метод заполнения матрицы 
                    Print(matrix1); //вызываем метод вывода матрицы
                    Console.WriteLine("Результат умножения матрицы на число:");
                    Umnogenie(matrix1, f); //вызываем метод умножения матрицы на число
                    Console.ReadKey();
                    break;
                case 2: //сумма двух матриц
                    Console.WriteLine("Матрица 1:");
                    Add_Value(matrix1); //вызываем метод заполнения матрицы 
                    Print(matrix1); //вызываем метод вывода матрицы
                    Console.WriteLine("Матрица 2:");
                    Add_Value(matrix2); //вызываем метод заполнения матрицы 
                    Print(matrix2); //вызываем метод вывода матрицы
                    Console.WriteLine("Сумма двух матриц:");
                    Sum(matrix1, matrix2); //вызываем метод сложения матриц
                    Console.ReadKey();
                    break;
                case 3: //произведение двух матриц
                    Console.WriteLine("Матрица 1:");
                    Add_Value(matrix1); //вызываем метод заполнения матрицы 
                    Print(matrix1); //вызываем метод вывода матрицы
                    Console.WriteLine("Матрица 2:");
                    Add_Value(matrix2); //вызываем метод заполнения матрицы 
                    Print(matrix2); //вызываем метод вывода матрицы
                    if (r == c) //Операция умножения двух матриц выполнима только в том случае, если число столбцов в первом сомножителе равно числу строк во втором
                    {
                        Console.WriteLine("Произведение двух матриц:");
                        Proizvedenie(matrix1, matrix2); //вызываем метод умножения матриц
                        Console.ReadKey();
                        break;
                    }
                    else { Console.WriteLine("Матрицы не согласованы! Умножение невозможно."); break; }

                default:
                    Console.WriteLine("Выбран недопустимый вариант");
                    Console.ReadKey();
                    break;
            }
            #endregion

            #region Задание 2
            Console.WriteLine("\nЗадание 2: Программа принимает текст и находит самое длинное и самое короткое слово");
            Console.Write("Введите текст:");
            string zadanie2 = Convert.ToString(Console.ReadLine()); //пользователь вводит текст

            Console.Write($"\nМинимальное количество букв: {Min(zadanie2)}");
            Console.Write($"\nМаксимальное количество букв: {Max(zadanie2)}");
            Console.ReadKey();
            #endregion

            #region Задание 3
            Console.WriteLine();
            Console.WriteLine("\nЗадание 3: удаляем дублируемые символы");
            Console.Write("Введите текст: ");
            string zadanie3 = Convert.ToString(Console.ReadLine()); //пользователь вводит текст
            Console.Write($"Сокращенный текст: {Short(zadanie3)}");
            Console.ReadKey();
            #endregion

            #region Задание 4
            Console.WriteLine();
            Console.WriteLine("\nЗадание 4: проверка последовательности на прогрессию");
            Console.Write("Введите последовательность не менее 3х символов (разделитель пробел): ");
            string zadanie4 = Convert.ToString(Console.ReadLine()); //пользователь вводит текст
            Console.Write($"Результат: {Progression(zadanie4)}");
            Console.ReadKey();
            #endregion


        }
    }
}
