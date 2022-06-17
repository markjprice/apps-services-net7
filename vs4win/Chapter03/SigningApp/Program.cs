using Packt.Shared;

Write("Enter some text to sign: ");
string? data = ReadLine();

if (string.IsNullOrEmpty(data))
{
  WriteLine("You must enter some text.");
  return;
}

string signature = Protector.GenerateSignature(data);

WriteLine($"Signature: {signature}");
WriteLine("Public key used to check signature:");
WriteLine(Protector.PublicKey);

if (Protector.ValidateSignature(data, signature))
{
  WriteLine("Correct! Signature is valid. Data has not been manipulated.");
}
else
{
  WriteLine("Invalid signature or the data has been manipulated.");
}

// simulate manipulated data by replacing the
// first character with an X or Y
string manipulatedData = data.Replace(data[0], 'X');
if (manipulatedData == data)
{
  manipulatedData = data.Replace(data[0], 'Y');
}

if (Protector.ValidateSignature(manipulatedData, signature))
{
  WriteLine("Correct! Signature is valid. Data has not been manipulated.");
}
else
{
  WriteLine("Invalid signature or manipulated data: {0}", 
    manipulatedData);
}
