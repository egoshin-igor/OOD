using System;
using GumballMachine.Menu;

namespace GumballMachine
{
    class Program
    {
        static void Main( string[] args )
        {
            var menuSetuper = new MenuSetuper();
            Run( menuSetuper.GetSetuped() );
        }

        private static void Run( Menu.Menu menu )
        {
            var isExit = false;
            menu.Execute( "Help" );

            while ( !isExit )
            {
                string command = Console.ReadLine();
                if ( command.ToLower() == "exit" )
                {
                    break;
                }

                try
                {
                    menu.Execute( command );
                }
                catch ( MenuException ex )
                {
                    Console.WriteLine( ex.Message );
                }
            }
        }
    }
}
