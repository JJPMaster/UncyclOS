using System;
using System.Collections.Generic;
using System.Text;
using UncyclOS.Core;
using UncyclOS.Hardware;
using UncyclOS.Graphics;

namespace UncyclOS.Commands
{
    public class CMDEcho : Command
    {
        public CMDEcho() 
        {
            this.Name = "PRINT";
            this.Help = "Prints a line of input to the screen";
            this.Usage = "Usage: echo [text]";
        }

        public override void Execute(string line, string[] args)
        {
            CLI.WriteLine(line.Substring(5, line.Length - 5));
        }
    }
}
