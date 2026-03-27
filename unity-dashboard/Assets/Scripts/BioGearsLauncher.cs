using UnityEngine;
using System.Diagnostics;

public class BioGearsLauncher : MonoBehaviour
{
    string exe = @"C:\BioGears\bin\bg-scenario.exe";
    string workingDir = @"C:\BioGears\bin";

    Process process;

    void StartScenario(string scenario)
    {
        if (process != null && !process.HasExited)
        {
            process.Kill();
            process = null;
        }

        ProcessStartInfo info = new ProcessStartInfo();

        info.FileName = exe;
        info.Arguments = "..\\runs\\" + scenario + ".xml";
        info.WorkingDirectory = workingDir;

        info.CreateNoWindow = true;
        info.UseShellExecute = false;

        process = Process.Start(info);

        UnityEngine.Debug.Log("Started BioGears: " + scenario);
    }

    public void RunNormal()
    {
        StartScenario("NormalScenario");
    }

    public void RunModerate()
    {
        StartScenario("ModerateHeatScenario");
    }

    public void RunHeatwave()
    {
        StartScenario("HeatwaveScenario");
    }

    public void RunExtreme()
    {
        StartScenario("ExtremeHeatwaveScenario");
    }
}