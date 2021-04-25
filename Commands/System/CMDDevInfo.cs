using System;
using System.Collections.Generic;
using System.Text;
using UncyclOS.Core;
using UncyclOS.Hardware;
using UncyclOS.Graphics;

namespace UncyclOS.Commands
{
    public class CMDDevInfo : Command
    {
        public CMDDevInfo()
        {
            this.Name = "CREDITS";
            this.Help = "This operating system's credits";
        }

        public override void Execute(string line, string[] args)
        {
            CLI.Write("\n");
            CLI.Write("DEVELOPERS: \n JJPMaster (aka JJP): Lead development \n napalmtorch: The writer of a lot of the programs that were ported onto this OS \nSPECIAL THANKS: \n Kev: The person who actually motivated me to turn 'Uncyclux' into a real thing \n David Gerard and SonicChao: The original creators of the 'Command Line' Uncyclopedia article that inspired this OS \n\nA RANDOM OTHER PERSON: \n Gale5050. \n");
        }
    }
}
