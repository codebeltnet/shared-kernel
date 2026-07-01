---
uid: Codebelt.SharedKernel.Security.Secret
example:
- *content
---
The following example constructs a `Secret` from a 32-character hex string and converts it to its UTF-8 byte representation so it can be fed to a downstream cryptographic operation. Use the implicit `Guid` conversion when an upstream system hands you a request id, or the implicit `string` conversion when the secret arrives as a header value.

```csharp
using System;
using System.Security.Cryptography;
using Codebelt.SharedKernel.Security;

namespace CryptographySample;

public static class KeyDerivation
{
    public static byte[] DeriveHmacKey(string hexSecret)
    {
        var secret = new Secret(hexSecret);
        var keyMaterial = secret.ToByteArray();

        // The byte array is suitable as input for HMAC-SHA256 key derivation.
        return SHA256.HashData(keyMaterial);
    }
}
```
