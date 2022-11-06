using CommunityToolkit.Mvvm.Input; // [RelayCommand]
using System.Collections.ObjectModel; // ObservableCollection<T>
using System.Net.Http.Headers; // MediaTypeWithQualityHeaderValue
using System.Net.Http.Json; // ReadFromJsonAsync<T>

namespace Northwind.Maui.Blazor.Client.Views.Categories;

internal partial class CategoriesViewModel : ObservableCollection<Category>
{
  // These property do not need to support two-way binding
  // because they are set programmatically to display to user.

  public string InfoMessage { get; set; } = string.Empty;

  public string ErrorMessage { get; set; } = string.Empty;

  public bool ErrorMessageVisible { get; set; }

  public CategoriesViewModel()
  {
    try
    {
      HttpClient client = new()
      {
        BaseAddress = new Uri(
          DeviceInfo.Platform == DevicePlatform.Android ?
          "http://10.0.2.2:5192" : "http://localhost:5192")
      };

      InfoMessage = $"BaseAddress: {client.BaseAddress}. ";

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
        int offset = 78; // to remove the OLE header

        category.Picture = category.Picture.AsSpan(
          offset, category.Picture.Length - offset).ToArray();

        category.PicturePath = $"category{category.CategoryId}_small.jpeg";

        Add(category);
      }

      InfoMessage += $"{Count} categories loaded.";
    }
    catch (Exception ex)
    {
      ErrorMessage = ex.Message;
      ErrorMessageVisible = true;
    }
  }

  [RelayCommand]
  private void AddCategoryToFavorites()
  {
    Console.WriteLine("Add category to favorites");
  }

  [RelayCommand]
  private void DeleteCategory()
  {
    Console.WriteLine("Delete category");
  }
}
