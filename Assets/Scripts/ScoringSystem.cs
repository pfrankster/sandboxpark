using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringSystem : MonoBehaviour
{

    public AudioSource somcol; 

    void Start()
    {


    }


    void OnTriggerEnter(Collider other)
    {
        BoxCollider bc = GetComponent<BoxCollider>();
        bc.enabled = false;
        StartCoroutine(tocasom());
       
    }

    IEnumerator tocasom()
    {
        somcol = GetComponent<AudioSource>();
        somcol.Play();
        yield return new WaitWhile(() => somcol.isPlaying);
        ScoreManager.theScore++;
        Destroy(gameObject);

    }
}
