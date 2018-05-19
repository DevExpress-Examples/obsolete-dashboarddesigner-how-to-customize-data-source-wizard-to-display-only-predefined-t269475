Imports Microsoft.VisualBasic
Imports DevExpress.DashboardCommon
Imports DevExpress.DashboardWin.ServiceModel
Imports DevExpress.DataAccess.UI.Wizard
Imports DevExpress.DataAccess.Wizard.Presenters
Imports DevExpress.DataAccess.Wizard.Views
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace WizardCustomizationExample1
    Public Class DataSourceWizardCustomization
        Implements IDashboardDataSourceWizardCustomization

        Public Sub CustomizeDataSourceWizard(ByVal customization As IWizardCustomization(Of DashboardDataSourceModel)) Implements IDashboardDataSourceWizardCustomization.CustomizeDataSourceWizard
            customization.StartPage = GetType(ChooseConnectionPage(Of DashboardDataSourceModel))
            customization.Model.DataSourceType = DashboardDataSourceType.Xpo
            customization.RegisterPageView(Of IChooseConnectionPageView, CustomChooseConnectionPageView)()
        End Sub
    End Class
End Namespace
