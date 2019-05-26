using System.Windows.Forms;

namespace Chart.View.MainFormView
{
    public class HarmonicsListViews
    {
        public ListBox HarmonicsListBox { get; }
        public Button DeleteSelectedButton { get; }
        public Button AddNewButton { get; }

        public HarmonicsListViews( ListBox harmonicsListBox, Button deleteSelectedButton, Button addNewButton )
        {
            HarmonicsListBox = harmonicsListBox;
            DeleteSelectedButton = deleteSelectedButton;
            AddNewButton = addNewButton;
        }
    }
}
