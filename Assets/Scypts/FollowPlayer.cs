using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject ObjectFollow;
    public float offSet;
    public float offSetSmoothing;

    private Vector3 playerPosition;

    void LateUpdate()
    {
        // transform.position = ObjectFollow.transform.position + new Vector3(0, 0, -25);//axes x, y, z;
        //+= new Vector3(camSpeed * Time.deltaTime, 0, 0);
    }
    private void Update()
    {
        playerPosition = new Vector3(ObjectFollow.transform.position.x, transform.position.y, transform.position.z);
        if(ObjectFollow.transform.localScale.x>0f)
        {
            playerPosition = new Vector3(playerPosition.x + offSet, playerPosition.y, playerPosition.z);
        }
        {
            playerPosition = new Vector3(playerPosition.x - offSet, playerPosition.y, playerPosition.z);
        }

        transform.position = Vector3.Lerp(transform.position, playerPosition, offSetSmoothing * Time.deltaTime);
    }
}

