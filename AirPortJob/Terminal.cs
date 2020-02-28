using System;
using System.Collections.Generic;
using System.Text;

namespace AirPortJob
{
    public enum Destination
    {
        Russia,
        France,
        USA,
        Canada,
        Norway,
        Sweden,
        Egypt,
        Japan
    }

    class Terminal
    {
        public Destination destination;

        public Bagage[] bagageBuffer = new Bagage[15];
        public Terminal(Destination destination)
        {

            this.destination = destination;
        }
        public void ClearBagage()
        {
            for (int i = 0; i < bagageBuffer.Length; i++)
            {
                bagageBuffer[i] = null;
            }
        }

    }
}
