using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLib
{
    [Serializable]
    public class Car
    {
        private string _model;

        public string Model
        {
            get { return _model; }
            set { _model = value; }
        }

        private string _color;

        public string Color
        {
            get { return _color; }
            set { _color = value; }
        }

        private string _registrationnumber;

        public string Registrationnumber
        {
            get { return _registrationnumber; }
            set { _registrationnumber = value; }
        }

        public Car()
        {
            
        }

        public Car(string model, string color, string registrationnumber)
        {
            _model = model;
            _color = color;
            _registrationnumber = registrationnumber;
        }

        public override string ToString()
        {
            return "Car: Model: " + _model + " Color: " + _color + " Regnumber: " + _registrationnumber;
        }
    }
}
