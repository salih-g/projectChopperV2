using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chopperBrain : MonoBehaviour
{
    [Header("Floats")]
    public float maxSpeed;
    private float horizontal;
    public float horizontalSpeed;
    public float clampXmin, clampXmax;
    public float clampYmin, clampYmax;


    [Header("Vectors")]
    public Vector3 gravitiy;
    public Vector3 thrust;
    public Vector3 horizontalThrust;
    private Vector3 clampPosition;


    Vector3 velocity = Vector3.zero;


 
    private void FixedUpdate()
    {
        chopperPhysics();
    }
    


    private void chopperPhysics()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        velocity += gravitiy * Time.deltaTime;



        if (horizontal!=0)
            velocity += (horizontal * horizontalThrust * Time.deltaTime) * horizontalSpeed;


        if (Input.GetKey(KeyCode.W))
        {
            velocity += thrust;
        }


        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        clampPosition = transform.position;


        clampPosition.x = Mathf.Clamp(clampPosition.x, clampXmin,clampXmax);
        clampPosition.y = Mathf.Clamp(clampPosition.y, clampYmin,clampYmax);


        transform.position = clampPosition;

        transform.position += velocity * Time.deltaTime;
    }
}
