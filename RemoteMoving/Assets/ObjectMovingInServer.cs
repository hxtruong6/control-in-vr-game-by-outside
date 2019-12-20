using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovingInServer : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;

    private float vertical, horizontal;

    public void FixedUpdate()
    {
        Vector3 direction = Vector3.forward * vertical + Vector3.right * horizontal;
        rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
    }

    public void MovingUpdate(float vertical, float horizontal)
    {
        this.vertical = vertical;
        this.horizontal = horizontal;
    }
}