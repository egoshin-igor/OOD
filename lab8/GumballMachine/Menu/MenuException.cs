﻿using System;

namespace GumballMachine.Menu
{
    public class MenuException : ApplicationException
    {
        public MenuException()
            : base( "Incorrect command. Type help to show possible commands" )
        {
        }

        public MenuException( string message )
            : base( message )
        {
        }
    }
}
