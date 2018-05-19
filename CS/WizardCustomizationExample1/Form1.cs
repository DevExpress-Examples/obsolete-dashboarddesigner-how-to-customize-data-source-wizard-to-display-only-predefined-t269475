using DevExpress.DataAccess;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.XtraBars.Ribbon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WizardCustomizationExample1 {
    public partial class Form1 : RibbonForm {
        public Form1() {
            InitializeComponent();
            dashboardDesigner1.DataSourceWizardCustomization = new DataSourceWizardCustomization();
            MsSqlConnectionParameters cpNorthwind = new MsSqlConnectionParameters() {
                ServerName = "localhost",
                AuthorizationType = MsSqlAuthorizationType.Windows,
                DatabaseName = "Northwind"
            };
            MsSqlConnectionParameters cpAdventureWorks = new MsSqlConnectionParameters() {
                ServerName = "localhost",
                AuthorizationType = MsSqlAuthorizationType.Windows,
                DatabaseName = "AdventureWorksDW2012"
            };

            MsSqlConnectionParameters cpContosoRetail = new MsSqlConnectionParameters() {
                ServerName = "localhost",
                AuthorizationType = MsSqlAuthorizationType.Windows,
                DatabaseName = "ContosoRetailDW"
            };
            

            dashboardDesigner1.CustomDataConnections.Add(new DataConnection("Local Northwind Connection", cpNorthwind));
            dashboardDesigner1.CustomDataConnections.Add(new DataConnection("Local AdventureWorks Connection", cpAdventureWorks));
            dashboardDesigner1.CustomDataConnections.Add(new DataConnection("Local ContosoRetail Connection", cpContosoRetail));
        }
    }
}
