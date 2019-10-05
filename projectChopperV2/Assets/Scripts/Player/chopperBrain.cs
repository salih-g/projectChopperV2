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
    private Vector3 mouseMove;

    Vector3 velocity = Vector3.zero;

    [Header("GameObjects")]
    private GameObject turret;
    private GameObject crossHair;

    [Header("Cams")]
    private Camera mainCam;


    private void Start()
    {
        turret = gameObject.transform.GetChild(0).gameObject;
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        crossHair = gameObject.transform.GetChild(1).gameObject;
    }

    private void Update()
    {
        MouseTracking();
    }
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

    private void MouseTracking()
    {
        mouseMove = mainCam.ScreenToWorldPoint(Input.mousePosition);
        mouseMove.Set(mouseMove.x, mouseMove.y, transform.position.z);

        float angleRad = Mathf.Atan2(
           mouseMove.y - turret.transform.position.y,
           mouseMove.x - turret.transform.position.x
           );

        float angleDeg = (180 / Mathf.PI) * angleRad;

        turret.transform.rotation = Quaternion.Euler(0, 0, Mathf.Clamp(angleDeg, -80.0F, 41.15F));

        crossHair.transform.position = mouseMove;

    }
}
