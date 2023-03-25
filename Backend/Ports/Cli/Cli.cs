using System.Reflection;

namespace Backend.Ports.Cli;

internal static class Cli
{
    public static void For(string[] args)
    {
        Console.WriteLine($"args: {string.Join(",", args)}");
        if (args.Length < 1)
        {
            throw new ArgumentException("at least one arg is required");
        }

        var command = args[0].Trim();

        var assembly = Assembly.GetAssembly(typeof(Cli));
        if (assembly is null)
        {
            throw new ArgumentException($"no assembly for: {nameof(Cli)}");
        }

        var type = assembly.GetTypes()
            .FirstOrDefault(t => t.IsAssignableTo(typeof(IRunnable)) && t.Name == command);
        if (type is null)
        {
            throw new ArgumentException($"no class for command: {command}");
        }

        if (Activator.CreateInstance(type) is not IRunnable runnable)
        {
            throw new ArgumentException($"runnable for {type.GetType().FullName} could not be activated");
        }

        runnable.Run(args.Skip(1).ToArray());
    }
}

