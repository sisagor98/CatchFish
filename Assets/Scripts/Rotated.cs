using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotated : MonoBehaviour
{
    public float min_Z = 20f, max_Z = -20f;
    public float rotatedSpeed = 20f;
    private float rotationAngle;
    private bool rotatedRight;
    private bool CanRotated;

    private float initialY;
    private float intialMove;
    public float moveSpeed = 3f;

    // Start is called before the first frame update
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
        
        //transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }


    void Rotate()
    {
        if (!CanRotated)
            return;
        if (rotatedRight)
        {
            rotationAngle += rotatedSpeed * Time.deltaTime;
        }
        else
        {
            rotationAngle -= rotatedSpeed * Time.deltaTime;
        }

        transform.rotation = Quaternion.AngleAxis(rotationAngle, Vector3.forward);

        if (rotationAngle >= max_Z)
        {
            rotatedRight = false;
        }
        if (rotationAngle <= min_Z)
        {
            rotatedRight = true;
        }
    }


}
