---
uid: Codebelt.SharedKernel.Token
example:
- *content
---
The following example constructs a `Token` from a 32-character hex string that satisfies the default minimum length, maximum length, and character-distribution rules, then logs the token so its presence can be audited in the request flow. Use the optional `TokenOptions` delegate when the supplied value needs bounds or character-distribution rules that differ from the defaults.

```csharp
using System;
using Codebelt.SharedKernel;

namespace ApiKeySample;

public static class TokenProbe
{
    public static string AuditToken(string hexCandidate)
    {
        // The default TokenOptions (32-128 chars, 4+ distinct characters) reject unguessable candidates.
        var token = new Token(hexCandidate);
        var length = token.Value.Length;

        // Audit the token length against the configured minimum so the validation rule is observable.
        Console.WriteLine($"token length: {length}");
        return token.Value;
    }
}
```
