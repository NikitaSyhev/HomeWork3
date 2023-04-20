using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;

namespace HomeWork3
{
    enum Month
    {
        Январь = 1,
        Февраль,
        Март,
        Апрель,
        Май,
        Июнь,
        Июль,
        Август,
        Сентябрь,
        Октябрь,
        Ноябрь,
        Декабрь
    }
    class myMeterReader
    {
        int waterCount;
        public int WaterCount
        {
            get
            {
                return waterCount;
            }
            set
            {
                waterCount = value;
            }
        }
        public myMeterReader(int _number)
        {
            waterCount = _number;
        }
        public string convert2Str()
        {
            string _tmp = waterCount.ToString();
            while (_tmp.Length < 8)
            {
                _tmp = "0" + _tmp;
            }
            return _tmp;
        }
    }
    struct myMeterReader02
    {
        public myMeterReader Cold;
        public myMeterReader Hot;
    }
    class myCounter
    {
        int _min = 0, _max = 99999999;
        List<myMeterReader02> myBillList = new List<myMeterReader02>();
        public myCounter(int _cold, int _hot)
        {
            if (_cold >= _min || _cold <= _max)
            {
                if (_hot >= _min || _hot <= _max)
                {
                    myMeterReader02 myMR02;
                    myMR02.Cold = new myMeterReader(_cold);
                    myMR02.Hot = new myMeterReader(_hot);
                    myBillList.Add(myMR02);
                }
            }
        }
        public bool addMetric(int _cold, int _hot)
        {
            bool result = false;
            int _lastElement = myBillList.Count;
            if (myBillList[_lastElement - 1].Cold.WaterCount <= _cold)
            {
                if (myBillList[_lastElement - 1].Hot.WaterCount <= _hot)
                {
                    myMeterReader02 myMR02;
                    myMR02.Cold = new myMeterReader(_cold);
                    myMR02.Hot = new myMeterReader(_hot);
                    myBillList.Add(myMR02);
                    result = true;
                }

            }
            return result;
        }
        public List<myMeterReader02> getValues()
        {
            return myBillList;
        }
    }


    internal class Program
    {
        static void addDataFromArr()
        {

        }
        static void Main(string[] args)
        {
            ////Задача 1
            //Console.WriteLine("Task 1");

            //string number;
            //Console.WriteLine("Enter a 4 digit number");
            //number = Console.ReadLine();
            //if (number.Length == 4)
            //{
            //    for (int i = number.Length - 1; i >= 0; i--)
            //    {
            //        Console.Write(number[i]);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("Error");
            //}
            //Console.WriteLine("\n");

            //Console.WriteLine("Task2");

            //Console.WriteLine("Enter a 6 digit number");
            //string number2;
            //int tmp;
            //number2 = Console.ReadLine();
            //if (number2.Length == 6)
            //{
            //    for (int i = 0; i < number2.Length; i++)
            //    {
            //        tmp = Convert.ToInt32(number2[i]);
            //        if (number2[i] % 2 == 0)
            //        {
            //            Console.WriteLine(number2[i]);
            //        }

            //    }
            //}
            //else
            //{
            //    Console.WriteLine("Error");
            //}


            ////Задача 2
            //Console.WriteLine("Task3");


            //Console.WriteLine("Enter a key");
            //ConsoleKeyInfo key = Console.ReadKey();
            //DateTime startTime = DateTime.Now;

            //while (true)
            //{
            //    DateTime startTime1 = DateTime.Now;
            //    key = Console.ReadKey();

            //    if (key.Key == ConsoleKey.Enter)
            //    {
            //        DateTime stopTime1 = DateTime.Now;
            //        TimeSpan timeSpan1 = stopTime1 - startTime1;
            //        Console.WriteLine($"\nLap time {timeSpan1.ToString("ss")}");
            //        Console.ReadKey();

            //    }
            //    else if ((key.Key == ConsoleKey.Spacebar))
            //    {
            //        DateTime stopTime = DateTime.Now;
            //        TimeSpan timeSpan = stopTime - startTime;
            //        Console.WriteLine($"\nLap time {timeSpan.ToString("ss")}");
            //    }


            //Задача 4

            Console.WriteLine("Task4");
            string path = @"C:\Users\nosychev\Desktop\Programmatic\С#\HomeWork3\HomeWork3";
            File.Create("text.doc");




            int[,] counterArr = new int[,] { { 12, 10 }, { 13, 11 }, { 14, 13 }, { 15, 21 }, { 16, 22 }, { 17, 23 }, { 18, 24 }, { 19, 25 }, { 20, 24 }, { 21, 25 }, { 22, 26 }, { 23, 27 } };
            int _row = counterArr.GetUpperBound(0); 
            int _column = counterArr.Length / _row; 
            int _cold = 0, _hot = 0;
            myCounter _meterReader = new myCounter(0, 0);
            int sum = 0;
            for (int i = 0; i < _row; i++)
            {
                for (int j = 0; j < _column; j++)
                {
                    if (j % 2 == 0)
                    {
                        _cold = counterArr[i, j];
                        Console.Write("холодная = " + counterArr[i, j] + " ");
                       // File.WriteAllText(path, counterArr[i, j].ToString());
                    }
                    else
                    {
                        _hot = counterArr[i, j];
                        Console.Write("горячая = " + counterArr[i, j] + ".");
                        // File.WriteAllText(path, counterArr[i, j].ToString());
                    }
                    sum += counterArr[i,j];
                }
                Console.WriteLine($"Пытаюсь добавить значение холодной {_cold} и горячей {_hot} воды");
                if (_meterReader.addMetric(_cold, _hot))
                {
                    Console.WriteLine($"Добавлено значение холодной {_cold} и горячей {_hot} воды");
                }
                else
                {
                    Console.WriteLine($"Значение холодной {_cold} и горячей {_hot} воды не добавлено");
                }
                Console.WriteLine();
                
            }
            
            Console.WriteLine($"\n\nИтог: {sum}");
            int _month = 1;
            string myMonth;
            _meterReader.getValues().RemoveAt(0);

       

            {
                foreach (var item in _meterReader.getValues())
                {
                    myMonth = Enum.GetName(typeof(Month), _month);
                    Console.WriteLine($"За {myMonth} \t холодная = {item.Cold.convert2Str()} горячая = {item.Hot.convert2Str()}");
                    _month++;


                }
               
            }
            

                  Console.ReadLine();

            }
        }
    }






              