using UnityEngine;

public class TestTemperature : MonoBehaviour
{
    public AvatarController avatar;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            avatar.UpdateAvatar(70f, 37f, 15f);

        if (Input.GetKeyDown(KeyCode.Alpha2))
            avatar.UpdateAvatar(90f, 38f, 18f);

        if (Input.GetKeyDown(KeyCode.Alpha3))
            avatar.UpdateAvatar(110f, 39f, 22f);

        if (Input.GetKeyDown(KeyCode.Alpha4))
            avatar.UpdateAvatar(130f, 40f, 28f);
    }
}