# Application Insights handler for CK-ActivityMonitor

Provides a simple `IActivityMonitor` output client to pass monitoring data to
[Microsoft Azure Application Insights](https://azure.microsoft.com/en-us/services/application-insights/).

## Usage

### Requirements

Application Insights must be installed and configured on your ASP.NET website *before* using the `IActivityMonitor` client.

For more information: [Set up Application Insights for your ASP.NET website](https://docs.microsoft.com/en-us/azure/application-insights/app-insights-asp-net)

### Install via NuGet

1. Add a NuGet feed to your project: `https://www.myget.org/F/bcrosnier/api/v3/index.json`
2. Install the `CK.ActivityMonitor.ApplicationInsights` NuGet package in your ASP.NET website project

### Register the Application Insights ActivityMonitor client

At the start of your application, before creating `ActivityMonitor` instances, call the following code:

```csharp
ActivityMonitor.AutoConfiguration += ( m ) =>
{
    m.Output.RegisterClient( new ApplicationInsightsClient() );
};
```

By default, log entries with a log level of `Warn` or above are tracked as
[trace logs](https://docs.microsoft.com/en-us/azure/application-insights/app-insights-asp-net-trace-logs).

This minimum log level of `Warn` can be configured through the client class'
constructor with e.g. `new ApplicationInsightsClient( LogLevel.Error )`.

**All exceptions are tracked, regardless of their log level.**

## Build requirements

- Windows
- Powershell
- [.NET Core SDK 2.0](https://www.microsoft.com/net/download/core) (with .NET Core 2.0)
- [Visual Studio 2017](https://www.visualstudio.com/) (any edition) with .NET framework build tools

## Build instructions

1. Clone the repository
2. In Powershell, run `CodeCakeBuilder/Bootstrap.ps1`
3. Run `CodeCakeBuilder/bin/Release/CodeCakeBuilder.exe`

## Contributing

Anyone and everyone is welcome to contribute. Please take a moment to
review the [guidelines for contributing](CONTRIBUTING.md).

## License

Assets in this repository are licensed with the MIT License. For more information, please see [LICENSE.md](LICENSE.md).

## Open-source licenses

This repository and its components use the following open-source projects:

- [Invenietis/CK-Core](https://github.com/Invenietis/CK-Core), licensed under the [GNU Lesser General Public License v3.0](https://github.com/Invenietis/CK-Core/blob/master/LICENSE)
- [Invenietis/CK-Text](https://github.com/Invenietis/CK-Text), licensed under the [MIT License](https://github.com/Invenietis/CK-Text/blob/master/LICENSE)
- [Invenietis/CK-ActivityMonitor](https://github.com/Invenietis/CK-ActivityMonitor), licensed under the [GNU Lesser General Public License v3.0](https://github.com/Invenietis/CK-ActivityMonitor/blob/master/LICENSE)
- [Microsoft Azure Application Insights](https://github.com/Microsoft/ApplicationInsights-Home), licensed under the [MIT License](https://github.com/Microsoft/ApplicationInsights-Home/blob/master/LICENSE)
