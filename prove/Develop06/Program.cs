/* To exceed requirements I added a level function to the goal manager which has a points bar 
    and adds diamonds each time the player levels up. The save option also saves the level and points*/
using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();
        goalManager.Start();
    }
}