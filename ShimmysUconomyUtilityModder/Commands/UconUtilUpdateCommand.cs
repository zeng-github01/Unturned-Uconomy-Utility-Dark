using System;
using System.Collections.Generic;
using Rocket.API;

namespace ShimmysUconomyUtilityModder.Commands
{
    public class UconUtilUpdateCommand : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Console;

        public string Name => "UconUtilUpdate";

        public string Help => "Updates the modded table";

        public string Syntax => Name;

        public List<string> Aliases => new List<string>();

        public List<string> Permissions => new List<string>() { Name + "." + Name };

        public void Execute(IRocketPlayer caller, string[] command)
        {
            Console.WriteLine("starting update, this may take a little time.");
            _ = main.Instance.RunUpdate();
        }
    }
}