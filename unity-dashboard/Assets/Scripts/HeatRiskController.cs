using UnityEngine;
using TMPro;

public class HeatRiskController : MonoBehaviour
{
    public TextMeshProUGUI riskText;

    public void UpdateRisk(float coreTemp)
    {
        if (coreTemp < 37.5f)
        {
            riskText.text = "Status: Normal";
            riskText.color = Color.green;
        }
        else if (coreTemp < 38.5f)
        {
            riskText.text = "Status: Heat Stress";
            riskText.color = Color.yellow;
        }
        else if (coreTemp < 39.5f)
        {
            riskText.text = "Status: High Heat Risk";
            riskText.color = new Color(1f,0.5f,0f); // orange
        }
        else
        {
            riskText.text = "Status: Heat Stroke Risk";
            riskText.color = Color.red;
        }
    }
}