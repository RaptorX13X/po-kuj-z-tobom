using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillow : MonoBehaviour
{
    [SerializeField] private float radius;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerMenager playerMenager))
            return;
        //if(other.gameObject.TryGetComponent(out Health health)) health.Damage();
        RaycastHit2D[] pillowHits = Physics2D.CircleCastAll(transform.position, radius, Vector3.forward);
        Debug.Log(pillowHits.Length);
        foreach (RaycastHit2D hit in pillowHits)
        {
            if (hit.collider.gameObject.TryGetComponent(out PlayerMenager menager)) continue;
            if (hit.collider.gameObject.TryGetComponent(out Health health)) health.Damage();
        }
        Destroy(gameObject);
    }
}
