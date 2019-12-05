using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour
{
    public bool isButton = true;
    public bool leftJoystick = true;
    public string buttonName;

    private Vector3 startPos;
    private Transform thisTransform;
    MeshRenderer mr;


    // Start is called before the first frame update
    void Start()
    {
        thisTransform = transform;
        startPos = thisTransform.position;
        mr = thisTransform.GetComponent<MeshRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if(isButton)
        {
            mr.enabled = Input.GetButton(buttonName);
        }
        else
        {
            if(leftJoystick)
            {
                Vector3 inputDirection = Vector3.zero;
                inputDirection.x = Input.GetAxis("LeftStickHorizontal");
                inputDirection.z = Input.GetAxis("LeftStickVertical");

                thisTransform.position = startPos + inputDirection;
            }
            else
            {
                Vector3 inputDirection = Vector3.zero;
                inputDirection.x = Input.GetAxis("RightStickHorizontal");
                inputDirection.z = Input.GetAxis("RightStickVertical");
                thisTransform.position = startPos + inputDirection;

            }
        }
        
    }
}
