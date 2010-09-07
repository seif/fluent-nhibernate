using System;

namespace FluentNHibernate.Diagnostics
{
    public class NullDiagnosticsLogger : IDiagnosticLogger
    {
        public void Flush()
        {}

        public void FluentMappingDiscovered(Type type)
        {}

        public void ConventionDiscovered(Type type)
        {}

        public void LoadedFluentMappingsFromSource(ITypeSource source)
        {}

        public void LoadedConventionsFromSource(ITypeSource source)
        {}
    }
}