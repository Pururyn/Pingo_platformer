using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject penguin;
    public float timeOffset;
    public Vector3 posOffset;

    private Vector3 velocity;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position,
            penguin.transform.position + posOffset, ref velocity, timeOffset);
    }
}