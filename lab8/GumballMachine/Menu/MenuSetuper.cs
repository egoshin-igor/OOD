using System;
using GumballMachine.Menu.Util;

namespace GumballMachine.Menu
{
    public class MenuSetuper
    {
        private readonly IGumbalMachine _machine;

        public MenuSetuper()
        {
            _machine = new GumbalMachineWithState.GumballMachine( ballsCount: 0 );
        }

        public Menu GetSetuped()
        {
            Menu menu = new Menu();

            menu.AddItem(
                shortcut: "Help",
                description: "Print <Help> to show command info",
                ( arguments ) => Console.WriteLine( menu.GetCommandsInfo() )
            );

            menu.AddItem(
                shortcut: "BallsCount",
                description: "Print <BallsCount> to show gumbles count in the machine",
                ( args ) => Console.WriteLine( $"Balls count: {_machine.BallsCount}" )
            );

            menu.AddItem(
                shortcut: "QuartersCount",
                description: "Print <QuartersCount> to show quarters count in the machine",
                ( args ) => Console.WriteLine( $"Quarters count: {_machine.QuartersCount}" )
            );

            menu.AddItem(
                shortcut: "MaxQuartersCount",
                description: "Print <MaxQuartersCount> to show max quarters count in the machine",
                ( args ) => Console.WriteLine( $"Max quarters count: {_machine.MaxQuartersCount}" )
            );

            menu.AddItem(
                shortcut: "InsertQuarter",
                description: "Print <InsertQuarter> to insert quarter into the machine",
                ( args ) => _machine.InsertQuarter()
            );

            menu.AddItem(
                shortcut: "EjectQuarter",
                description: "Print <EjectQuarter> to eject quarter from the machine",
                ( args ) => _machine.EjectQuarter()
            );

            menu.AddItem(
                shortcut: "TurnCrank",
                description: "Print <TurnCrank> to turn crank at the machine",
                ( args ) => _machine.TurnCrank()
            );

            menu.AddItem(
                shortcut: "AddBalls",
                description: "Print <AddBalls> <BallsCount> to add balls at the machine",
                AddBalls
            );

            return menu;
        }

        private void AddBalls( string args )
        {
            var argumentsParser = new ArgumentsParser( args );
            if ( argumentsParser.NextArgumentsCount < 1 )
            {
                throw new MenuException();
            }

            int? ballsCount = argumentsParser.GetNextAsInt();
            if ( ballsCount == null || ballsCount < 0 )
            {
                throw new MenuException();
            }

            _machine.AddBalls( ( uint )ballsCount.Value );
        }
    }
}
