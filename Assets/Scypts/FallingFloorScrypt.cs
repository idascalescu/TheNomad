using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingFloorScrypt : MonoBehaviour
{
    Rigidbody2D rbd;
    
    void Start()
    {
        rbd = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            Invoke("DropPlatfrom", 0.3f);
            Destroy(gameObject,2f);
        }
    }
    void DropPlatfrom()
    {
        rbd.isKinematic = false;
    }

}
