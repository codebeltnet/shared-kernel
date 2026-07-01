---
uid: Codebelt.SharedKernel.Security.AccessKeyExtensions
example:
- *content
---
The following example issues an `AccessKey` with a one-hour lifespan and then calls the `IsValid` extension against a `CoordinatedUniversalTime` snapshot taken from a hypothetical verifier clock, so the result reflects clock-skew tolerance rather than local "now". Use `IsValid` whenever an HTTP request, a queue consumer, or a service-to-service call needs to decide whether a presented key is still trustworthy.

```csharp
using System;
using Codebelt.SharedKernel;
using Codebelt.SharedKernel.Security;

namespace KeyVerificationSample;

public static class Verifier
{
    public static bool IsKeyTrusted(string hexSecret, DateTime verifierClock)
    {
        var key = AccessKey.Issue(new Secret(hexSecret), TimeToLive.FromHours(1));
        CoordinatedUniversalTime snapshot = verifierClock;

        // The extension returns false when the snapshot is outside the key's validity window plus tolerance.
        return key.IsValid(snapshot);
    }
}
```
