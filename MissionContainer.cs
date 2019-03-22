using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{

    // deledate which recieve double and return double.
    public delegate double MyDelegate(double d);

    public class FunctionsContainer {

        // dictionary keeping the name of the function and the function.
        Dictionary<string, MyDelegate> dict;

        //constructor. initialize the dictionary.
        public FunctionsContainer() {
            dict = new Dictionary<string, MyDelegate>();
        }

        // return a list of the names of the functions.
        public List<string> getAllMissions() {
            return dict.Keys.ToList();
        }

        /*
         * indexer. receive string (name of the function) and return the function 
         * (delegate - recieve double and return double).
         */
        public MyDelegate this[string idx] {
            // getter - if the value already in the dictionary return it. else, adding a new pair, 
            // the name and function that return the same value.
            get {
                if (!dict.ContainsKey(idx)) {
                    dict.Add(idx, val => val);
                    return val => val;
                }
                return dict[idx];
        }
            // setter - addind the dictionary a new pair or changing existing one.
            set
            {
                dict[idx] = value;
            }
        }
    }
}
