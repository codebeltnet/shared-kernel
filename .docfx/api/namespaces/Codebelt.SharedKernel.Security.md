---
uid: Codebelt.SharedKernel.Security
summary: *content
---
API keys are easy to mint but easy to misuse: an issuer may forget to bound a key's lifespan, a verifier may compare timestamps without tolerating clock drift, and a key's "valid" window can quietly change shape the moment any of those assumptions shift. The `Codebelt.SharedKernel.Security` namespace solves that by pairing an `AccessKey` value object with a default `AccessKeyOptions` configuration and an `IsValid` extension method that already accounts for `ValidFrom`, `Expires`, and `DesiredTolerance` against a `CoordinatedUniversalTime` snapshot.

Start with `AccessKey.Issue` to mint a new key from a `Secret`; pass an optional `TimeToLive` to bound the key's validity window. When you need bounds that differ from the defaults, configure `AccessKeyOptions` through the constructor delegate instead of creating a separate type. To verify a key against the current UTC moment, call the `IsValid` extension on the `AccessKey`; pass an explicit `CoordinatedUniversalTime` argument when you need to verify against a specific point in time rather than "now."

[!INCLUDE [](../../includes/availability-modern.md)]

### Extension Members

|Type|Ext|Methods|
|--:|:-:|---|
|AccessKey|⬇️|`IsValid`|
