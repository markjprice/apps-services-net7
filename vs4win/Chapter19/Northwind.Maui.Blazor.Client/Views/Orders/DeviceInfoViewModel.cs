using CommunityToolkit.Maui.Alerts; // Toast, ToastDuration
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel; // ObservableObject
using CommunityToolkit.Mvvm.Input; // [RelayCommand]

namespace Northwind.Maui.Blazor.Client.Views.Orders;

internal partial class DeviceInfoViewModel : ObservableObject
{
  public string DisplayPixelWidth
  {
    get
    {
      return $"{DeviceDisplay.Current.MainDisplayInfo.Width} pixel width";
    }
  }

  public string DisplayDensity
  {
    get
    {
      return $"{DeviceDisplay.Current.MainDisplayInfo.Density} pixel density";
    }
  }

  public string DisplayOrientation
  {
    get
    {
      return $"Orientation is {DeviceDisplay.Current.MainDisplayInfo.Orientation}";
    }
  }

  public string DisplayRotation
  {
    get
    {
      return $"Rotation is {DeviceDisplay.Current.MainDisplayInfo.Rotation}";
    }
  }

  public string DisplayRefreshRate
  {
    get
    {
      return $"{DeviceDisplay.Current.MainDisplayInfo.RefreshRate} Hz refresh rate";
    }
  }

  public string DeviceModel
  {
    get
    {
      return DeviceInfo.Current.Model;
    }
  }

  public string DeviceType
  {
    get
    {
      return $"{DeviceInfo.Current.DeviceType} {DeviceInfo.Current.Idiom} device";
    }
  }

  public string DeviceVersion
  {
    get
    {
      return DeviceInfo.Current.VersionString;
    }
  }

  public string DevicePlatform
  {
    get
    {
      return $"Platform is {DeviceInfo.Current.Platform}";
    }
  }

  [RelayCommand]
  private async Task NavigateTo(string pageName)
  {
    await Shell.Current.GoToAsync($"//{pageName}");
  }

  [RelayCommand]
  private async Task PopupToast()
  {
    CancellationTokenSource cts = new();

    IToast toast = Toast.Make(message: "This toast pops up.",  
      duration: ToastDuration.Short, textSize: 18);

    await toast.Show(cts.Token);
  }
}
