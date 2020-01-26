using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{
    private int currentCameraId;

    //lista de cameras
    public Camera fpvCamera;
    public Camera overheadCamera;
    public Camera pilotCamera;
    public Text  m_MessageText;

    // Start is called before the first frame update
    private void Awake()
    {
        currentCameraId = 0; 
        
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("BButton"))
        {
            currentCameraId++;
            if (currentCameraId > 2)
            { currentCameraId = 0; }

            SwitchCamera(currentCameraId);
        }
        /*         m_MessageText.text =
                "Joystick identificado: " + Input.GetJoystickNames()[0] + "\n" +
                "LeftHorizontal   " + Input.GetAxis("LeftStickHorizontal") +
                "\nLeftVertical   " + Input.GetAxis("LeftStickVertical") +
                "\nRightHorizontal   " + Input.GetAxis("RightStickHorizontal") +

                "\nRightVertical   " + Input.GetAxis("RightStickVertical") +
                "\n\n" + 
                "LeftHor - Raw   " + Input.GetAxisRaw("LeftStickHorizontal") +
                "\nLeftVer - Raw   " + Input.GetAxisRaw("LeftStickVertical") +
                "\nRightHor - Raw   " + Input.GetAxisRaw("RightStickHorizontal") +

                "\nRightVer - Raw   " + Input.GetAxisRaw("RightStickVertical") +

                "";
                */
        m_MessageText.text = "";
    }

    private void SwitchCamera(int cCam)
    {
        DisableCameras();

        switch (cCam)
        {
            case 0:
                fpvCamera.enabled = true;
                break;
            case 1:
                overheadCamera.enabled = true;
                break;
            case 2:
                pilotCamera.enabled = true;
                break;
            default :
                fpvCamera.enabled = true;
                break;

        }
    }

    private void DisableCameras()
    {
        fpvCamera.enabled = false;
        overheadCamera.enabled = false;
        pilotCamera.enabled = false;
    }
}
