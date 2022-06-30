using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private Death _death;
    [SerializeField] private GameObject _pausePrefab;



    private GameObject _pause;


    private void Start()
    {
        _death.Dead += Hide;
        _pause = Instantiate(_pausePrefab);
    }
    public void Hide()
    {
        _pause.gameObject.SetActive(false);
    }
    
}
