﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis.Testing;

namespace Microsoft.CodeAnalysis.CSharp.Testing
{
    public class CSharpSourceGeneratorTest<TSourceGenerator, TVerifier> : SourceGeneratorTest<TVerifier>
        where TSourceGenerator : ISourceGenerator, new()
        where TVerifier : IVerifier, new()
    {
        private static readonly LanguageVersion DefaultLanguageVersion =
            Enum.TryParse("Default", out LanguageVersion version) ? version : LanguageVersion.CSharp6;

        protected override IEnumerable<Type> GetSourceGenerators()
            => new Type[] { typeof(TSourceGenerator) };

        protected override string DefaultFileExt => "cs";

        public override string Language => LanguageNames.CSharp;

        protected override CompilationOptions CreateCompilationOptions()
            => new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary, allowUnsafe: true);

        protected override ParseOptions CreateParseOptions()
            => new CSharpParseOptions(DefaultLanguageVersion, DocumentationMode.Diagnose);
    }
}
