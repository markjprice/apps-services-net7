using System.Net.Http.Headers; // MediaTypeWithQualityHeaderValue
using System.Net.Http.Json; // ReadFromJsonAsync<T>

namespace Northwind.Maui.Blazor.Client;

public partial class CategoriesPage : ContentPage
{
	public CategoriesPage()
	{
		InitializeComponent();

    CategoriesViewModel viewModel = new();

    try
    {
      HttpClient client = new()
      {
        BaseAddress = new Uri(DeviceInfo.Platform == DevicePlatform.Android ?
          "http://10.0.2.2:5192" : "http://localhost:5192")
      };

      InfoLabel.Text = $"BaseAddress: {client.BaseAddress}";

      client.DefaultRequestHeaders.Accept.Add(
        new MediaTypeWithQualityHeaderValue("application/json"));

      HttpResponseMessage response = client
        .GetAsync("api/categories").Result;

      response.EnsureSuccessStatusCode();

      IEnumerable<Category> categories =
        response.Content.ReadFromJsonAsync
        <IEnumerable<Category>>().Result;

      foreach (Category category in categories)
      {
        viewModel.Add(category);
      }

      InfoLabel.Text += $"\n{viewModel.Count} categories loaded.";
    }
    catch (Exception ex)
    {
      ErrorLabel.Text = ex.Message;
      ErrorLabel.IsVisible = true;
    }

    BindingContext = viewModel;
  }
}