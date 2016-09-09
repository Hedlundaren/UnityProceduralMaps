using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    public GameObject player;
    private Rigidbody rb;
    private Vector3 offset;
    public float camera_speed = 300f;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 movement = new Vector3(offset.x - (transform.position.x - player.transform.position.x), 0, offset.z - (transform.position.z - player.transform.position.z));
        movement = new Vector3(movement.x * Mathf.Abs(movement.x), 0.0f, movement.z * Mathf.Abs(movement.z));
        rb.AddForce(camera_speed * movement);
        rb.velocity = rb.velocity * 0.5f;
        // transform.position = player.transform.position + offset;
    }
}
