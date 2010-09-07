using System;
using System.Collections.Generic;
using System.Linq;

namespace FluentNHibernate.Diagnostics
{
    public class DiagnosticResults
    {
        public DiagnosticResults(IEnumerable<ScannedSource> scannedSources, IEnumerable<Type> fluentMappings, IEnumerable<Type> conventions)
        {
            FluentMappings = fluentMappings.ToArray();
            ScannedSources = scannedSources.ToArray();
            Conventions = conventions.ToArray();
        }

        public IEnumerable<Type> FluentMappings { get; private set; }
        public IEnumerable<ScannedSource> ScannedSources { get; private set; }
        public IEnumerable<Type> Conventions { get; private set; }
    }
}