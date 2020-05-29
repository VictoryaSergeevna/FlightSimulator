using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Flight_simulator_pilot
{
    public class Dispatcher
    {
        public string NameDisp { set; get; }
        public int N { set; get; }
        int penaltyPoints;//штраф.очки
        int recomHeight;//рекоменд. высота 


        public int RecomHeight
        {
            set { this.recomHeight = value; }
            get { return recomHeight; }
        }


        public int PenaltyPoints
        {
            set { this.penaltyPoints = value; }
            get { return penaltyPoints; }
        }


        public Dispatcher()
        {
            NameDisp = "def";
            N = 0;
            penaltyPoints = 0;
            recomHeight = 0;
        }
        public Dispatcher(string name, int N)
        {
            this.NameDisp = name;
            this.N = N;
        }

        public void recomendation(int currentSpeed, int currentHeight)
        {
            RecomHeight = 7 * currentSpeed - N;
            if ((currentHeight - RecomHeight) > 300 && (currentHeight - RecomHeight) < 601)
            {
                PenaltyPoints += 25;
            }
            else if ((currentHeight - RecomHeight) > 600 && (currentHeight - RecomHeight) < 1001)
            {
                PenaltyPoints += 50;
            }
            else if ((currentHeight - RecomHeight) > 1001)
            {
                Clear();
                WriteLine("\tОпасность!");
                for (int i = 0; i < 1000000000; i++) { }
                WriteLine("\tСамолет снижает высоту!");
                for (int i = 0; i < 1000000000; i++) { }
                WriteLine("\tСамолет разбился!");
                Environment.Exit(0);
            }
            else if ((RecomHeight - currentHeight) > 300 && (RecomHeight - currentHeight) < 601)
            {
                PenaltyPoints += 25;
            }
            else if ((RecomHeight - currentHeight) > 600 && (RecomHeight - currentHeight) < 1001)
            {
                PenaltyPoints += 50;
            }
        }

        public override string ToString()
        {
            return $"{NameDisp}, рекомендованная высота: {RecomHeight}.\n Ваши штрафные очки от диспетчера: {NameDisp} = {PenaltyPoints} ";
        }

    }
}
