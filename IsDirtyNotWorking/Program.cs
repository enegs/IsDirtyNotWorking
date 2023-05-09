using System.Collections.Specialized;
using System.Diagnostics;



using (var gitCommandProcess = new Process())
{
    gitCommandProcess.StartInfo.FileName = "git";
    gitCommandProcess.StartInfo.Arguments = " diff --quiet HEAD";
    gitCommandProcess.StartInfo.CreateNoWindow = true;
    gitCommandProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

    gitCommandProcess.StartInfo.UseShellExecute = true;
    gitCommandProcess.Start();
    gitCommandProcess.WaitForExit();

    Console.WriteLine($"ThisAssembly.Git.IsDirtyString={ThisAssembly.Git.IsDirtyString}");
    Console.WriteLine($"ThisAssembly.Git.IsDirty={ThisAssembly.Git.IsDirty}");
    Console.WriteLine();
    Console.WriteLine($"git diff --quiet HEAD={gitCommandProcess.ExitCode == 1}");
}

Console.ReadKey();
