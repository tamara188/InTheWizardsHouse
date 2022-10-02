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
    public Animator anim;
    // Update is called once per frame
    void processAnimation(){
        anim.SetFloat("horizontal",500);
    }
    void Update()
    {
        processAnimation();
        if (Input.GetKey(KeyCode.A))
        {
            if(transform.position[0] > leftBound)
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
                cam.transform.position += Vector3.left * speed * Time.deltaTime;
                anim.SetFloat("horizontal",0);
            }
            
        }
        if (Input.GetKey(KeyCode.D))
        {
            if(transform.position[0] < rightBound)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
                cam.transform.position += Vector3.right * speed * Time.deltaTime;
                anim.SetFloat("horizontal",1);
            }

        }
        anim.SetFloat("horizontal",0.5f);
    }
}
