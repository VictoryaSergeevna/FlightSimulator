using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace Flight_simulator_pilot
{
    public class Fly : IdangerSimulator
    {
        public event MyEventHandler startFlying;
        public event MyEventHandler finishFlying;
        public event MyEventHandler dangerSpeed;
        public event MyEventHandler dangerHeight;
        public Airplane airplane = null;
        public Fly(string NameAirplane,string firstName, int N1, string secondName, int N2)
        {
            airplane = new Airplane(NameAirplane,firstName, N1, secondName, N2);
        }
        public void initStart()
        {
            startFlying(this, new MyEventArgs("\tМы начинаем взлетать!"));
        }

        public void initFinish()
        {
            finishFlying(this, new MyEventArgs("\tТест пройден!"));
        }

        public void takeOffAirplane()
        {
            do
            {
                Clear();
                airplane.FirstDisp.recomendation(airplane.CurrentSpeed, airplane.CurrentHeight);
                airplane.SecondDisp.recomendation(airplane.CurrentSpeed, airplane.CurrentHeight);
                WriteLine(airplane);
                WriteLine(airplane.FirstDisp);
                WriteLine(airplane.SecondDisp);
                Write("\tУправление самолетом осуществляеться при помощи стрелок! -> ");


                if (airplane.CurrentSpeed >= 1000)
                {
                    Clear();
                    WriteLine("\tВы на вершине! Теперь вам нужно посадить самолет!!");
                    ReadKey();
                    break;
                }
                else
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    airplane.totalPenaltyPoints(airplane.FirstDisp, airplane.SecondDisp);
                    if (key.Key == ConsoleKey.UpArrow)
                    {
                        airplane.heightUP();
                        WriteLine($"\nВысота: { airplane.CurrentHeight}");
                    }
                    else if (key.Key == ConsoleKey.DownArrow)
                    {
                        airplane.heightDown();
                        WriteLine($"\nВысота: {airplane.CurrentHeight }");
                    }
                    else if (key.Key == ConsoleKey.RightArrow)
                    {
                        airplane.speedUP();
                        WriteLine($"\nСкорость: { airplane.CurrentSpeed}");
                    }
                    else if (key.Key == ConsoleKey.LeftArrow)
                    {
                        airplane.speedDown();
                        WriteLine($"\nСкорость: {airplane.CurrentSpeed }");
                    }
                    else if (key.Modifiers == ConsoleModifiers.Shift && key.Key == ConsoleKey.UpArrow)
                    {
                        airplane.ShiftHeightUP();
                        WriteLine($"\nВысота: { airplane.CurrentHeight}");
                    }
                    else if (key.Modifiers == ConsoleModifiers.Shift && key.Key == ConsoleKey.DownArrow)
                    {
                        airplane.ShiftHeightDown();
                        WriteLine($"\nВысота: {airplane.CurrentHeight }");
                    }
                    else if (key.Modifiers == ConsoleModifiers.Shift && key.Key == ConsoleKey.RightArrow)
                    {
                        airplane.ShiftSpeedUP();
                        WriteLine($"\nСкорость: { airplane.CurrentSpeed}");
                    }
                    else if (key.Modifiers == ConsoleModifiers.Shift && key.Key == ConsoleKey.LeftArrow)
                    {
                        airplane.ShiftSpeedDown();
                        WriteLine($"\nСкорость: {airplane.CurrentSpeed }");
                    }

                }

            } while (airplane.CurrentSpeed >= 0);


        }

        public void landingAirplane()
        {
            do
            {
                Clear();
                airplane.FirstDisp.recomendation(airplane.CurrentSpeed, airplane.CurrentHeight);
                airplane.SecondDisp.recomendation(airplane.CurrentSpeed, airplane.CurrentHeight);
                WriteLine(airplane);
                WriteLine(airplane.FirstDisp);
                WriteLine(airplane.SecondDisp);
                Write("\tУправление самолетом осуществляеться при помощи стрелок! -> ");

                if (airplane.CurrentSpeed <= 0)
                {
                    Clear();
                    WriteLine("\tСамолет приземлился!");
                    break;
                }
                else
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    airplane.totalPenaltyPoints(airplane.FirstDisp, airplane.SecondDisp);
                    if (key.Key == ConsoleKey.UpArrow)
                    {
                        airplane.heightUP();
                        WriteLine($"\nВысота: { airplane.CurrentHeight}");
                    }
                    else if (key.Key == ConsoleKey.DownArrow)
                    {
                        airplane.heightDown();
                        WriteLine($"\nВысота: {airplane.CurrentHeight }");
                    }
                    else if (key.Key == ConsoleKey.RightArrow)
                    {
                        airplane.speedUP();
                        WriteLine($"\nСкорость: { airplane.CurrentSpeed}");
                    }
                    else if (key.Key == ConsoleKey.LeftArrow)
                    {
                        airplane.speedDown();
                        WriteLine($"\nСкорость: {airplane.CurrentSpeed }");
                    }
                    else if (key.Modifiers == ConsoleModifiers.Shift && key.Key == ConsoleKey.UpArrow)
                    {
                        airplane.ShiftHeightUP();
                        WriteLine($"\nВысота: { airplane.CurrentHeight}");
                    }
                    else if (key.Modifiers == ConsoleModifiers.Shift && key.Key == ConsoleKey.DownArrow)
                    {
                        airplane.ShiftHeightDown();
                        WriteLine($"\nВысота: {airplane.CurrentHeight }");
                    }
                    else if (key.Modifiers == ConsoleModifiers.Shift && key.Key == ConsoleKey.RightArrow)
                    {
                        airplane.ShiftSpeedUP();
                        WriteLine($"\nСкорость: { airplane.CurrentSpeed}");
                    }
                    else if (key.Modifiers == ConsoleModifiers.Shift && key.Key == ConsoleKey.LeftArrow)
                    {
                        airplane.ShiftSpeedDown();
                        WriteLine($"\nСкорость: {airplane.CurrentSpeed }");
                    }

                }

            } while (airplane.CurrentSpeed >= 0);

        }

    }
}
