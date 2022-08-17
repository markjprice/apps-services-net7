namespace Northwind.Maui.Client;

internal class CustomerSearchHandler : SearchHandler
{
  public IList<CustomerDetailViewModel> Customers { get; set; }

  public Type SelectedItemNavigationTarget { get; set; }

  protected override void OnQueryChanged(string oldValue, string newValue)
  {
    base.OnQueryChanged(oldValue, newValue);

    if (string.IsNullOrWhiteSpace(newValue))
    {
      ItemsSource = null;
    }
    else
    {
      ItemsSource = Customers
          .Where(customer => customer.CompanyName.ToLower().Contains(newValue.ToLower()))
          .ToList();
    }
  }

  protected override async void OnItemSelected(object item)
  {
    base.OnItemSelected(item);

    CustomerDetailViewModel customer = (CustomerDetailViewModel)item;

    // Let the animation complete
    await Task.Delay(1000);

    ShellNavigationState state = (App.Current.MainPage as Shell).CurrentState;

    // The following route works because route names are unique in this app.
    await Shell.Current.GoToAsync($"{GetNavigationTarget()}?name={customer.CompanyName}");
  }

  string GetNavigationTarget()
  {
    return string.Empty;
    //return (Shell.Current as AppShell).Routes.FirstOrDefault(route => route.Value.Equals(SelectedItemNavigationTarget)).Key;
  }
}
