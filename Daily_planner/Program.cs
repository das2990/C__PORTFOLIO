using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Daily_planner
{
    class Program
    {
        static void Main(string[] args)
        {
            Repository bd = new Repository(); //инициализируем новый репозиторий для хранения массива записей
            byte i; //первая вспомогательная переменная
            byte e; //вторая вспомогательная переменная
            string path; //название пути или имени файла в методе экспорта/импорта данных
            byte caseSwitch; //переменная для цикла в котором пользователь взаимодействует с интерфейсом

            while (true) //зацикливаем выполнением действий в ежедневнике
            {
                Console.Clear(); //очищаем консоль
                Console.WriteLine("ЕЖЕДНЕВНИК");
                Console.WriteLine("\nЧто вы хотите сделать? " +
                    "\n[1] - создать новую запись " +
                    "\n[2] - прочитать все записи " +
                    "\n[3] - редактировать запись " +
                    "\n[4] - удалить запись " +
                    "\n[5] - Экспорт / Импорт записей" +
                    "\n[0] - выйти");
                caseSwitch = Convert.ToByte(Console.ReadLine());
                if (caseSwitch == 0) break; //если пользователь хочет выйти из ежидневника, то прекращаем цикл while

                switch (caseSwitch)
                {
                    case 1:
                        Console.WriteLine($"\nНовая запись {Repository.index}");
                        Console.Write("Введите дату исполнения (формат DD.MM.YYY): ");
                        DateTime TD = DateTime.Parse(Console.ReadLine());
                        Console.Write("Введите заголовок записи: ");
                        string head = Console.ReadLine();
                        Console.Write("Введите тело записи: ");
                        string body = Console.ReadLine();
                        bd.Add(new Record(TD, head, body)); //запись данных в структуру
                        break;
                    case 2:
                        Console.WriteLine("\nВыберите вариант сортировки записей: " +
                            "\n[1] - сортировка по дате исполнения " +
                            "\n[2] - сортировка по дате создания");
                        i = Convert.ToByte(Console.ReadLine());
                        bd.Sort(i); //сортируем записи
                        bd.PrintBD(); //печать всего массива в консоль
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.WriteLine("Все записи в записной книжке:");
                        bd.PrintBD(); //печать всего массива в консоль

                        Console.Write("\nВведите номер записи для редактирвоания: ");
                        i = Convert.ToByte(Console.ReadLine());

                        if (i > Repository.index) //проверяем наличие записи
                        { Console.WriteLine("Такой записи нет"); Console.ReadKey(); break; }
                        else { bd.PrintIndex(i);} //выводим запись в консоль
                                                
                        Console.WriteLine("\nКакое поле хотите отредактировать? \n[1] - дата исполнения \n[2] - тело записи");
                        e = Convert.ToByte(Console.ReadLine());
                        bd.Edit(e); //редактируем выбранное поле выбранной записи
                        bd.PrintIndex(i); //повторно выводим уже отредактирвоанную запись
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.Write("Введите номер записи для удаления: ");
                        i = Convert.ToByte(Console.ReadLine());
                        bd.Delete(i); //обнуляем запись в массиве
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.WriteLine("[1] - экспорт записией \n[2] - импорт записей");
                        i = Convert.ToByte(Console.ReadLine());

                        switch(i)
                        {
                            case 1:
                                Console.Write("Введите название файла для экспорта в формате _data.csv_: ");
                                path = Convert.ToString(Console.ReadLine());
                                bd.Write(path); //метод сохранение данных в файл
                                Console.Write("Готово");
                                break;
                            case 2:
                                Console.Write("Введите путь к файлу в формате LFS: "); //например: C:\Users\primer.csv
                                path = Convert.ToString(Console.ReadLine());
                                Console.WriteLine("\n[1] - импорт всех записией \n[2] - импорт записей по дате создания");
                                e = Convert.ToByte(Console.ReadLine());
                                switch (e)
                                {
                                    case 1:
                                        bd.Load(path); //загружаем все данные из файла
                                        Console.Write("Готово");
                                        break;
                                    case 2:
                                        Console.WriteLine("Введите диапазон дат, которые нужно импортировать:");
                                        Console.Write("От: ");
                                        DateTime UTime1 = DateTime.Parse(Console.ReadLine());
                                        Console.Write("До: ");
                                        DateTime UTime2 = DateTime.Parse(Console.ReadLine());
                                        bd.Load(path, UTime1, UTime2); //перегрузка метода. Загружаем из файла с проверкой по дате создания
                                        Console.Write("Готово");
                                        break;
                                    default:
                                        Console.WriteLine("Несуществующий вариант");
                                        break;
                                }
                                break;
                            default:
                                Console.WriteLine("Несуществующий вариант");
                                break;
                        }
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Несуществующий вариант");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
