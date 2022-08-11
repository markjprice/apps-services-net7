/* Shared classes can be referenced by both the Client and Server */
namespace Packt.Shared;

public static class NorthwindExtensionMethods
{
  public static string ConvertToBase64Jpeg(this byte[] picture)
  {
    int offset = 78; // to remove the OLE header
    Span<byte> data = picture.AsSpan(offset, picture.Length - offset);
    return string.Format("data:image/jpg;base64,{0}",
      Convert.ToBase64String(data));
  }
}