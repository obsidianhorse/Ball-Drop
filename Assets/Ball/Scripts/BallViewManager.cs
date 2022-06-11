using UnityEngine;

public class BallViewManager : MonoBehaviour
{
    [SerializeField] private Material[] _setMaterials;
    [SerializeField] private Mesh[] _setMeshes;

    private static Material[] _materials;
    private static Mesh[] _meshes;

    private static int _currentMaterial = 0;




    public static Material CurrentMaterial
    {
        get { return _materials[_currentMaterial]; }
    }
    public static Mesh CurrentMesh
    {
        get { return _meshes[_currentMaterial]; }
    }

    public static int CurrentIndex
    {
        get { return _currentMaterial; }
        set { _currentMaterial = value; }
    }


    private void Awake()
    {
        SetFields();
        SetCurrentSkin();
    }

    private void SetFields()
    {
        _materials = _setMaterials;
        _meshes = _setMeshes;
    }
    private void SetCurrentSkin()
    {
        CurrentIndex = int.Parse(DataBase.ExecuteQueryWithAnswer($"SELECT currentSkin FROM STORE;"));
    }

}
