﻿using StardewModdingAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplayerMod.Framework.Command
{
    internal class CommandManager
    {
        public List<ICommand> Commands = new List<ICommand>();
        public CommandManager() 
        {
            AddCommand(new ClientConnectMenuCommand());
        }

        public void Apply(IModHelper modHelper) 
        { 
            foreach (var command in Commands)
            {
                modHelper.ConsoleCommands.Add(command.Name , command.Description , command.Execute);
            }
        }

        public void AddCommand(ICommand command)
        {
            Commands.Add(command);
        }
        public void RemoveCommand(ICommand command)
        {
            Commands.Remove(command);
        }
        public void Clear()
        {
            Commands.Clear();
        }
        public ICommand GetCommand(string name)
        {
            var listCmd = Commands.Where(p => p.Name == name).ToList();
            if(listCmd.Count() > 0 )
            {
                return listCmd[0];
            }
            throw new NullReferenceException();
        }
    }
}
