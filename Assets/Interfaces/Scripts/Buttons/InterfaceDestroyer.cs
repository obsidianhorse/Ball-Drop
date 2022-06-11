using UnityEngine;

public class InterfaceDestroyer : MonoBehaviour
{
    [SerializeField] private GameObject _deleteObject;
    public void Delete()
    {
        InterfaceSoundManager.ClickButton.Play();

        Destroy(_deleteObject);
    }
}
