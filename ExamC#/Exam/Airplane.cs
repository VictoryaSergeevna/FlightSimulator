using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;


namespace Flight_simulator_pilot
{

    public class Airplane : IdangerSimulator
    {
        public event MyEventHandler startFlying;
        public event MyEventHandler finishFlying;
        public event MyEventHandler dangerSpeed;
        public event MyEventHandler dangerHeight;
        public Dispatcher FirstDisp = null;
        public Dispatcher SecondDisp = null;
        string NameAirplane { set; get; }
        int maxSpeed = 1000, maxHeight = 10000;
        int currentSpeed = 0, currentHeight = 0, sum = 0;
        int penaltyPoints = 0;

        public int MaxSpeed
        {
            set { this.maxSpeed = value; }
            get { return maxSpeed; }

        }

        public int CurrentSpeed
        {
            set { this.currentSpeed = value; }
            get { return currentSpeed; }
        }
        public int MaxHeight
        {
            set { this.maxHeight = value; }
            get { return maxHeight; }

        }

        public int CurrentHeight
        {
            set { this.currentHeight = value; }
            get { return currentHeight; }
        }

        public int PenaltyPoints
        {
            set { this.penaltyPoints = value; }
            get { return penaltyPoints; }

        }

        public Airplane() { }
        public Airplane(string NameAirplane, string firstName, int N1, string secondName, int N2)
        {
            currentSpeed = 0;
            currentHeight = 0;
            sum = 0;
            penaltyPoints = 0;
            this.NameAirplane = NameAirplane;
            FirstDisp = new Dispatcher(firstName, N1);
            SecondDisp = new Dispatcher(secondName, N2);
        }


        public void totalPenaltyPoints(Dispatcher D1, Dispatcher D2)
        {
            if (PenaltyPoints >= 1000)
            {
                Clear();
                WriteLine("\tПлохой пилот!");
                Environment.Exit(0);
            }
            else
            {
                PenaltyPoints = D1.PenaltyPoints + D2.PenaltyPoints;
                if (sum == PenaltyPoints)
                {
                    PenaltyPoints = sum;
                }
                else
                {
                    sum = PenaltyPoints;
                }
            }
        }

        public void speedUP()
        {
            CurrentSpeed += 50;
            if (CurrentSpeed > MaxSpeed)
            {
                if (dangerSpeed != null)
                {
                    dangerSpeed(this, new MyEventArgs("Скорость привысила допустимую!"));
                }
            }
        }

        public void speedDown()
        {
            CurrentSpeed -= 50;
            if (CurrentSpeed < MaxSpeed)
            {
                if (dangerSpeed != null)
                {
                    dangerSpeed(this, new MyEventArgs("Скорость меньше допустимой!"));
                }
            }
        }

        public void ShiftSpeedUP()
        {
            CurrentSpeed += 150;
            if (CurrentSpeed > MaxSpeed)
            {
                if (dangerSpeed != null)
                {
                    dangerSpeed(this, new MyEventArgs("Скорость привысила допустимую!"));
                }
            }
        }

        public void ShiftSpeedDown()
        {
            CurrentSpeed -= 150;
            if (CurrentSpeed < MaxSpeed)
            {
                if (dangerSpeed != null)
                {
                    dangerSpeed(this, new MyEventArgs("Скорость меньше допустимой!"));
                }
            }
        }

        public void heightUP()
        {
            CurrentHeight += 250;
            if (CurrentHeight > MaxHeight)
            {
                if (dangerHeight != null)
                {
                    dangerHeight(this, new MyEventArgs("Высота полета привысила допустимую!"));
                }
            }
        }

        public void heightDown()
        {
            CurrentHeight -= 250;
            if (CurrentHeight < MaxHeight)
            {
                if (dangerHeight != null)
                {
                    dangerHeight(this, new MyEventArgs("Высота полета меньше допустимой!"));
                }
            }
        }

        public void ShiftHeightUP()
        {
            CurrentHeight += 500;
            if (CurrentHeight > MaxHeight)
            {
                if (dangerHeight != null)
                {
                    dangerHeight(this, new MyEventArgs("Высота полета привысила допустимую!"));
                }
            }
        }

        public void ShiftHeightDown()
        {
            CurrentHeight -= 500;
            if (CurrentHeight < MaxHeight)
            {
                if (dangerSpeed != null)
                {
                    dangerHeight(this, new MyEventArgs("Высота полета меньше допустимой!"));
                }
            }
        }

        public override string ToString()
        {
            return $"Ваша текущая скорость: { CurrentSpeed },  \n" +
               $"ваша текущая высота: { CurrentHeight }";
        }

    }
}
