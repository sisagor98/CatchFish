using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HockMoveScript : MonoBehaviour
{
    public float min_Z = -20f, max_Z=20f;
    public float rotatedSpeed = 20f;
    private float rotationAngle;
    public bool rotatedRight;
    private bool CanRotated;

    public float moveSpeed = 3f;
    private float intialMove;


    public float minY = -5f;
    private float initialY;


    private bool moveDown;

    //private RopeRenderer ropeRenderer;

    void Start()
    {
        initialY = transform.position.y;
        intialMove = moveSpeed;

        CanRotated = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
        GetInput();
        MoveRope();
    }

    void Rotate()
    {
        if (!CanRotated)
        {
            return;
        }
        else if (rotatedRight)
        {
            rotationAngle += rotatedSpeed * Time.deltaTime;
        }
        else
        {
            rotationAngle -= rotatedSpeed * Time.deltaTime;     
        }

        transform.rotation = Quaternion.AngleAxis(rotationAngle, Vector3.forward);

        if(rotationAngle > max_Z)
        {
            rotatedRight = false;
        }
        else if (rotationAngle < min_Z)
        {
            rotatedRight = true;
        }
    }



    void GetInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (CanRotated)
            {
                CanRotated = false;
                moveDown = true;

            }
        }
    }
    void MoveRope()
    {
        if (CanRotated)
            return;
        if (!CanRotated)
        {
            Vector3 temp = transform.position;


            if (moveDown)
            {
                temp -= transform.up * Time.deltaTime * moveSpeed;

            }
            else
            {
                temp += transform.up * Time.deltaTime * moveSpeed;
            }

            transform.position = temp;
            if (temp.y <= minY)
            {
                moveDown = false;
            }
            if (temp.y >= initialY)
            {
                CanRotated = true;
                moveSpeed = intialMove;
            }

        }
    }
}
