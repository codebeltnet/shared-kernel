---
uid: Codebelt.SharedKernel
summary: *content
---
When domain code needs to talk about moments in time, traced requests, or immutable identifiers, raw `TimeSpan` and `string` values quickly lose meaning and bypass the validation your model actually relies on. The `Codebelt.SharedKernel` namespace solves that by replacing those primitives with strongly-typed value objects that enforce their own invariants: a `Token` is never whitespace, a `CorrelationId` is never a single repeated character, and a `CoordinatedUniversalTime` is never anything but UTC.

If you are issuing a token and need to express how long it remains valid, reach for `TimeToLive` and pass it to your issuer. If two systems must agree on what "now" means within a bounded margin, reach for `ClockSkew`. If you need an absolute timestamp, use `CoordinatedUniversalTime`. For traced request identifiers and opaque credentials, start with `CorrelationId` and `Secret`; both extend `Token` and inherit its minimum length, maximum length, and character-distribution checks.

[!INCLUDE [](../../includes/availability-modern.md)]
