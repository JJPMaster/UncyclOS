using System;
using System.Collections.Generic;
using System.Text;
using UncyclOS.Core;
using UncyclOS.Hardware;
using UncyclOS.Graphics;

namespace UncyclOS.Commands
{
    public class CMDInfo : Command
    {
        public CMDInfo()
        {
            this.Name = "INFO";
            this.Help = "Shows operating system and hardware information";
        }

        public override void Execute(string line, string[] args)
        {
            CLI.WriteLine("");
            SystemInfo.ShowInfo();
        }
    }
}
