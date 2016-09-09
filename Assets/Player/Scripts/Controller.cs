using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour
{
    private GameObject player;
    private Rigidbody rb;
    public float running_speed = 2.5f;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = running_speed * Input.GetAxis("Horizontal");
        float moveVertical = running_speed * Input.GetAxis("Vertical");

        //rb.AddForce(new Vector3(moveHorizontal, 0.0f, moveVertical));
        rb.velocity = (new Vector3(moveHorizontal, rb.velocity.y, moveVertical));
    }
}
