---
uid: Codebelt.SharedKernel.ClockSkew
example:
- *content
---
The following example expresses a 30-second clock-skew tolerance and then measures the drift between two UTC timestamps so a verifier can decide whether a token issuance time is still within the allowed margin. Use `ClockSkew.FromSeconds` or `ClockSkew.FromMinutes` to model tolerances that match the real-world clock variance between two systems.

```csharp
using System;
using Codebelt.SharedKernel;

namespace TokenIssuanceSample;

public static class ClockTolerance
{
    public static bool IsWithinTolerance(DateTime issuedAt, DateTime verifiedAt)
    {
        ClockSkew allowed = TimeSpan.FromSeconds(30);
        var issued = new CoordinatedUniversalTime(issuedAt);
        var verified = new CoordinatedUniversalTime(verifiedAt);
        DateTime issuedAtUtc = issued;
        DateTime verifiedAtUtc = verified;
        TimeSpan actualSkew = verifiedAtUtc - issuedAtUtc;

        // Return whether the measured drift fits inside the configured tolerance.
        return actualSkew <= allowed;
    }
}
```
