﻿using System;
using System.Collections.Generic;
using System.Text;
using UncyclOS.Core;
using UncyclOS.Hardware;
using UncyclOS.Graphics;

namespace UncyclOS.Commands
{
    public class CMDMakeDir2 : Command
    {
        public CMDMakeDir2()
        {
            this.Name = "MD";
            this.Help = "Alias for MKDIR";
        }

        public override void Execute(string line, string[] args)
        {
            bool success = false;
            string path = "";
            if (line.Length > 3)
            {
                path = line.Substring(3, line.Length - 3);
                if (path.EndsWith('\\')) { path = path.Remove(path.Length - 1, 1); }
                path += "\\";

                    if (path.StartsWith(PMFAT.CurrentDirectory)) { PMFAT.CreateFolder(path); success = true; }
                    else if (path.StartsWith(@"0:\")) { PMFAT.CreateFolder(path); success = true; }
                    else if (!path.StartsWith(PMFAT.CurrentDirectory) && !path.StartsWith(@"0:\"))
                    {
                        PMFAT.CreateFolder(PMFAT.CurrentDirectory + path);
                        success = true;
                    }
                else { CLI.WriteLine("Could not locate directory!", Color.Red); }
            }
            else { CLI.WriteLine("Invalid argument! Path expected.", Color.Red); }

            if (success) { CLI.WriteLine("Successfully created directory \"" + path + "\"", Color.Green); }
        }
    }
}