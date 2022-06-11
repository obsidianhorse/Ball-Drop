using UnityEngine;

public class LinkButton : MonoBehaviour
{
    public void GoTo(string URL)
    {
        Application.OpenURL(URL);
    }
}
