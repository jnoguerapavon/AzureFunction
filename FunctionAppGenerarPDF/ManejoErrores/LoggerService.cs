using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionAppGenerarPDF.ManejoErrores
{
    public class LoggerService
    {
        private readonly TelemetryClient _telemetry;

        public LoggerService(TelemetryClient telemetry)
        {
            _telemetry = telemetry;
        }

        /// <summary>
        /// Registra un mensaje de información.
        /// </summary>
        public void LogInfo(string mensaje)
        {
            _telemetry.TrackTrace(mensaje, SeverityLevel.Information);
        }

        /// <summary>
        /// Registra una advertencia.
        /// </summary>
        public void LogWarning(string mensaje)
        {
            _telemetry.TrackTrace(mensaje, SeverityLevel.Warning);
        }

        /// <summary>
        /// Registra un error.
        /// </summary>
        public void LogError(string mensaje, Exception? ex = null)
        {
            _telemetry.TrackTrace(mensaje, SeverityLevel.Error);
            if (ex != null)
            {
                _telemetry.TrackException(ex);
            }
        }

        /// <summary>
        /// Registra un evento personalizado.
        /// </summary>
        public void LogEvento(string nombreEvento)
        {
            _telemetry.TrackEvent(nombreEvento);
        }
    }
}
