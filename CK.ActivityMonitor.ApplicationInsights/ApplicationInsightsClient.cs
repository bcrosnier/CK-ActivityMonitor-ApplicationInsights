using System;
using System.Collections.Generic;
using CK.Core;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;

namespace CK.Core
{
    /// <summary>
    /// ActivityMonitor output client for Application Insights.
    /// </summary>
    public class ApplicationInsightsClient : IActivityMonitorClient
    {
        readonly TelemetryClient _tc;
        readonly LogLevel _minLogLevel;

        public ApplicationInsightsClient( LogLevel minimumLogLevel )
        {
            _tc = new TelemetryClient();
            _minLogLevel = minimumLogLevel;
        }

        public ApplicationInsightsClient()
            : this( LogLevel.Warn ) { }

        public void OnAutoTagsChanged( CKTrait newTrait )
        {
        }

        public void OnGroupClosed( IActivityLogGroup group, IReadOnlyList<ActivityLogGroupConclusion> conclusions )
        {
        }

        public void OnGroupClosing( IActivityLogGroup group, ref List<ActivityLogGroupConclusion> conclusions )
        {
        }

        public void OnOpenGroup( IActivityLogGroup group )
        {
        }

        public void OnTopicChanged( string newTopic, string fileName, int lineNumber )
        {
        }

        public void OnUnfilteredLog( ActivityMonitorLogData data )
        {
            if( data.MaskedLevel >= _minLogLevel )
            {
                _tc.TrackTrace( data.Text, GetSeverityLevel( data ) );
            }
            if( data.Exception != null )
            {
                _tc.TrackException( data.Exception );
            }
        }

        private static SeverityLevel GetSeverityLevel( ActivityMonitorLogData data )
        {
            switch( data.MaskedLevel )
            {
                case LogLevel.Debug:
                case LogLevel.Trace:
                    return SeverityLevel.Verbose;
                case LogLevel.Info:
                    return SeverityLevel.Information;
                case LogLevel.Warn:
                    return SeverityLevel.Warning;
                case LogLevel.Error:
                    return SeverityLevel.Error;
                case LogLevel.Fatal:
                    return SeverityLevel.Critical;
                default:
                    return SeverityLevel.Information;
            }
        }
    }
}
