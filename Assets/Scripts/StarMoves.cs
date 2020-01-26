using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarMoves : MonoBehaviour
{
    public float spinVelocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0, spinVelocity * Time.deltaTime, 0);
    }
}
