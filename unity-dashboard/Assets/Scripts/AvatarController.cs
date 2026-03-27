using UnityEngine;

public class AvatarController : MonoBehaviour
{
    Renderer rend;

    Color normalColor = new Color(1f, 0.8f, 0.6f);
    Color heatColor = Color.red;

    void Start()
    {
        rend = GetComponentInChildren<Renderer>();
    }

    public void UpdateAvatar(float heartRate, float coreTemp, float respRate)
    {
        float heatLevel = Mathf.InverseLerp(36.5f, 40f, coreTemp);

        Color target = Color.Lerp(normalColor, heatColor, heatLevel);

        rend.material.color =
            Color.Lerp(rend.material.color, target, Time.deltaTime * 2f);
    }
}