using System;

namespace FluentNHibernate.Diagnostics
{
    public class DiagnosticsConfiguration
    {
        readonly IDiagnosticMessageDespatcher despatcher;
        readonly Action<IDiagnosticLogger> setLogger;

        public DiagnosticsConfiguration(IDiagnosticMessageDespatcher despatcher, Action<IDiagnosticLogger> setLogger)
        {
            this.despatcher = despatcher;
            this.setLogger = setLogger;
        }

        public DiagnosticsConfiguration Enable(bool enable)
        {
            if (enable)
                Enable();
            else
                Disable();

            return this;
        }

        public DiagnosticsConfiguration Enable()
        {
            setLogger(new DefaultDiagnosticLogger(despatcher));
            return this;
        }

        public DiagnosticsConfiguration Disable()
        {
            setLogger(new NullDiagnosticsLogger());
            return this;
        }

        public DiagnosticsConfiguration RegisterListener(IDiagnosticListener listener)
        {
            despatcher.RegisterListener(listener);
            return this;
        }

        public DiagnosticsConfiguration OutputToConsole()
        {
            RegisterListener(new ConsoleOutputListener());
            return this;
        }

        public DiagnosticsConfiguration OutputToConsole(IDiagnosticResultsFormatter formatter)
        {
            RegisterListener(new ConsoleOutputListener(formatter));
            return this;
        }

        public DiagnosticsConfiguration OutputToFile(string path)
        {
            RegisterListener(new FileOutputListener(path));
            return this;
        }

        public DiagnosticsConfiguration OutputToFile(IDiagnosticResultsFormatter formatter, string path)
        {
            RegisterListener(new FileOutputListener(formatter, path));
            return this;
        }
    }
}