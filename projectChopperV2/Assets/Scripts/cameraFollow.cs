using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    [Header("Floats")]
    public float smoothSpeed = 0.125f;
    public float minY, maxY;

    [Header("Vectors")]
    public Vector3 offset;


    private Transform target;

    private void Start()
    {
        target = gameManager.Instance.player.transform;
    }
    private void LateUpdate()
    {
        Vector3 desiredPosition = new Vector3(transform.position.x, Mathf.Clamp(target.transform.position.y, minY, maxY), transform.position.z) + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position,desiredPosition,smoothSpeed);

        transform.position = smoothedPosition;
    }
}
