using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
    [SerializeField][Range(0.01f, 1f)] private float _bounciness;

    private PhysicMaterial _physicMaterial;



    private void Start()
    {
        GetComponents();
        SetBouncinessOfMaterial();
    }


    private void GetComponents()
    {
        _physicMaterial = GetComponent<BoxCollider>().material;
    }
    private void SetBouncinessOfMaterial()
    {
        _physicMaterial.bounciness = _bounciness;
    }
}
