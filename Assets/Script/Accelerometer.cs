using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerometer : MonoBehaviour
{
    public float speed = 500f;
    public Rigidbody rigid;
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3 (Input.acceleration.x, 0.0f, Input.acceleration.y);
        // Adding force to rigidbody
        rigid.AddForce(movement * speed * Time.deltaTime);
    }
}
