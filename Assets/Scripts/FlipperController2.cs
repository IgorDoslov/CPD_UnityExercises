using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class FlipperController2 : MonoBehaviour
{
    public float speed = 10.0f;
    public float maxZRot = 30.0f;
    public float minZRot = -30.0f;
    public KeyCode key;

    float rotTime = 0.0f;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetKey(key))
        {
            rotTime += Time.deltaTime * speed;
        }
        else
        {
            rotTime -= Time.deltaTime * speed;
        }

        rotTime = Mathf.Clamp(rotTime, 0, 1);

        rb.MoveRotation(Quaternion.Euler(0, 0, Mathf.Lerp(minZRot, maxZRot, rotTime)));
    }
}
