using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverheadCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 offSet;

    // Start is called before the first frame update
    void Start()
    { 
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector3 velocity = new Vector3(1, 1, 1);
        //com lerp fica smooth
        //transform.position = Vector3.Lerp(target.position , offsetT.position, ref velocity, Time.deltaTime * 0.3f);
        transform.position = Vector3.Lerp(transform.position + offSet, target.position, 0.3f);
    }
}
