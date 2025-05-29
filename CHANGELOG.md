# Changelog

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/), and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

For more details, please refer to `PackageReleaseNotes.txt` on a per assembly basis in the `.nuget` folder.

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
