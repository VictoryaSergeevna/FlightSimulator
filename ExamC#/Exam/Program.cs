using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using static System.Console;
namespace Flight_simulator_pilot
{

    class Program
    {
        private static void ShowMessage(object sender, MyEventArgs e)
        {
            WriteLine(e.message);
        }


        static void Main(string[] args)
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            string nameAirplane, nameFistDisp, nameSecondDisp;
            int N1, N2;
            N1 = rnd.Next(-200, +200);
            N2 = rnd.Next(-200, +200);
            Write("Введите ваше имя: ");
            nameAirplane = ReadLine();
            Clear();
            Write("Введите имя первого диспетчера: ");
            nameFistDisp = ReadLine();
            WriteLine();
            Write("Введите имя второго диспетчера: ");
            nameSecondDisp = ReadLine();
            WriteLine();
            Fly fly = new Fly(nameAirplane, nameFistDisp, N1, nameSecondDisp, N2);
            fly.airplane.FirstDisp.recomendation(fly.airplane.CurrentSpeed, fly.airplane.CurrentHeight);
            fly.airplane.SecondDisp.recomendation(fly.airplane.CurrentSpeed, fly.airplane.CurrentHeight);
            Clear();
            fly.startFlying += ShowMessage;
            fly.finishFlying += ShowMessage;
            fly.initStart();
            ReadKey();
            fly.takeOffAirplane();
            fly.landingAirplane();
            fly.initFinish();
            Thread.Sleep(1000);
            fly.startFlying -= ShowMessage;
            fly.finishFlying -= ShowMessage;
        }
    }
}

   
    

    

    

    
       


