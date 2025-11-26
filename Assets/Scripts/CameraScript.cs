using UnityEngine;

public class CameraScript : MonoBehaviour
{
    Transform playerTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 playerPos2D = playerTransform.position;
        playerPos2D.z = -10; //default camera depth for 2D

        transform.position = Vector3.Lerp(transform.position, playerPos2D, Vector3.Distance(playerPos2D, transform.position)/100); //Temp
    }
}
