using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coletavel : MonoBehaviour
{

    public AudioSource som;
    // Start is called before the first frame update
    void Start()
    {
        som = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        DisableCollision();
        //ScoreManager.theScore++;
        //CallDeath();
        StartCoroutine(CallDeath());
    }

    private void DisableCollision()
    {
        BoxCollider bc = GetComponent<BoxCollider>();
        bc.enabled = false;
    }

    private IEnumerator CallDeath()
    {
        yield return new WaitWhile(() => som.isPlaying);
        //yield return WaitForSeconds(som.clip.length);
        som.Play();
        yield return new WaitWhile(() => som.isPlaying);
        //Destroy(gameObject, somcol.clip.length);
        Destroy(gameObject);
    }
}
