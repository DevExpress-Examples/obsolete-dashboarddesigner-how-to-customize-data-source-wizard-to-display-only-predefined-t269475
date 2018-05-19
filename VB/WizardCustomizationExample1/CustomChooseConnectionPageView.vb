Imports Microsoft.VisualBasic
Imports DevExpress.DataAccess
Imports DevExpress.DataAccess.Native
Imports DevExpress.DataAccess.Sql
Imports DevExpress.DataAccess.UI.Native
Imports DevExpress.DataAccess.UI.Wizard.Views
Imports DevExpress.DataAccess.Wizard.Views
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms

Namespace WizardCustomizationExample1
	Partial Public Class CustomChooseConnectionPageView
		Inherits WizardViewBase
		Implements IChooseConnectionPageView
		Private lbConnections As DevExpress.XtraEditors.ListBoxControl
		Private anyExceptions_Renamed As Boolean = False

		Public Sub New(ByVal connections As IEnumerable(Of SqlDataConnection))
			InitializeComponent()
			AddHandler lbConnections.SelectedIndexChanged, AddressOf listBoxControl1_SelectedIndexChanged
			lbConnections.DisplayMember = "Name"
            Dim targetConnections = connections.Where(Function(c) TypeOf c Is DataConnection).ToList()
			lbConnections.DataSource = targetConnections
		End Sub

		Private Sub listBoxControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
			RaiseEvent Changed(Me, New EventArgs())
		End Sub

        Public Overrides ReadOnly Property HeaderDescription() As String
            Get
                Return "Choose one connection from the list."
            End Get
        End Property

        Public Event Changed As EventHandler Implements IChooseConnectionPageView.Changed

        Public ReadOnly Property ExistingConnectionName() As String Implements IChooseConnectionPageView.ExistingConnectionName
            Get
                Return (CType(lbConnections.SelectedItem, INamedItem)).Name
            End Get
        End Property

        Public Sub SetSelectedConnection(ByVal connection As INamedItem) Implements IChooseConnectionPageView.SetSelectedConnection
            If connection IsNot Nothing Then
                lbConnections.SelectedItem = connection
            End If
        End Sub

        Public ReadOnly Property ShouldCreateNewConnection() As Boolean Implements IChooseConnectionPageView.ShouldCreateNewConnection
            Get
                Return False
            End Get
        End Property

        Public ReadOnly Property WaitFormActivator() As IWaitFormActivator Implements IChooseConnectionPageView.WaitFormActivator
            Get
                Return New WaitFormActivator(FindForm(), GetType(WaitFormWithCancel), True)
            End Get
        End Property

        Public ReadOnly Property AnyExceptions() As Boolean Implements IChooseConnectionPageView.AnyExceptions
            Get
                Return anyExceptions_Renamed
            End Get
        End Property

        Public Sub HandleException(ByVal exception As Exception) Implements IChooseConnectionPageView.HandleException
            MessageBox.Show(exception.Message)
        End Sub
	End Class
End Namespace
