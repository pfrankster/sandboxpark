using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringArcSystem : MonoBehaviour
{
    public AudioSource som;

    public MeshRenderer mrInnerArc;
    public MeshRenderer mrOutArc;
    public Material hitedLight;

    private MeshRenderer[] msr;
    List<MeshRenderer> entrega; 
    // Start is called before the first frame update

    void Start()
    {
        msr = GetComponentsInChildren<MeshRenderer>();
        mrInnerArc = msr[0];
        mrOutArc = msr[1];
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        MeshCollider mc = GetComponent<MeshCollider>();
        mc.enabled = false;

        som = GetComponent<AudioSource>();
        som.Play();

        //mrOutArc.material.SetColor("_Color", Color.gray);


        //mrInnerArc.material = greenLight;

        //Funciona
        //mrInnerArc.material.SetColor("_Color", Color.white);
        //mrOutArc.material.SetColor("_Color", Color.green);

        //hitedLight.SetColor("_Color", Color.yellow);

        mrOutArc.material = hitedLight;



        ScoreManager.theScore++;

    }
}
