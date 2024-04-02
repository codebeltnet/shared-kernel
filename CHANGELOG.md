# Changelog

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/), and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

For more details, please refer to `PackageReleaseNotes.txt` on a per assembly basis in the `.nuget` folder.

## [Unreleased]

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
