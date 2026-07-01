---
uid: Codebelt.SharedKernel.TokenOptions
example:
- *content
---
The following example loosens the `Token` validation rules so a developer-supplied 20-character string can be accepted as a token during local testing. Use `TokenOptions` whenever a `Token` consumer has constraints that differ from the default 32-128 character window or the 4-distinct-character minimum.

```csharp
using Codebelt.SharedKernel;

namespace DeveloperEnvironmentSample;

public static class TestTokenFactory
{
    public static Token CreateDevelopmentToken(string candidate)
    {
        var options = new TokenOptions
        {
            MinimumLength = 16,
            MaximumLength = 64,
            MaximumCharacterFrequency = 0
        };

        // The TokenOptions delegate wires the relaxed policy into the constructor.
        return new Token(candidate, o =>
        {
            o.MinimumLength = options.MinimumLength;
            o.MaximumLength = options.MaximumLength;
            o.MaximumCharacterFrequency = options.MaximumCharacterFrequency;
        });
    }
}
```
