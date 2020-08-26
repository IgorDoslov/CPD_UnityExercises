using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class OrbitCamera : MonoBehaviour
{
    private Transform target { get { return transform.transform.parent.parent.parent; } }
    private Transform hRotate { get { return transform.transform.parent.parent; } }
    private Transform vRotate { get { return transform.transform.parent; } }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float hRot = Input.GetAxis("Horizontal");
        if (Input.GetMouseButton(0))
            hRot += Input.GetAxis("Mouse X");

        float vRot = Input.GetAxis("Vertical");
        if (Input.GetMouseButton(0))
            vRot += Input.GetAxis("Mouse Y");

        hRotate.Rotate(Vector3.up, hRot, Space.Self);

        var hr = hRotate.localRotation.eulerAngles;
        var vr = vRotate.localRotation.eulerAngles;

        vr.x = Math.Max(1, Math.Min(80, vr.x + vRot));
        hr.y += hRot;

        hRotate.localRotation = Quaternion.Euler(hr);
        vRotate.localRotation = Quaternion.Euler(vr);

        if (Input.GetKey(KeyCode.Z)) Distance(-1 * Time.deltaTime);
        if (Input.GetKey(KeyCode.X)) Distance(1 * Time.deltaTime);

        transform.LookAt(hRotate.position);

    }

    void Distance(float amount)
    {
        float dist = Math.Max(0, transform.localPosition.magnitude - amount);
        transform.localPosition = transform.localPosition.normalized * dist;
    }
}
