using System;
using System.Collections.Generic;
using System.Text;
using UncyclOS.Hardware;
using UncyclOS.Graphics;

namespace UncyclOS.Core
{
    public static class Shell
    {
        // configuration
        public static Color TitleBarColor = Color.DarkMagenta;
        public static Color DateTimeColor = Color.White;
        public static Color TitleColor = Color.Magenta;
        public static bool TitleBarVisible = true;
        public static string TitleBarText = "UncyclOS Shell: That one OS...";
        public static string TitleBarTime = RTC.GetDateFormatted() + " " + RTC.GetTimeFormatted();

        // command list
        public static List<Command> Commands = new List<Command>();

        // initialize
        public static void Initialize()
        {
            // add commands
            AddCommands();

            // load config
            SystemInfo.LoadConfig(PMFAT.ConfigFile, true);

            // clear 
            DrawFresh();

            // show info
            SystemInfo.ShowInfo();
        }

        // populate command list
        private static void AddCommands()
        {
            // system
            Commands.Add(new Commands.CMDClear());
            Commands.Add(new Commands.CMDEcho());
            Commands.Add(new Commands.CMDColors());
            Commands.Add(new Commands.CMDDevInfo());
            Commands.Add(new Commands.CMDInfo());
            Commands.Add(new Commands.CMDHelp());
            Commands.Add(new Commands.CMDReboot());
            Commands.Add(new Commands.CMDShutdown());

            // config
            Commands.Add(new Commands.CMDForeColor());
            Commands.Add(new Commands.CMDBackColor());
            Commands.Add(new Commands.CMDTitleBarColor());
            Commands.Add(new Commands.CMDTitleColor());
            Commands.Add(new Commands.CMDTimeColor());
            Commands.Add(new Commands.CMDTitleBar());

            // file system
            Commands.Add(new Commands.CMDSetDir());
            Commands.Add(new Commands.CMDListDir());
            Commands.Add(new Commands.CMDMakeDir());
            Commands.Add(new Commands.CMDMakeDir2());
            Commands.Add(new Commands.CMDDelDir());
            Commands.Add(new Commands.CMDDelDir2());
            Commands.Add(new Commands.CMDCutFile());
            Commands.Add(new Commands.CMDCopyFile());
            Commands.Add(new Commands.CMDDelFile());

            // programs
            Commands.Add(new Commands.CMDEdit());
            Commands.Add(new Commands.CMDRun());
            Commands.Add(new Commands.CMDAsm());
        }

        // clear screen, draw title bar, set cursor pos
        public static void DrawFresh()
        {
            // clear screen
            TextGraphics.Clear(CLI.BackColor);

            // draw title bar
            if (TitleBarVisible) { DrawTitleBar(); CLI.SetCursorPos(0, 2); }
            else { CLI.SetCursorPos(0, 0); }
        }

        // draw title bar
        public static void DrawTitleBar()
        {
            TextGraphics.DrawLineH(0, 0, CLI.Width, ' ', Color.Black, TitleBarColor); // draw background
            DrawTime(); // draw time
            TextGraphics.DrawString(CLI.Width - TitleBarText.Length, 0, TitleBarText, TitleColor, TitleBarColor); // draw title
        }

        // draw time
        public static void DrawTime() { TextGraphics.DrawString(0, 0, TitleBarTime, DateTimeColor, TitleBarColor); }

        // begin accepting commands
        public static void GetInput()
        {
            // reset title
            TitleBarText = "UncyclOS Shell: That one OS...";

            // draw input pointer
            if (PMFAT.CurrentDirectory == @"0:\") { CLI.Write("root@UncyclOS", Color.Magenta); CLI.Write(":-$ ", Color.White); }
            else
            {
                CLI.Write("root", Color.Magenta); CLI.Write("@", Color.White);
                CLI.Write(PMFAT.CurrentDirectory.Substring(3, PMFAT.CurrentDirectory.Length - 3), Color.Yellow);
                CLI.Write(":- ", Color.White);
            }

            // get input
            string input = CLI.ReadLine();
            ParseCommand(input);
        }

        // parse command
        private static void ParseCommand(string line)
        {
            // if a command has actually been enter
            if (line.Length > 0)
            {
                string[] args = line.Split(' ');
                bool error = true;
                for (int i = 0; i < Commands.Count; i++)
                {
                    // validate command
                    if (args[0].ToUpper() == Commands[i].Name)
                    {
                        // execute and finish
                        Commands[i].Execute(line, args);
                        error = false;
                        break;
                    }
                }

                // invalid command has been entered
                if (error) { CLI.WriteLine("Bad command or file name!", Color.Red); }
            }

            // continue fetching commands
            DrawTitleBar();
            GetInput();
        }

        // get command from list based on name
        public static Command GetCommand(string cmd)
        {
            for (int i = 0; i < Commands.Count; i++)
            {
                if (Commands[i].Name == cmd.ToUpper()) { return Commands[i]; }
            }
            return null;
        }
    }
}
