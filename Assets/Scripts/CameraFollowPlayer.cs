using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{

    public Transform target;
    public Vector3 target_Offset;

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

        //target_Offset = new Vector3(0, 15.26f, -19.22f);
        target_Offset = new Vector3(0, 1.4f, 0.98f);
        transform.position = target.position + target_Offset;
        
        
        
    }
}
