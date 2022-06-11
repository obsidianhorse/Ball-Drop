using UnityEngine;

public class MaterialTest : MonoBehaviour
{
    [SerializeField] private Material[] _materials;

    private MeshRenderer _meshRenderer;
    private int _index = 1;

    private void Start()
    {
        GetComponents();
    }

    private void GetComponents()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }
    private void SetMaterial()
    {
        _meshRenderer.material = _materials[_index];
    }
    public void NextMaterial()
    {
        if (_index == _materials.Length - 1)
        {
            _index = 0;
        }
        else
        {
            _index++;
        }

        SetMaterial();
    }
    public void BackMaterial()
    {
        if (_index == 0)
        {
            _index = _materials.Length - 1;
        }
        else
        {
            _index--;
        }

        SetMaterial();
    }


}
