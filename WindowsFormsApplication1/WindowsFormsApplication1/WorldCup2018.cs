using System;
using System.Collections.Generic;


namespace WindowsFormsApplication1
{
    public class WorldCup2018
    {
        public string comand { get; set; } // Название команды
        public string Base { get; set; } // База дислокации
        public string group { get; set; } // Группа, в которой играет команда
        public int NumberPlayers { get; set; } // Количество заявленных игроков
        public string ColorForm { get; set; } // Цвет формы
        public string Capitan { get; set; } // Капитан команды
        public string Coach { get; set; } // Тренер команды

        // Установим ограничение года выпуска автомобиля
        //public int Year
        //{
          //  get { return year; }
            //set
            //{
              //  if (value >= 1900 && value <= 2100) year = value;
                //else Console.WriteLine("Год не адекватен");
            //}

        //}
        // Метод, выводящий в консоль
        public void WriteInConsoleInfo()
        {
            Console.WriteLine("Команда: {0}\nБаза дислокации: {1}\nГруппа: {2}\nКоличество заявленных игроков: {3}\nЦвет формы: {4}\nКапитан команды: {5}\nТренер: {6}\n", 
                this.comand, this.Base, this.group, this.NumberPlayers, this.ColorForm, this.Capitan, this.Coach);
        }
        // Параметрический конструктор класса
        public WorldCup2018(string comand, string Base, string group, int NumberPlayers, string ColorForm, string Capitan, string Coach)
        {
            this.comand = comand;
            this.Base = Base;
            this.group = group;
            this.NumberPlayers = NumberPlayers;
            this.ColorForm = ColorForm;
            this.Capitan = Capitan;
            this.Coach = Coach;
        }
        public WorldCup2018()
        {

        }

    }
}