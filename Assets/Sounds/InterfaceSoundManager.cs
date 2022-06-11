using UnityEngine;

public class InterfaceSoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource _setButtonClickSound;

    private static AudioSource _buttonClickSound;





    private void Start()
    {
        SetFields();
    }

    private void SetFields()
    {
        _buttonClickSound = _setButtonClickSound;
    }
    public static AudioSource ClickButton
    {
        get { return _buttonClickSound; }
    }
}
