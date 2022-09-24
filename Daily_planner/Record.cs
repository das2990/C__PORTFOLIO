using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daily_planner
{
    /// <summary>
    /// Структура данных записной книжки
    /// </summary>
    struct Record
    {
        /// <summary>
        /// Номер записи, присваивается автоматически
        /// </summary>
        public byte number { get; private set; }

        /// <summary>
        /// Дата создания записи, присваивается автоматически
        /// </summary>
        public DateTime CurrentTime { get; private set; }

        /// <summary>
        /// Дата исполнения записи, назначается пользователем
        /// </summary>
        public DateTime TimeToDo { get; set; }

        /// <summary>
        /// Заголовок записи
        /// </summary>
        public string head { get; set; }

        /// <summary>
        /// Тело записи
        /// </summary>
        public string body { get; set; }

        /// <summary>
        /// Вывод записной книжки на экран
        /// </summary>
        /// <returns></returns>
        public string print()
        {
            return $"\nНомер записи: {number} " +
                $"\nДата создания записи: {CurrentTime:dd.MM.yyy} " +
                $"\nДата исполнения записи: {TimeToDo:dd.MM.yyy} " +
                $"\nЗаголовок записи: {head} " +
                $"\nТело записи: {body}";
        }

        /// <summary>
        /// Создание записи
        /// </summary>
        /// <param name="number">Номер записи</param>
        /// <param name="CurrentTime">Текущее время</param>
        /// <param name="TimeToDo">Время исполнения</param>
        /// <param name="head">Звголовок записи</param>
        /// <param name="body">Тело записи</param>
        public Record(byte number, DateTime CurrentTime, DateTime TimeToDo, string head, string body)
        {
            this.number = number;
            this.CurrentTime = CurrentTime;
            this.TimeToDo = TimeToDo;
            this.head = head;
            this.body = body;
        }

        /// <summary>
        /// Создание записи
        /// </summary>
        /// <param name="TimeToDo">Время исполнения</param>
        /// <param name="head">Заголовок записи</param>
        /// <param name="body">Тело записи</param>
        public Record(DateTime TimeToDo, string head, string body) :
            this(0, DateTime.Now, TimeToDo, head, body)
        {
            this.number = (byte)Repository.index;
        }

/// <summary>
/// Создание записи
/// </summary>
/// <param name="CurrentTime">Дата создания записи</param>
/// <param name="TimeToDo">Дата исполнения записи</param>
/// <param name="head">Заголовок записи</param>
/// <param name="body">Тело записи</param>
        public Record(DateTime CurrentTime, DateTime TimeToDo, string head, string body) :
            this(0, CurrentTime, TimeToDo, head, body)
        {
            this.number = (byte)Repository.index;
        }
    }
        
}
