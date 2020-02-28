using System;
using System.Collections.Generic;
using System.Text;

namespace AirPortJob
{
    class BagageFactory
    {
        int bagageCount = 0;

        public Bagage GenerateBags()
        {
            Bagage bagages;


            bagageCount++;
            bagages = new Bagage("Person " + bagageCount);
            return bagages;
        }
    }
}
