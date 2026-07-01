---
uid: Codebelt.SharedKernel.CorrelationId
example:
- *content
---
The following example creates a `CorrelationId` from a `Guid`, prints the resulting trace identifier so a developer can see it at runtime, and then returns it so a downstream service can pick it up from the result. Use the implicit `Guid` conversion when an upstream component already produced a request id, or the string constructor when one arrives as an HTTP header.

```csharp
using System;
using Codebelt.SharedKernel;

namespace DistributedTracingSample;

public static class CorrelationProbe
{
    public static string EmitTrace(Guid upstreamId)
    {
        CorrelationId correlation = upstreamId;
        var traceId = correlation.Value;

        // Print the correlation id so distributed traces and logs are visible during local debugging.
        Console.WriteLine(traceId);
        return traceId;
    }
}
```
