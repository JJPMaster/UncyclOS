﻿using System;
using System.Collections.Generic;
using System.Text;
using UncyclOS.Core;
using UncyclOS.Hardware;
using UncyclOS.Graphics;

namespace UncyclOS.Commands
{
    public class CMDTitleBarColor : Command
    {
        public CMDTitleBarColor()
        {
            this.Name = "TBG";
            this.Help = "Change the title bar color";
        }

        public override void Execute(string line, string[] args)
        {
            int newColor = 40;
            string colString = "";
            if (args.Length == 2)
            {
                colString = args[1];
                newColor = (int)CLI.StringToColor(args[1]);
                if (newColor != 40) { Shell.TitleBarColor = (Color)newColor; CLI.WriteLine("Changed title bar back color to " + colString, Color.Green); }
                else { CLI.WriteLine(colString + " is not a valid color!", Color.Red); }
            }
            else { CLI.WriteLine("Invalid arguments!", Color.Red); }
            SystemInfo.SaveConfig(PMFAT.ConfigFile);
            if (Shell.TitleBarVisible) { Shell.DrawTitleBar(); }
        }
    }
}
