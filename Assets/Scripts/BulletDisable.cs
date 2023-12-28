using UnityEngine;

public class BulletDisable : MonoBehaviour
{
    public ParticleSystem _explosionEffect;
    TrailRenderer _bulletRenderer;
    private void Start()
    {
        _bulletRenderer = GetComponent<TrailRenderer>();
        _bulletRenderer.enabled = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(false);
        GameObject explosion = ObjectPool.Instance.SpawnExplosion();
        explosion.transform.position = transform.position;
        explosion.SetActive(true);
        explosion.GetComponent<ParticleSystem>().Play();
        

    }
    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }


}
