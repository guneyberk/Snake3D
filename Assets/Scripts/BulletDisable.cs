using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDisable : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(false);
    }
    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
