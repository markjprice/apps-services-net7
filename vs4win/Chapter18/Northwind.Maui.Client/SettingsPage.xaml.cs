using System.Reflection; // FieldInfo

namespace Northwind.Maui.Client;

public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		InitializeComponent();
	}

  private const string textColorKey = "TextColor";
  private const string backgroundColorKey = "BackgroundColor";

  private async void ApplyButton_Clicked(object sender, EventArgs e)
  {
    try
    {
      App.Current.Resources[textColorKey] =
        Color.Parse(TextColorEntry.Text);

      App.Current.Resources[backgroundColorKey] =
        Color.Parse(BackgroundColorEntry.Text);
    }
    catch (Exception ex)
    {
      await DisplayAlert(title: "Exception",
        message: ex.Message, cancel: "OK");
    }
  }

  private async void ContentPage_Loaded(object sender, EventArgs e)
  {
    try
    {
      object color;

      if (App.Current.Resources.TryGetValue(textColorKey, out color))
      {
        TextColorEntry.Text = GetNameFromColor(color as Color);
      }

      if (App.Current.Resources.TryGetValue(backgroundColorKey, out color))
      {
        BackgroundColorEntry.Text = GetNameFromColor(color as Color);
      }
    }
    catch (Exception ex)
    {
      await DisplayAlert(title: "Exception",
        message: ex.Message, cancel: "OK");
    }
  }

  private string GetNameFromColor(Color color)
  {
    Type colorsType = typeof(Colors);

    FieldInfo info = colorsType.GetFields().Where(
      field => field.GetValue(field) == color).SingleOrDefault();

    return info?.Name;
  }

  private void TextColorEntry_TextChanged(
    object sender, TextChangedEventArgs e)
  {
    if (!ApplyButton.IsEnabled) ApplyButton.IsEnabled = true;
  }

  private void BackgroundColorEntry_TextChanged(
    object sender, TextChangedEventArgs e)
  {
    if (!ApplyButton.IsEnabled) ApplyButton.IsEnabled = true;
  }
}