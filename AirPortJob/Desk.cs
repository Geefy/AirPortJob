using System;
using System.Collections.Generic;
using System.Text;

namespace AirPortJob
{
    class Desk
    {
        string deskName;
        Random rnd = new Random(DateTime.Now.Millisecond);
        Destination destination;
        public Bagage[] bagageBuffer = new Bagage[15];
        

        public Desk(int deskNumber)
        {
            this.deskName = "Desk " + deskNumber;
        }

        public Destination DestinationId { get => destination; set => destination = value; }


        //Generates a random baganumber with a prefix using destination
        public string GenerateBagageNumber()
        {
            string bagageNumber;
            bagageNumber = destination + rnd.Next(0000, 9999).ToString();
            return bagageNumber;
        }

        //Sets bagage destination and bagagenumber
        public void HandleBagage()
        {


            for (int i = 0; i < bagageBuffer.Length; i++)
            {
                if (bagageBuffer[i] != null)
                {

                bagageBuffer[i].Destination = destination;

                bagageBuffer[i].BagageNumber = GenerateBagageNumber();
                }
            }


        }
    }
}
