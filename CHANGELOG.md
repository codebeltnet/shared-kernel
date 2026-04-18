# Changelog

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/), and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

For more details, please refer to `PackageReleaseNotes.txt` on a per assembly basis in the `.nuget` folder.

## [0.5.6] - 2026-04-18

This is a service update that focuses on package dependencies.

## [0.5.5] - 2026-03-29

This is a service update that focuses on package dependencies.

### Changed

- Dependencies upgraded: `Cuemon.Extensions.IO` to 10.5.0, `Codebelt.Extensions.Xunit.App` to 11.0.8, `Savvyio.Domain`, `Savvyio.Extensions.Newtonsoft.Json`, and `Savvyio.Extensions.Text.Json` to 5.0.5, and `coverlet.collector`/`coverlet.msbuild` to 8.0.1,
- `Directory.Build.targets` now reads `PackageReleaseNotes.txt` via `System.IO.File.ReadAllText` instead of `ReadLinesFromFile`, preserving blank lines in NuGet package release notes,
- `testenvironments.json` Docker test environment split into dedicated `.NET 9` and `.NET 10` entries using versioned image tags (`:9` and `:10`) instead of a single combined image,
- `service-update.yml` fixed spurious trailing whitespace in the `ENTRY` bash template for the service-update workflow,
- `bump-nuget.py` extended `SOURCE_PACKAGE_MAP` with the `carter` → `Codebelt.Extensions.Carter` package mapping.

## [0.5.4] - 2026-02-28

This is a service update that focuses on package dependencies.

## [0.5.3] - 2026-02-21

This is a service update that focuses on package dependencies.

## [0.5.2] - 2026-02-15

This is a service update that focuses on package dependencies.

## [0.5.1] - 2026-01-24

This is a service update that focuses on package dependencies.

## [0.5.0] - 2025-11-15

This is a major release that focuses on adapting the latest `.NET 10` release (LTS) in exchange for current `.NET 8` (LTS).

> To ensure access to current features, improvements, and security updates, and to keep the codebase clean and easy to maintain, we target only the latest long-term (LTS), short-term (STS) and (where applicable) cross-platform .NET versions.

## [0.4.6] - 2025-10-20

This is a service update that focuses on package dependencies.

## [0.4.5] - 2025-09-16

This is a service update that focuses on package dependencies.

## [0.4.4] - 2025-08-26

This is a service update that focuses on package dependencies.

## [0.4.3] - 2025-05-29

This is a service update that focuses on package dependencies.

## [0.4.2] - 2025-04-19

This is a service update that focuses on package dependencies.

## [0.4.1] - 2025-01-31

Purely an ALM release. No changes to the codebase.

## [0.4.0] - 2024-11-13

#### Codebelt.SharedKernel

Purely an ALM release. No changes to the codebase.

## [0.3.0] - 2024-09-08

#### Codebelt.SharedKernel

Purely an ALM release. No changes to the codebase.

## [0.2.0] - 2024-04-11

### Added

#### Codebelt.SharedKernel

- Token record in the Codebelt.SharedKernel namespace that represents an object that can be used for storing sensitive data
- TokenOptions class in the Codebelt.SharedKernel namespace that specifies options that is related to the Token record
- CorrelationId record in the Codebelt.SharedKernel namespace that represents an object that can be used as unique identifier that help you trace requests across multiple services in a distributed system

## [0.1.0] - 2024-04-03

### Added

#### Codebelt.SharedKernel

- AccessKey record in the Codebelt.SharedKernel.Security namespace that represents an object that can be used for API key-based authentication and similar
- AccessKeyExtensions class in the Codebelt.SharedKernel.Security namespace that consist of extension methods for the AccessKey record: IsValid
- AccessKeyOptions class in the Codebelt.SharedKernel.Security namespace that specifies options that is related to the AccessKey record
- Secret record in the Codebelt.SharedKernel.Security namespace that represents an object that can be used for storing sensitive data
- ClockSkew record in the Codebelt.SharedKernel namespace that represents an object that can be used to warrant for clock skew related scenarios such as authentication
- ComparableValueObject class in the Codebelt.SharedKernel namespace that provides an implementation of SingleValueObject{T} tailored for handling a single value that implements the IComparable{T} interface
- CoordinatedUniversalTime record in the Codebelt.SharedKernel namespace that represents an object that can be used when you need a timestamp that is based on an absolute time (UTC)
- TimeToLive record in the Codebelt.SharedKernel namespace that represents an object that can be used when issuing authentication tokens or similar (TTL)

[0.5.6]: https://github.com/codebeltnet/shared-kernel/compare/v0.5.5...v0.5.6
[0.5.5]: https://github.com/codebeltnet/shared-kernel/compare/v0.5.4...v0.5.5
[0.5.4]: https://github.com/codebeltnet/shared-kernel/compare/v0.5.3...v0.5.4
[0.5.3]: https://github.com/codebeltnet/shared-kernel/compare/v0.5.2...v0.5.3
[0.5.2]: https://github.com/codebeltnet/shared-kernel/compare/v0.5.1...v0.5.2
[0.5.1]: https://github.com/codebeltnet/shared-kernel/compare/v0.5.0...v0.5.1
[0.5.0]: https://github.com/codebeltnet/shared-kernel/compare/v0.4.6...v0.5.0
[0.4.6]: https://github.com/codebeltnet/shared-kernel/compare/v0.4.5...v0.4.6
[0.4.5]: https://github.com/codebeltnet/shared-kernel/compare/v0.4.4...v0.4.5
[0.4.4]: https://github.com/codebeltnet/shared-kernel/compare/v0.4.3...v0.4.4
[0.4.3]: https://github.com/codebeltnet/shared-kernel/compare/v0.4.2...v0.4.3
[0.4.2]: https://github.com/codebeltnet/shared-kernel/compare/v0.4.1...v0.4.2
[0.4.1]: https://github.com/codebeltnet/shared-kernel/compare/v0.4.0...v0.4.1
[0.4.0]: https://github.com/codebeltnet/shared-kernel/compare/v0.3.0...v0.4.0
[0.3.0]: https://github.com/codebeltnet/shared-kernel/compare/v0.2.0...v0.3.0
[0.2.0]: https://github.com/codebeltnet/shared-kernel/compare/v0.1.0...v0.2.0
[0.1.0]: https://github.com/codebeltnet/shared-kernel/releases/tag/v0.1.0
