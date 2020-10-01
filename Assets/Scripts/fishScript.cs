using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishScript : MonoBehaviour
{
    public float movespeed = 4f;
    public bool MoveLeft;

    private void Update()
    {
        if (MoveLeft)
        {
            Vector3 temp = transform.position;
            //transform.localScale = new Vector2(1.793041f, 1.539274f);
           // transform.rotation.y = 180f;
            temp.x += movespeed * Time.deltaTime;
            transform.position= temp;
        }
        else
        {
            Vector3 temp =transform.position;
            temp.x -= movespeed * Time.deltaTime;
            transform.position = temp;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "colider")
        {
            MoveLeft = !MoveLeft;

            Debug.Log("colide");
            
        }
    }
}
