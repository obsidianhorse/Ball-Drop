using UnityEngine;

public class BallSoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource _setJumpSound;
    [SerializeField] private AudioSource _setLandSound;
    [SerializeField] private AudioSource _setCrashSound;
    [SerializeField] private AudioSource _setStickyInSound;
    [SerializeField] private AudioSource _setStickyOutSound;

    private static AudioSource _jumpSound;
    private static AudioSource _landSound;
    private static AudioSource _crashSound;
    private static AudioSource _stickyInSound;
    private static AudioSource _stickyOutSound;





    private void Start()
    {
        SetFields();
    }

    private void SetFields()
    {
        _jumpSound = _setJumpSound;
        _landSound = _setLandSound;
        _crashSound = _setCrashSound;
        _stickyInSound = _setStickyInSound;
        _stickyOutSound = _setStickyOutSound;
    }


    public static AudioSource Jump
    { 
        get { return _jumpSound; }
    }
    public static AudioSource Land
    {
        get { return RandomSound(_landSound, 1.1f, 1.3f); }
    }
    public static AudioSource Crush
    {
        get { return RandomSound(_crashSound, 1.3f, 1.5f); }
    }
    public static AudioSource StickyIn
    {
        get { return _stickyInSound; }
    }
    public static AudioSource StickyOut
    {
        get { return _stickyOutSound; }
    }

    private static AudioSource RandomSound(AudioSource sourse, float minPitch, float maxPitch)
    {
        AudioSource randomSound = sourse;
        randomSound.pitch = Random.Range(minPitch, maxPitch);
        randomSound.volume = Random.Range(0.2f, 1.0f);

        return randomSound;
    }
}
