using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshHidder : MonoBehaviour
{
    // Start is called before the first frame update

    private MeshRenderer m_mesh;
    private Collider m_collider;

    private void Awake()
    {
        m_mesh = GetComponent<MeshRenderer>();
        m_collider = GetComponent<Collider>();
        
    }


    void Start()
    {
        m_mesh.enabled = false;
        m_collider.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
