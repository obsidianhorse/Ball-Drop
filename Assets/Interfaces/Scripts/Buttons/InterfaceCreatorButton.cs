using UnityEngine;

public class InterfaceCreatorButton : MonoBehaviour
{
    [SerializeField] private GameObject[] _interfaces;





    public void CreateInterface(int index)
    {
        Instantiate(_interfaces[index]);

        InterfaceSoundManager.ClickButton.Play();
    }
}
