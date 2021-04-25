using System;
using System.Collections.Generic;
using System.Text;
using UncyclOS.Core;
using UncyclOS.Hardware;
using UncyclOS.Graphics;

namespace UncyclOS.Commands
{
    public class CMDShutdown : Command
    {
        public CMDShutdown()
        { 
            this.Name = "EXIT";
            this.Help = "Turn off the computer";
        }

        public override void Execute(string line, string[] args)
        {
            Cosmos.System.Power.Shutdown();
        }
    }
}
