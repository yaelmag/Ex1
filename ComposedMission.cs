using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    public class ComposedMission : IMission {

        public event EventHandler<double> OnCalculate;

        // list of delegates, which we can calculate later.
        private List<MyDelegate> funcs = new List<MyDelegate>();

        //constructor. initialize the name of the mission.
        public ComposedMission(string name) {
            Name = name;
        }

        public string Type { get; } = "Composed";

        public string Name { get; }

        //add function to the composed mission.
        public ComposedMission Add(MyDelegate func) {
            funcs.Add(func);
            return this;
        }

        /*
         * calculate the functions within the value.
         * overrride the value, in each function who calculate. at the end we get the 
         * value of all functions.
         */
        public double Calculate(double value) {
            foreach (MyDelegate func in funcs)
            {
                value = func(value);
            }
            // invoke the events of the value.
            OnCalculate?.Invoke(this, value);
            return value;
        }
    }
}
