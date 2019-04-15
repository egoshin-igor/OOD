using System;
using Command.Document;
using Command.Menu;

namespace Command
{
    class Program
    {
        static void Main( string[] args )
        {
            var menu = new Menu.Menu();
            MenuSetup menuSetuper = new MenuSetup();
            menuSetuper.Setup( menu );

            Run( menu );
        }

        private static void Run( Menu.Menu menu )
        {
            var isExit = false;

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
                catch ( DocumentException ex )
                {
                    Console.WriteLine( ex.Message );
                }
            }
        }
    }
}
