---
uid: Codebelt.SharedKernel.Security.AccessKeyOptions
example:
- *content
---
The following example constructs an `AccessKeyOptions` instance with a custom `DesiredTolerance` and a bounded validity window, then validates the configuration before it is consumed by an `AccessKey` constructor. Use `AccessKeyOptions` whenever the default `CoordinatedUniversalTime.MinValue` / `MaxValue` / 30-second tolerance is not appropriate for the issuing system.

```csharp
using System;
using Codebelt.SharedKernel;
using Codebelt.SharedKernel.Security;

namespace KeyIssuanceSample;

public static class OptionsFactory
{
    public static AccessKeyOptions CreateHourlyOptions()
    {
        var now = DateTime.UtcNow;
        return new AccessKeyOptions
        {
            ValidFrom = new CoordinatedUniversalTime(now),
            Expires = new CoordinatedUniversalTime(now.AddHours(1)),
            DesiredTolerance = TimeSpan.FromMinutes(1)
        };
    }
}
```
