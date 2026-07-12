using UnityEngine;

public class EnableDisable : MonoBehaviour
{
    public void Disable(GameObject obj)
    {
        if (obj != null) obj.SetActive(false);
    }

    public void Enable(GameObject obj)
    {
        if (obj != null) obj.SetActive(true);
    }
}
