using DevExpress.DataAccess;
using DevExpress.DataAccess.Native;
using DevExpress.DataAccess.Sql;
using DevExpress.DataAccess.UI.Native;
using DevExpress.DataAccess.UI.Wizard.Views;
using DevExpress.DataAccess.Wizard.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WizardCustomizationExample1
{
    public partial class CustomChooseConnectionPageView : WizardViewBase, IChooseConnectionPageView
    {
        private DevExpress.XtraEditors.ListBoxControl lbConnections;
        bool anyExceptions = false;

        public CustomChooseConnectionPageView(IEnumerable<SqlDataConnection> connections)
        {
            InitializeComponent();
            lbConnections.SelectedIndexChanged += listBoxControl1_SelectedIndexChanged;
            lbConnections.DisplayMember = "Name";
            var targetConnections = connections.Where(c => c is DataConnection).ToList();
            lbConnections.DataSource = targetConnections;            
        }

        void listBoxControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Changed != null)
                Changed(this, new EventArgs());
        }

        public override string HeaderDescription
        {
            get { return "Choose one connection from the list."; }
        }
        public event EventHandler Changed;

        public string ExistingConnectionName
        {
            get { return ((INamedItem)lbConnections.SelectedItem).Name; }
        }

        public void SetSelectedConnection(INamedItem connection)
        {
            if (connection != null)
            {
                lbConnections.SelectedItem = connection;
            }
        }

        public bool ShouldCreateNewConnection { get { return false; } }

        public IWaitFormActivator WaitFormActivator
        {
            get { return new WaitFormActivator(FindForm(), typeof(WaitFormWithCancel), true); }
        }

        public bool AnyExceptions { get { return anyExceptions; } }

        public void HandleException(Exception exception)
        {
            MessageBox.Show(exception.Message);
        }
    }    
}
