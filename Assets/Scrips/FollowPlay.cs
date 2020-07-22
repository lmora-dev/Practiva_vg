using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlay : MonoBehaviour
{
    Transform playerTransiti;

    public float camXOffSet;
    public float camYOffSet;
    public float camSpeed;

    public Vector3 min;
    public Vector3 max;



    void Start()
    {

        playerTransiti = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        SmoothMov();
        CameraMargen();
    }

    void SmoothMov()
    {
        Vector3 newPos = new Vector3(playerTransiti.position.x - camXOffSet, playerTransiti.position.x + camYOffSet, transform.position.z);
                            
        //lerp mueve cosas a dos posiciones
        transform.position = Vector3.Lerp(transform.position, newPos, camSpeed * Time.deltaTime);

    }

    void CameraMargen()
    {
        if(transform.position.x <= min.x)
        {
            transform.position = new Vector3(min.x, transform.position.y, transform.position.z);
        }

        if (transform.position.x >= max.x)
        {
            transform.position = new Vector3(max.x, transform.position.y, transform.position.z);
        }

        if (transform.position.y <= min.y)
        {
            transform.position = new Vector3(transform.position.x, min.y, transform.position.z);
        }
        if (transform.position.y >= max.y)
        {
            transform.position = new Vector3(transform.position.x, max.y, transform.position.z);
        }
    }
}
