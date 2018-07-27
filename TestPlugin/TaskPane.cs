using System.Runtime.InteropServices;
using System.Windows.Forms;
using AngelSix.SolidDna;

namespace TestPlugin
{
    [ProgId(TaskPaneId)]
    public partial class TaskPane : UserControl, ITaskpaneControl
    {
        private const string TaskPaneId = "Test.Plugin.Pane";

        public TaskPane()
        {
            InitializeComponent();
        }

        public string ProgId => TaskPaneId;
    }
}
