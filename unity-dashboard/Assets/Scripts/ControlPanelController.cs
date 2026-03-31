using UnityEngine;
using UnityEngine.UIElements;

public class ControlPanelController : MonoBehaviour
{
    public AvatarController avatar;
    public Light sun;

    public CSVReader csvReader;

    GraphElement graph;

    Slider tempSlider;
    Slider humiditySlider;
    Slider sunSlider;

    Label coreTempLabel;
    Label heartRateLabel;
    Label riskLabel;

    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        tempSlider = root.Q<Slider>("tempSlider");
        humiditySlider = root.Q<Slider>("humiditySlider");
        sunSlider = root.Q<Slider>("sunSlider");

        coreTempLabel = root.Q<Label>("coreTempLabel");
        heartRateLabel = root.Q<Label>("heartRateLabel");
        riskLabel = root.Q<Label>("riskLabel");

        var graphPanel = root.Q<VisualElement>("graphPanel");

        graph = new GraphElement();
        graph.style.flexGrow = 1;

        if(graphPanel != null)
            graphPanel.Add(graph);

        // Scenario buttons

        root.Q<Button>("normalButton").clicked += () =>
        {
            csvReader.autoMode = true;
            csvReader.SetCSV("NormalScenario.csv");
        };

        root.Q<Button>("moderateButton").clicked += () =>
        {
            csvReader.autoMode = true;
            csvReader.SetCSV("ModerateScenario.csv");
        };

        root.Q<Button>("heatwaveButton").clicked += () =>
        {
            csvReader.autoMode = true;
            csvReader.SetCSV("HeatwaveScenario.csv");
        };

        root.Q<Button>("extremeButton").clicked += () =>
        {
            csvReader.autoMode = true;
            csvReader.SetCSV("ExtremeScenario.csv");
        };

        tempSlider.RegisterValueChangedCallback(evt => UpdateSimulation());
        humiditySlider.RegisterValueChangedCallback(evt => UpdateSimulation());
        sunSlider.RegisterValueChangedCallback(evt => UpdateSimulation());
    }

    void UpdateSimulation()
    {
        csvReader.autoMode = false;

        float temp = tempSlider.value;
        float humidity = humiditySlider.value;
        float sunIntensity = sunSlider.value;

        if (sun != null)
            sun.intensity = sunIntensity;

        float coreTemp = 36.8f + (temp - 30f) * 0.1f + humidity * 0.01f;
        float heartRate = 70 + (temp - 30f) * 2;
        float respRate = 14 + (temp - 30f) * 0.5f;

        avatar.UpdateAvatar(heartRate, coreTemp, respRate);

        UpdateFromSimulation(coreTemp, heartRate);
    }

    public void UpdateFromSimulation(float coreTemp, float heartRate)
    {
        coreTempLabel.text = "Core Temp: " + coreTemp.ToString("F1") + " °C";
        heartRateLabel.text = "Heart Rate: " + heartRate.ToString("F0") + " bpm";

        graph.AddPoint(coreTemp, heartRate);

        if (coreTemp < 37.5f)
            riskLabel.text = "Heat Risk: Normal";
        else if (coreTemp < 38.5f)
            riskLabel.text = "Heat Stress";
        else if (coreTemp < 39.5f)
            riskLabel.text = "High Risk";
        else
            riskLabel.text = "Heat Stroke";
    }
}