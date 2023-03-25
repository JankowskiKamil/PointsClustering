using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;


using NLog;

using NodaTime;

namespace PidgeonStudioPro;

internal sealed class Program
{

    public static void Main(string[] args)
    {
        SetupCulture();
        SetupNLog();
        Run(args);
    }

    // Avalonia configuration, don't remove; also used by visual designer.
    public static void Run(string[] args)
    {
#if DEBUG
        Log.PublishLevel = LoggingLevel.Debug;
#else
        Log.PublishLevel = LoggingLevel.Info;
#endif
    }


    private static void SetupNLog()
    {
        Log.PublishLevel = LoggingLevel.Debug;
        LogManager.Configuration.Variables.Add("pidgeonlogs", Services.Directories.LogDirectory);
    }

    private static void SetupCulture()
    {
        CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
        CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InstalledUICulture;
    }
}
