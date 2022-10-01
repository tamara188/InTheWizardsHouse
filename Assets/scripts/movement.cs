using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public GameObject cam;
    public GameObject player;
    public int speed;
    public int leftBound;
    public int rightBound;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if(transform.position[0] > leftBound)
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
                cam.transform.position += Vector3.left * speed * Time.deltaTime;
            }
            
        }
        if (Input.GetKey(KeyCode.D))
        {
            if(transform.position[0] < rightBound)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
                cam.transform.position += Vector3.right * speed * Time.deltaTime;
            }

        }
    }
}
