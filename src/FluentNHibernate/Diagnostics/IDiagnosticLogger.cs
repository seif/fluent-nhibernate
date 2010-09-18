using System;

namespace FluentNHibernate.Diagnostics
{
    public interface IDiagnosticLogger
    {
        void Flush();
        void FluentMappingDiscovered(Type type);
        void ConventionDiscovered(Type type);
        void LoadedFluentMappingsFromSource(ITypeSource source);
        void LoadedConventionsFromSource(ITypeSource source);
        void AutomappingSkippedType(Type type, string reason);
    }
}