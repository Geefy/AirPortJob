using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AirPortJob
{
    class AirportManager
    {
        Terminal[] terminals = new Terminal[3];
        Desk[] desks = new Desk[3];
        BagageFactory factory = new BagageFactory();
        public static object _lock = new object();
        private static AirportManager instance;


        public event EventHandler bagageDesked;
        public event EventHandler bagageSorted;
        public event EventHandler bagageLeft;

        private AirportManager()
        {
            GenerateDestinationIds();
            for (int i = 0; i < desks.Length; i++)
            {
                desks[i] = new Desk(i);
            }
            for (uint i = 0; i < terminals.Length; i++)
            {
                terminals[i] = new Terminal(destinationIds.GetValueOrDefault(i));


                desks[i].DestinationId = destinationIds.GetValueOrDefault(i);

            }
        }
        public static AirportManager GetAirportManager()
        {
            lock (_lock)
            {

                if (instance == null)
                {
                    instance = new AirportManager();
                }
                return instance;
            }
        }

        public Dictionary<uint, Destination> destinationIds = new Dictionary<uint, Destination>();
        void GenerateDestinationIds()
        {
            Array enumValues = Enum.GetValues(typeof(Destination));
            for (uint i = 0; i < enumValues.Length; i++)
            {
                destinationIds.Add(i, (Destination)enumValues.GetValue(i));
            }
        }

        public void GiveBagageToDesk()
        {
            while (true)
            {
                lock (_lock)
                {

                    for (int i = 0; i < desks.Length; i++)
                    {
                        for (int j = 0; j < desks[i].bagageBuffer.Length; j++)
                        {
                            if (desks[i].bagageBuffer[j] == null)
                            {

                                desks[i].bagageBuffer[j] = factory.GenerateBags();


                                bagageDesked?.Invoke("Bagage with destionation: " + desks[i].DestinationId + " has been desked", new EventArgs());
                                Monitor.PulseAll(_lock);
                            }
                            else
                            {
                                Monitor.Wait(_lock);
                            }
                        }
                        desks[i].HandleBagage();
                    }
                }
            }
        }

        public void GiveBagageToSorter()
        {
            Bagage bagage;
            while (true)
            {
                lock (_lock)
                {
                    for (int i = 0; i < desks.Length; i++)
                    {
                        for (int j = 0; j < desks[i].bagageBuffer.Length; j++)
                        {
                            if (desks[i].bagageBuffer[j] != null)
                            {

                                bagage = desks[i].bagageBuffer[j];
                                SortingSystem.GetSortingSystem().SortBagage(bagage, terminals);
                                bagageSorted?.Invoke("Bagage with destionation: " + desks[i].DestinationId + " has been sorted", new EventArgs());
                                desks[i].bagageBuffer[j] = null;
                                Monitor.PulseAll(_lock);
                            }
                            else
                            {
                                Monitor.Wait(_lock);
                            }
                        }
                    }
                }
            }
        }

        public void PlaneLeaveTerminal()
        {
            while (true)
            {
                lock (_lock)
                {

                    Thread.Sleep(5000);
                    for (int i = 0; i < terminals.Length; i++)
                    {
                        terminals[i].ClearBagage();
                        Monitor.PulseAll(_lock);
                    }
                }
            }
        }
    }
}
