using System;
using System.Collections.Generic;

namespace FluentNHibernate.Diagnostics
{
    public class DefaultDiagnosticLogger : IDiagnosticLogger
    {
        readonly IDiagnosticMessageDespatcher despatcher;
        readonly List<Type> classMaps = new List<Type>();
        readonly List<string> scannedSources = new List<string>();
        bool isDirty;

        public DefaultDiagnosticLogger(IDiagnosticMessageDespatcher despatcher)
        {
            this.despatcher = despatcher;
        }

        public void Flush()
        {
            if (!isDirty) return;

            var results = BuildResults();

            despatcher.Publish(results);
        }

        DiagnosticResults BuildResults()
        {
            return new DiagnosticResults(classMaps, scannedSources);
        }

        public void FluentMappingDiscovered(Type type)
        {
            isDirty = true;
            classMaps.Add(type);
        }

        public void LoadedFluentMappingsFromSource(ITypeSource source)
        {
            isDirty = true;
            scannedSources.Add(source.GetIdentifier());
        }
    }
}