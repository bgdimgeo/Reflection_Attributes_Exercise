﻿using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Commands
{
    public class ErrorCommand : ICommand
    {
        public string Execute(string[] args)
        {
            return $"Unexpected error occured";
        }
    }
}
