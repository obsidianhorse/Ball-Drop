using UnityEngine;

public class MeshTest : MonoBehaviour
{
    [SerializeField] private Mesh[] _meshes;

    private MeshFilter _meshFilter;
    private int _index = 1;

    private void Start()
    {
        GetComponents();
    }

    private void GetComponents()
    {
        _meshFilter = GetComponent<MeshFilter>();
    }
    private void SetMesh()
    {
        _meshFilter.mesh = _meshes[_index];
    }

    public void NextMesh()
    {
        if (_index == _meshes.Length - 1)
        {
            _index = 0;
        }
        else
        {
            _index++;
        }

        SetMesh();
    }
    public void BackMesh()
    {
        if (_index == 0)
        {
            _index = _meshes.Length - 1;
        }
        else
        {
            _index--;
        }

        SetMesh();
    }
}
