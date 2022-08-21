namespace Northwind.Maui.Blazor.Client;

public partial class OrdersPage : ContentPage
{
	public OrdersPage()
	{
		InitializeComponent();
	}

	private void NewWindowButton_Clicked(object sender, EventArgs e)
	{
		Window window = new() { Page = new AppShell() };
		Application.Current.OpenWindow(window);
	}
}