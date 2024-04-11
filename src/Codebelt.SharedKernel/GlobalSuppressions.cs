// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Major Code Smell", "S3928:Parameter names used into ArgumentException constructors should match an existing one ", Justification = "False positive.", Scope = "member", Target = "~M:Codebelt.SharedKernel.Token.#ctor(System.String,System.Action{Codebelt.SharedKernel.TokenOptions})")]
