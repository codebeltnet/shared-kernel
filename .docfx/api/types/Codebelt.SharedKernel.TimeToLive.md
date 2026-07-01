---
uid: Codebelt.SharedKernel.TimeToLive
example:
- *content
---
The following example issues a one-year access-key lifespan and reports the resulting duration, then compares two lifespans to decide which one grants a longer validity window. Use the `FromMinutes`, `FromHours`, `FromDays`, `FromMonths`, or `FromYears` factories to model lifespans in the unit that fits the product; the implicit `TimeSpan` conversion lets you treat the value as a normal span whenever you need to.

```csharp
using System;
using Codebelt.SharedKernel;
using Codebelt.SharedKernel.Security;

namespace TokenIssuanceSample;

public static class LifespanPolicy
{
    public static TimeSpan ChooseLifespan(string tier)
    {
        TimeToLive candidate = tier == "premium"
            ? TimeToLive.FromYears(1)
            : TimeToLive.FromDays(30);

        // Implicit conversion to TimeSpan lets the duration flow into existing APIs that expect a span.
        return (TimeSpan)candidate;
    }
}
```
