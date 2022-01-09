using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{ 
    class Programm
    {
        //Decorator

        abstract class Candle
        {
            public Candle(string n)
            {
                this.Name = n;
            }
            public string Name { get; protected set; }
        }

        class Beeswax : Candle
        {
            public Beeswax() : base("beeswax candle")
            { }
        }

        class SoyWax : Candle
        {
            public SoyWax() : base("soy wax candle")
            { }
        }

        abstract class decorator : Candle
        {
            protected Candle candle;
            public decorator(string n, Candle candle) : base(n)
            {
                this.candle = candle;
            }
        }

        class Perfume : decorator
        {
            public Perfume(Candle candle) : base("perfumed " + candle.Name, candle)
            { }
        }

        class AddGlitter : decorator
        {
            public AddGlitter(Candle candle) : base(candle.Name + " with glitter", candle)
            { }
        }
        static void Main(string[] args)
        {
            Candle candle_1 = new Beeswax();
            candle_1 = new AddGlitter(candle_1);
            Console.WriteLine(candle_1.Name);
            Candle candle_2 = new SoyWax();
            candle_2 = new Perfume(candle_2);
            Console.WriteLine(candle_2.Name);
            Candle candle_3 = new SoyWax();
            candle_3 = new AddGlitter(new Perfume(candle_3));
            Console.WriteLine(candle_3.Name);
        }
    }
}