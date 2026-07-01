---
uid: Codebelt.SharedKernel.Security.AccessKey
example:
- *content
---
The following example issues a one-year `AccessKey` from a `Secret` and a `TimeToLive`, then reports the resulting secret material and the validity window so an issuer can confirm what was handed to the caller. Use `AccessKey.Issue` whenever you need both the secret and the bounded validity period on the same value object.

```csharp
using System;
using Codebelt.SharedKernel;
using Codebelt.SharedKernel.Security;

namespace KeyIssuanceSample;

public static class KeyIssuer
{
    public static (string Secret, DateTime ValidFrom, DateTime Expires) IssueYearlyKey(string hexSecret)
    {
        var secret = new Secret(hexSecret);
        var key = AccessKey.Issue(secret, TimeToLive.FromYears(1));

        // All three values are observable on the issued AccessKey and can flow into the caller response.
        return (key.Secret, key.ValidFrom, key.Expires);
    }
}
```
