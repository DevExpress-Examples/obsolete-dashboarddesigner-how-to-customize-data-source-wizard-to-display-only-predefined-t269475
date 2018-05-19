Imports Microsoft.VisualBasic
Imports DevExpress.DataAccess
Imports DevExpress.DataAccess.ConnectionParameters
Imports DevExpress.XtraBars.Ribbon
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms

Namespace WizardCustomizationExample1
	Partial Public Class Form1
		Inherits RibbonForm
		Public Sub New()
			InitializeComponent()
			dashboardDesigner1.DataSourceWizardCustomization = New DataSourceWizardCustomization()
			Dim cpNorthwind As New MsSqlConnectionParameters() With {.ServerName = "localhost", .AuthorizationType = MsSqlAuthorizationType.Windows, .DatabaseName = "Northwind"}
			Dim cpAdventureWorks As New MsSqlConnectionParameters() With {.ServerName = "localhost", .AuthorizationType = MsSqlAuthorizationType.Windows, .DatabaseName = "AdventureWorksDW2012"}

			Dim cpContosoRetail As New MsSqlConnectionParameters() With {.ServerName = "localhost", .AuthorizationType = MsSqlAuthorizationType.Windows, .DatabaseName = "ContosoRetailDW"}


			dashboardDesigner1.CustomDataConnections.Add(New DataConnection("Local Northwind Connection", cpNorthwind))
			dashboardDesigner1.CustomDataConnections.Add(New DataConnection("Local AdventureWorks Connection", cpAdventureWorks))
			dashboardDesigner1.CustomDataConnections.Add(New DataConnection("Local ContosoRetail Connection", cpContosoRetail))
		End Sub
	End Class
End Namespace
