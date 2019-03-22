using System;

namespace Excercise_1 {
    public class SingleMission : IMission {

        private string nameOfMission;

        // delegate receive double and return double.
        private MyDelegate deleg;

        public event EventHandler<double> OnCalculate;

        private string type = "Single";

        // constractor for SingleMission, receive the name of the mission and the function.
        public SingleMission(MyDelegate d, string s) {
            deleg += d;
            nameOfMission = s;
        }

        string IMission.Name {
            get {
                return nameOfMission;
            }
        }

        string IMission.Type { get { return type; } }

        // calculate the function with the value.
        public double Calculate(double value) {
            // calculate the new value.
            double newVal = deleg(value);
            // invoke the other events.
            OnCalculate?.Invoke(this, newVal);
            return newVal;
        }
    }
}
