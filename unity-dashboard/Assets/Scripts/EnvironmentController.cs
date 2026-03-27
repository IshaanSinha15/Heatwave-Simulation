using UnityEngine;

public class EnvironmentController : MonoBehaviour
{
    public Light sun;

    public void UpdateEnvironment(float temp)
    {
        if(temp > 40)
            sun.color = Color.red;

        else if(temp > 35)
            sun.color = new Color(1f,0.5f,0.3f);

        else
            sun.color = Color.white;
    }
}