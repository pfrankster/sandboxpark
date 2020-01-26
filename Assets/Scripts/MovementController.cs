using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    Rigidbody rbDrone;
    private float upForce;
    public float initUpForce;


    public float sensibility = 0.3f;

    public Vector3 lastPosition; 
//movefoward - Pitch
    public float speedForward = 300;
    public float speedUpForce = 450;
    public float tiltAmountForward = 0;
    public float tiltVelocityForward;

//sideways - Roll
    private float speedSides = 300;
    private float tiltAmountSideways = 0;
    private float tiltVelocitySideways;




    //rotation - Yaw
    private float wantedRotation;
    private float currentYRotation;
    private float rotateAmountByKeys = 1.0f;
    private float rotationYVelocity;

    private void Awake()
    {
        rbDrone = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rbDrone.isKinematic = false;

        lastPosition = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        MoveUpDown();
        MoveForward();
        MoveSideways();
        Rotation();
        Fire();
        ClamplingSpeedValues();

        rbDrone.AddRelativeForce(Vector3.up * upForce);
        //inclinacao do movimento
        //rbDrone.rotation = Quaternion.Euler(new Vector3(tiltAmountForward, rbDrone.rotation.y, rbDrone.rotation.z));
        //rbDrone.rotation = Quaternion.Euler(new Vector3(tiltAmountForward, currentYRotation, rbDrone.rotation.z));
        rbDrone.rotation = Quaternion.Euler(new Vector3(tiltAmountForward, currentYRotation, tiltAmountSideways));

        if(transform.position.y >= 1000)
        {
            transform.position = new Vector3(0, 3, 0);
        }

        lastPosition = this.transform.position;
    }


    

    private void MoveSideways()
    {
        if (Input.GetAxis("RightStickHorizontal") > sensibility || Input.GetAxis("RightStickHorizontal") < sensibility)

        {
            rbDrone.AddRelativeForce(Vector3.left * Input.GetAxis("RightStickHorizontal") * speedSides * -1);
            tiltAmountSideways = Mathf.SmoothDamp(tiltAmountSideways, 20 * -Input.GetAxis("RightStickHorizontal"), ref tiltVelocitySideways, 0.1f);
        }

        /*
          
        if (Mathf.Abs(Input.GetAxis("RightStickHorizontal"))  > sensibility || Mathf.Abs( Input.GetAxis("RightStickHorizontal"))  < -sensibility)
        {
            rbDrone.AddRelativeForce(Vector3.left * Input.GetAxis("RightStickHorizontal") * speedSides * -1);
            tiltAmountSideways  = Mathf.SmoothDamp(tiltAmountSideways, 40 * Input.GetAxis("RightStickHorizontal"), ref tiltVelocitySideways, 0.1f);
        }
        else
        {
            tiltAmountSideways = Mathf.SmoothDamp(tiltAmountSideways, 0, ref tiltAmountSideways, 0.1f);
        }

        */

    }

    private Vector3 valocityToSmoothDampToZero;
    private void ClamplingSpeedValues()
    {
        float adjustlimit = 0.9f;
        //float maxVelocity = 55.0f; 
        //float maxVelocity = 75.0f; 
        float maxVelocity = 175.0f; 


        if( Mathf.Abs( Input.GetAxis("RightStickVertical")) > adjustlimit || Mathf.Abs( Input.GetAxis("RightStickVertical"))  < - adjustlimit)
        {
            rbDrone.velocity = Vector3.ClampMagnitude(rbDrone.velocity, Mathf.Lerp(rbDrone.velocity.magnitude, maxVelocity, Time.deltaTime * 5f));
        }

        if (Mathf.Abs(Input.GetAxis("RightStickHorizontal")) > adjustlimit || Mathf.Abs(Input.GetAxis("RightStickHorizontal")) < - adjustlimit)
        {
            rbDrone.velocity = Vector3.ClampMagnitude(rbDrone.velocity, Mathf.Lerp(rbDrone.velocity.magnitude, maxVelocity * 0.5f, Time.deltaTime * 5f));
        }

        if (Mathf.Abs(Input.GetAxis("LeftStickHorizontal")) > adjustlimit || Mathf.Abs(Input.GetAxis("LeftStickHorizontal")) < - adjustlimit)
        {
            rbDrone.velocity = Vector3.ClampMagnitude(rbDrone.velocity, Mathf.Lerp(rbDrone.velocity.magnitude, maxVelocity * 0.5f, Time.deltaTime * 5f));
        }

        if (Mathf.Abs(Input.GetAxis("LeftStickVertical")) > adjustlimit || Mathf.Abs(Input.GetAxis("LeftStickVertical")) < - adjustlimit)
        {
            rbDrone.velocity = Vector3.ClampMagnitude(rbDrone.velocity, Mathf.Lerp(rbDrone.velocity.magnitude, maxVelocity, Time.deltaTime * 5f));
        }
    }

    private void Fire()
    {
        if(Input.GetButton("YButton"))
        {
            transform.position = new Vector3(0, 5, 0);


        }
    }

    private void Rotation()
    {
        if (Input.GetAxis("LeftStickHorizontal") >= 0.35f)
        {
            wantedRotation += rotateAmountByKeys;
            //Debug.Log("Rotacionando para DIR");
        }
        else if(Input.GetAxis("LeftStickHorizontal") <= -0.35f)
        {
            wantedRotation -= rotateAmountByKeys;
            //Debug.Log("Rotacionando para ESQ");
        }

        currentYRotation = Mathf.SmoothDamp(currentYRotation, wantedRotation, ref rotationYVelocity, 0.25f);




    }


    private void MoveForward()
    {
//        if(Input.GetAxis("RightStickVertical") != 0)
        if(Input.GetAxis("RightStickVertical") > sensibility || Input.GetAxis("RightStickVertical") < sensibility)

        {
            rbDrone.AddRelativeForce(Vector3.forward * Input.GetAxis("RightStickVertical") * speedForward * -1);
            tiltAmountForward = Mathf.SmoothDamp(tiltAmountForward, 20 * - Input.GetAxis("RightStickVertical"), ref tiltVelocityForward, 0.1f);
        }
    }

    private void MoveUpDown()
    {
        //UP
        if (Input.GetAxis("LeftStickVertical") < sensibility && Input.GetAxis("LeftStickVertical") < 0)
        {
            upForce = speedUpForce;
            
        }

        //DOWN
        else  if (Input.GetAxis("LeftStickVertical") > sensibility )
        {
            upForce = -speedUpForce ;
            
        }
        //STABLE
        else 
        {
            
            //upForce = -98.1f;
            upForce = initUpForce;

            
            
        }
    }
}
