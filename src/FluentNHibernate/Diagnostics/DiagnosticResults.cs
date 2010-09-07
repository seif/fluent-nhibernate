using System;
using System.Collections.Generic;
using System.Linq;

namespace FluentNHibernate.Diagnostics
{
    public class DiagnosticResults
    {
        public DiagnosticResults(IEnumerable<Type> fluentMappings, IEnumerable<string> scannedSources)
        {
            FluentMappings = fluentMappings.ToArray();
            ScannedSources = scannedSources.ToArray();
        }

        public IEnumerable<Type> FluentMappings { get; private set; }
        public IEnumerable<string> ScannedSources { get; private set; }
    }
}