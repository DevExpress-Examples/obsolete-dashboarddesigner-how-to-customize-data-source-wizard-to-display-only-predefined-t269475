<!-- default file list -->
*Files to look at*:

* [CustomChooseConnectionPageView.cs](./CS/WizardCustomizationExample1/CustomChooseConnectionPageView.cs) (VB: [CustomChooseConnectionPageView.vb](./VB/WizardCustomizationExample1/CustomChooseConnectionPageView.vb))
* [DataSourceWizardCustomization1.cs](./CS/WizardCustomizationExample1/DataSourceWizardCustomization1.cs) (VB: [DataSourceWizardCustomization1.vb](./VB/WizardCustomizationExample1/DataSourceWizardCustomization1.vb))
* [Form1.cs](./CS/WizardCustomizationExample1/Form1.cs) (VB: [Form1.vb](./VB/WizardCustomizationExample1/Form1.vb))
* [Program.cs](./CS/WizardCustomizationExample1/Program.cs) (VB: [Program.vb](./VB/WizardCustomizationExample1/Program.vb))
<!-- default file list end -->
#  OBSOLETE: DashboardDesigner - How to customize data source wizard to display only predefined data connections
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/t269475)**
<!-- run online end -->


<p><strong>UPDATED:</strong> starting with version 15.2, it is possible to disable creating new connections by setting the <a href="https://documentation.devexpress.com/#Dashboard/DevExpressDashboardWinDashboardDataSourceWizardSettingsMembersTopicAll">DashboardDesigner.DataSourceWizardSettings.DisableNewConnections</a> property to <strong>True</strong>.  </p>
<p><br>This example demonstrates how to use the <a href="https://documentation.devexpress.com/#Dashboard/DevExpressDashboardWinDashboardDesigner_DataSourceWizardCustomizationtopic">DashboardDesigner.DataSourceWizardCustomization</a> to replace the default pages of the data source wizard with custom ones:</p>


```cs
dashboardDesigner1.DataSourceWizardCustomization = new DataSourceWizardCustomization();

```


<p> </p>
<p>We use following code to skip first page which allows selecting the data source type, and specify custom a wizard page that allows selecting one of the predefined connections. This custom page does not allow establishing a new connection:</p>


```cs
public class DataSourceWizardCustomization : IDashboardDataSourceWizardCustomization {
	public void CustomizeDataSourceWizard(IWizardCustomization<DashboardDataSourceModel> customization) {
		customization.StartPage = typeof(ChooseConnectionPage<DashboardDataSourceModel>);
		customization.Model.DataSourceType = DashboardDataSourceType.Xpo;
		customization.RegisterPageView<IChooseConnectionPageView, CustomChooseConnectionPageView>();
	}
}

```


<p> </p>
<p>To specify default connections in code behind, use the <a href="https://documentation.devexpress.com/#Dashboard/DevExpressDashboardWinDashboardDesigner_CustomDataConnectionstopic">DashboardDesigner.CustomDataConnections Property</a>.  <br><br><strong>See Also:</strong> <br><a href="https://www.devexpress.com/Support/Center/p/T281449">How to define a custom IConnectionStorageService in DashboardDesigner to filter out unnecessary connections from an app.config file  </a></p>

<br/>


