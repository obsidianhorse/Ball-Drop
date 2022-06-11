using UnityEngine;

public class PopParticle : MonoBehaviour
{
    [SerializeField] private ParticleSystem _popParticles;



    private void OnEnable()
    {
        SetParticleView();
    }


    
    public void SetParticleView()
    {
        _popParticles.GetComponent<ParticleSystemRenderer>().mesh = BallViewManager.CurrentMesh;
        _popParticles.GetComponent<ParticleSystemRenderer>().material = BallViewManager.CurrentMaterial;
    }
}
