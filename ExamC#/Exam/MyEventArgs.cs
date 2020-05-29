using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace Flight_simulator_pilot
{
    public delegate void MyEventHandler(object sender, MyEventArgs e);

    interface IdangerSimulator
    {
        event MyEventHandler startFlying;
        event MyEventHandler finishFlying;
        event MyEventHandler dangerSpeed;
        event MyEventHandler dangerHeight;
    }
    public class MyEventArgs
    {
        public string message;
        public MyEventArgs(string message)
        {
            this.message = message;

        }
    }
}
