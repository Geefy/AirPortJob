﻿using System;
using System.Threading;

namespace AirPortJob
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread DeskThread = new Thread(AirportManager.GetAirportManager().GiveBagageToDesk);
            Thread SorterThread = new Thread(AirportManager.GetAirportManager().GiveBagageToSorter);
            Thread TerminalThread = new Thread(AirportManager.GetAirportManager().PlaneLeaveTerminal);
            AirportManager.GetAirportManager().bagageDesked += Desk_BagageDesked;
            AirportManager.GetAirportManager().bagageSorted += Sort_BagageSorted;
            DeskThread.Start();
           SorterThread.Start();
           TerminalThread.Start();
            Console.Read();
        }

        private static void Desk_BagageDesked(object sender, EventArgs e)
        {
            Desk desk = (Desk)sender;
            Console.WriteLine("Bagage with destionation: " + desk.DestinationId + " has been desked");
        }
        private static void Sort_BagageSorted(object sender, EventArgs e)
        {
            Desk desk = (Desk)sender;
            Console.WriteLine("Bagage with destionation: " + desk.DestinationId + " has been sorted");
        }
    }
}
