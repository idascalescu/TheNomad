using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyRotationScrypt : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 333) * Time.deltaTime);
    }
}
