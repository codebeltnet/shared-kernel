---
uid: Codebelt.SharedKernel.CoordinatedUniversalTime
example:
- *content
---
The following example captures the current UTC moment as a `CoordinatedUniversalTime` and converts it back to a `DateTime` for downstream consumers, and parses a wire-format ISO 8601 string the same way. Use `CoordinatedUniversalTime.Now` for "now" snapshots and `FromString` when an external system hands you a UTC timestamp that still needs validation.

```csharp
using System;
using Codebelt.SharedKernel;

namespace EventPublishingSample;

public static class EventTimestamps
{
    public static DateTime CaptureAndRepublish(string wireTimestamp)
    {
        CoordinatedUniversalTime current = CoordinatedUniversalTime.Now();
        CoordinatedUniversalTime parsed = CoordinatedUniversalTime.FromString(wireTimestamp);

        // Both values are guaranteed to be DateTimeKind.Utc and can flow into JSON or storage as DateTime.
        return current > parsed ? current : parsed;
    }
}
```
