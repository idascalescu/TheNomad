using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScrypt : MonoBehaviour
{
    private bool movingRight = false;

    public Transform groundDetection;
    public int maxHP = 100;
    public float speedEnemy;
    public float distance;

    int currentHealth;

    private void Update()
    {
        transform.Translate(Vector2.right * speedEnemy * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if (groundInfo.collider == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = true;
            }
        }
    }
}
