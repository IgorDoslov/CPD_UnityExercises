using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCon : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody myRB;

    private Vector3 moveInput;
    private Vector3 moveVelocity;

    private Camera mainCamera;

    public GunController theGun;

    public bool useController;

    private Controls controls;
    // Start is called before the first frame update
    void Start()
    {
        controls = new Controls();
        controls.Enable();
        myRB = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        var dir = controls.Player.Move.ReadValue<Vector2>();

        moveInput = new Vector3(dir.x, 0f, dir.y);
        //moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * moveSpeed;

        // Rotate with mouse
        if (!useController)
        {
            Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
            float rayLength;

            if (groundPlane.Raycast(cameraRay, out rayLength))
            {
                Vector3 pointToLook = cameraRay.GetPoint(rayLength);
                Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);

                transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
            }

            if (Input.GetMouseButtonDown(0))
            {
                theGun.isFiring = true;
            }
            if (Input.GetMouseButtonUp(0))
            {
                theGun.isFiring = false;
            }
        }

        // Rotate with controller
        if(useController)
        {
            Vector3 playerDirection = Vector3.right * Input.GetAxisRaw("RHorizontal") 
                + Vector3.forward * -Input.GetAxisRaw("RVertical");
            if(playerDirection.sqrMagnitude > 0.0f)
            {
                transform.rotation = Quaternion.LookRotation(playerDirection, Vector3.up);
            }

            if (/*Input.GetKeyDown(KeyCode.Joystick1Button5)*/Input.GetAxisRaw("RHorizontal") != 0.0f || Input.GetAxisRaw("RVertical") != 0.0)
            {
                theGun.isFiring = true;
            }

            if (/*Input.GetKeyUp(KeyCode.Joystick1Button5)*/Input.GetAxisRaw("RHorizontal") == 0.0f && Input.GetAxisRaw("RVertical") == 0.0)
            {
                theGun.isFiring = false;
            }
        }
    }

    void FixedUpdate()
    {
        myRB.velocity = moveVelocity;
    }
}
