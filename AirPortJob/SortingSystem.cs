using System;
using System.Collections.Generic;
using System.Text;

namespace AirPortJob
{
    class SortingSystem
    {
        public static readonly object _lock = new object();
        private static SortingSystem instance;
        private SortingSystem()
        {

        }
        public static SortingSystem GetSortingSystem()
        {
            lock (_lock)
            {

                if (instance == null)
                {
                    instance = new SortingSystem();
                }
                return instance;
            }
        }

        public void SortBagage(Bagage bag, Terminal[] terminals)
        {
            for (int i = 0; i < terminals.Length; i++)
            {

                if (bag.Destination == terminals[i].destination)
                {
                    for (int j = 0; j < terminals[i].bagageBuffer.Length; j++)
                    {

                        if (terminals[i].bagageBuffer[j] == null)
                        {

                            terminals[i].bagageBuffer[j] = bag;
                            return;
                        }
                        
                    }
                }
            }

        }
    }
}
