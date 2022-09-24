using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace Daily_planner
{
    struct Repository
    {
        /// <summary>
        /// База данных всех записей
        /// </summary>
        public Record[] Records; //массив для записей

        public static int index; //публичная статичная переменная для определения позиции записи
        byte e; //переменная для хранения индекса записи в резульатте поиска по полю number

        /// <summary>
        /// Метод для изменения данных в записи
        /// </summary>
        /// <param name="index">Номер записи</param>
        /// <returns></returns>
        public Record this[int index]
        {
            get { return Records[index]; }
            set { Records[index] = value; }
        }

        /// <summary>
        /// Метод увеличения массива
        /// </summary>
        /// <param name="Flag">Тригер, если массив меньше</param>
        private void Resize(bool Flag)
        {
            if (Flag)
            {
                Array.Resize(ref this.Records, this.Records.Length + 1);
            }
        }

        /// <summary>
        /// Добавление данных в записную книжку
        /// </summary>
        /// <param name="CurrentRecord">добавленные данные</param>
        public void Add(Record CurrentRecord)
        {
            if (index == 0) //проверяем есть ли записи в книжке
            {
                index = 0;
                this.Records = new Record[1]; //инициализируем новый массив для хранения записей
                this.Records[index] = CurrentRecord; //записываем данные в массив
                index++; //увеличиваем индекс
            }
            else
            {
                this.Resize(index >= this.Records.Length); //если индекс больше длины массива, то вызываем метод Resize
                this.Records[index] = CurrentRecord; //записываем данные в массив
                index++; //увеличиваем индекс
            }

        }

        /// <summary>
        /// Добавление данных в записную книжку
        /// </summary>
        /// <param name="CurrentRecord">добавленные данные</param>
        /// <param name="UTime1">Меньшее значение в диапазоне</param>
        /// <param name="UTime2">Большее значение в диапазоне</param>
        public void Add(Record CurrentRecord, DateTime UTime1, DateTime UTime2)
        {
            if (index == 0) //проверяем есть ли записи в книжке
            {
                if (CurrentRecord.CurrentTime < UTime2 && CurrentRecord.CurrentTime > UTime1) //проверяем диапазон дат в новых записях/ от 1.01.2020 до 20.07.2020
                {
                    index = 0;
                    this.Records = new Record[1]; //инициализируем новый массив для хранения записей
                    this.Records[index] = CurrentRecord; //записываем данные в массив
                    index++; //увеличиваем индекс
                }
            }
            else
            {
                this.Resize(index >= this.Records.Length); //если индекс больше длины массива, то вызываем метод Resize
                if (CurrentRecord.CurrentTime < UTime2 && CurrentRecord.CurrentTime > UTime1) //проверяем диапазон дат в новых записях
                {
                    this.Records[index] = CurrentRecord; //записываем данные в массив
                    index++; //увеличиваем индекс
                }
            }

        }

        /// <summary>
        /// Метод вывода всей записной книжки в консоль
        /// </summary>
        public void PrintBD()
        {
            for (int i = 0; i < index; i++)
            {
                if (this.Records[i].head != null) //проверка на удаленную запись
                {
                    Console.WriteLine(this.Records[i].print());
                }
                else continue;
            }

        }

        /// <summary>
        /// Метод вывода одной записи по индексу
        /// </summary>
        public void PrintIndex(byte i)
        {

            if (this.Records[i].head != null) //проверка на удаленную запись
            {
                for ( e = 0; e < index; e++)
                {
                    if (this.Records[e].number == i)
                    {
                        Console.WriteLine(this.Records[e].print()); //выводим запись в консоль
                        break;
                    }
                    else continue;
                }
            }
            else { Console.WriteLine("Такой записи нет"); }
        }

        /// <summary>
    /// Медот обнуляет значение записи
    /// </summary>
    /// <param name="i">Целочисленный номер записи</param>
        public void Delete(int i)
        {
            this.Records[i] = default(Record); //обнуляем значение записи в массиве
        }

        /// <summary>
        ///  Сортирует записи по дате создания или дате исполнения
        /// </summary>
        /// <param name="i">1 — сортировка по исполнению, 2 — сортировка по созданию</param>
        public void Sort(byte i)
        {
            if (Records == null) { Console.WriteLine("У вас нет записей"); } //проверяем есть ли в массиве записи
            else
            {
                switch (i)
                {
                    case 1:
                        Array.Sort(Records, new Comparison<Record>((a, b) => a.TimeToDo.CompareTo(b.TimeToDo)));
                        break;
                    case 2:
                        Array.Sort(Records, new Comparison<Record>((a, b) => a.CurrentTime.CompareTo(b.CurrentTime)));
                        break;
                    default:
                        Console.WriteLine("Такого варианта сортировки нет");
                        break;
                }
            }
        }

        /// <summary>
        /// Метод загрузки данных из файла
        /// </summary>
        /// <param name="path">Путь к файлу в формате LFS</param>
        public void Load (string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    string[] args = sr.ReadLine().Split(',');
                    Add(new Record(Convert.ToDateTime(args[0]), Convert.ToDateTime(args[1]), args[2], args[3]));
                }
            }
        }

        /// <summary>
        ///  Метод загрузки данных из файла
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <param name="UTime1">Меньшее значение в диапазоне</param>
        /// <param name="UTime2">Большее значение в диапазоне</param>
        public void Load(string path, DateTime UTime1, DateTime UTime2)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    string[] args = sr.ReadLine().Split(',');
                    Add(new Record(Convert.ToDateTime(args[0]), Convert.ToDateTime(args[1]), args[2], args[3]), UTime1, UTime2);
                }
            }
        }

        /// <summary>
        /// Метод сохранения данных в файл
        /// </summary>
        /// <param name="path">Название файла</param>
        public void Write (string path)
        {
            //if (!File.Exists(path)) //создаем файл
            //{
                using (StreamWriter sw = new StreamWriter(path, true, Encoding.Unicode)) //

                //sw = File.CreateText(path);)
                {
                    for (int i = 0; i < index; i++)
                    {
                        if (this.Records[i].head != null) //проверка на удаленную запись
                        {
                            // sw.WriteLine(string.Join(",", Records[i])); //сцепляем записи массива
                            sw.WriteLine(Records[i].number + ","
                                + Records[i].CurrentTime + ","
                                + Records[i].TimeToDo + ","
                                + Records[i].head + ","
                                + Records[i].body);

                        }
                        else continue;
                    }

                //}
            }
        }

        /// <summary>
        /// Метод для редактирования записи
        /// </summary>
        /// <param name="i">1 - редактируем timetodo; 2 - редактируем body</param>
        public void Edit (byte i)
        {
                    switch (i)
                    {
                        case 1:
                            Records[e].TimeToDo = DateTime.Parse(Console.ReadLine()); //присваиваем полю в массиве новое значение
                            Console.WriteLine("\nОтредактированная запись:");
                            break;
                        case 2:
                            Records[e].body = Console.ReadLine(); //присваиваем полю в массиве новое значение
                            Console.WriteLine("\nОтредактированная запись:");
                            break;
                        default:
                            Console.WriteLine("Несуществующий вариант");
                            break;
                    }
        }
    }
}
