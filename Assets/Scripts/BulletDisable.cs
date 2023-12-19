using System.Collections;
using UnityEngine;

public class BulletDisable : MonoBehaviour
{
    ParticleSystem _explosionEffect;
    MeshRenderer _meshRenderer;
   
    private void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(false);
    }
    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

    
}
