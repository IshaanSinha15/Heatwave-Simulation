using UnityEngine;
using System.IO;

public class CSVReader : MonoBehaviour
{
    public AvatarController avatar;
    public ControlPanelController ui;

    public bool autoMode = false;

    string csvPath;
    float timer;

    public void SetCSV(string file)
    {
        csvPath = @"C:\BioGears\runs\" + file;
    }

    void Update()
    {
        if (!autoMode)
            return;

        timer += Time.deltaTime;

        if (timer > 1f)
        {
            timer = 0f;
            ReadLatestRow();
        }
    }

    void ReadLatestRow()
    {
        if (!File.Exists(csvPath))
            return;

        string last = null;

        using (FileStream fs = new FileStream(csvPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        using (StreamReader reader = new StreamReader(fs))
        {
            while (!reader.EndOfStream)
                last = reader.ReadLine();
        }

        if (last == null)
            return;

        string[] v = last.Split('\t');

        float heart = float.Parse(v[2]);
        float core = float.Parse(v[3]);
        float resp = float.Parse(v[5]);

        avatar.UpdateAvatar(heart, core, resp);
        ui.UpdateFromSimulation(core, heart);
    }
}