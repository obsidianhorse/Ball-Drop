using UnityEngine;

public class View : MonoBehaviour
{
    private MeshRenderer _meshRenderer;
    private MeshFilter _meshFilter;






    void Start()
    {
        GetComponents();
        UpdateView();
    }


    private void GetComponents()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _meshFilter = GetComponent<MeshFilter>();
    }
    private void UpdateView()
    {
        UpdateMaterial();
        UpdateMesh();
    }
    private void UpdateMaterial()
    {
        _meshRenderer.material = BallViewManager.CurrentMaterial;
    }
    private void UpdateMesh()
    {
        _meshFilter.mesh = BallViewManager.CurrentMesh;
    }
}
