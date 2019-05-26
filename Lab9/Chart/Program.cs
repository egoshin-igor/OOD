using System;
using System.Windows.Forms;
using Chart.View.MainFormView;
using Chart.ViewModels;

namespace Chart
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault( false );
            var applicationViewModel = new MainFormViewModel();
            Application.Run( new MainForm( applicationViewModel ) );
        }
    }
}
