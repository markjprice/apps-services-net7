using Microsoft.Extensions.Localization; // IStringLocalizer, LocalizedString

public class PacktResources
{
  private readonly IStringLocalizer<PacktResources> localizer = null!;

  public PacktResources(IStringLocalizer<PacktResources> localizer)
  {
    this.localizer = localizer;
  }

  public string? GetEnterYourNamePrompt()
  {
    LocalizedString localizedString = localizer["EnterYourName"];
    // localizedString.SearchedLocation
    // e.g. WorkingWithCultures/Resources/PacktResources
    // localizedString.ResourceNotFound e.g. false
    return localizedString;
  }

  public string? GetEnterYourDobPrompt()
  {
    // LocalizedString has an implicit cast to string
    return localizer["EnterYourDob"];
  }

  public string? GetEnterYourSalaryPrompt()
  {
    return localizer["EnterYourSalary"];
  }

  public string? GetPersonDetails(
    string name, DateTime dob, int minutes, decimal salary)
  {
    return localizer["PersonDetails", name, dob, minutes, salary];
  }
}
