using System;
using System.Collections.Generic;
using System.Text;
using UncyclOS.Core;
using UncyclOS.Hardware;
using UncyclOS.Graphics;

namespace UncyclOS.Commands
{
    public class CMDReboot : Command
    {
        public CMDReboot() 
        {
            this.Name = "REBOOT";
            this.Help = "Reboots the computer";
        }

        public override void Execute(string line, string[] args)
        {
            Cosmos.System.Power.Reboot();
        }
    }
}
