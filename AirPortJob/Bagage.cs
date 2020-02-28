using System;
using System.Collections.Generic;
using System.Text;

namespace AirPortJob
{
    class Bagage
    {
        string bagageNumber;
        string bagageOwner;
        Destination destination;

        public Bagage(string bagageOwner)
        {
            this.bagageOwner = bagageOwner;
        }

        public Destination Destination { get => destination; set => destination = value; }
        public string BagageNumber { get => bagageNumber; set => bagageNumber = value; }
    }
}
