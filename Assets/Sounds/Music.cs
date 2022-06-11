using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] private AudioSource _backgroundMusic;



    private void Awake()
    {
        GameObject[] musics = GameObject.FindGameObjectsWithTag("Music");
        if (musics.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
