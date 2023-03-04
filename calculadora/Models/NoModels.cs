using System;
namespace calculadora.Models
{
    public class NoModels
    {
        public Nullable<char> operation;
        public NoModels left, right;
        public double number;

        public NoModels()
        {
            operation = null;
            left = null;
            right = null;
            number = 0;
        }
    };
}

