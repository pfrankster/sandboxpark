using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotorHelice : MonoBehaviour
{
    public float speedHelice;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("LeftStickVertical") < -0.02 )
            this.transform.Rotate(0,  speedHelice * Time.deltaTime, 0);
        else
        {
            this.transform.Rotate(0, speedHelice * 0.5f * Time.deltaTime, 0);
        }
    }
}
