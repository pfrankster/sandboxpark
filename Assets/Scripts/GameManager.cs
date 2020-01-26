using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static AudioSource collectSound;
    public static int gameState;
    public GameObject stage0, stage1, stage2, stage3, stage4;
    private GameObject stg0, stg1, stg2, stg3,stg4 ;


    // Start is called before the first frame update
    private void Awake()
    {
        gameState = 0;
        
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        ManageGameState();
    }

    private void ManageGameState()
    {
        switch(gameState)
        {
            case 0:
                if (stg0 == null )
                {
                    stg0 = (GameObject)Instantiate(stage0, new Vector3(0, 0, 0), Quaternion.identity);
                    stg0.SetActive(true);
                }
                break;
            case 1:
                if (stg1 == null)
                {
                    stg0.SetActive(false);
                    stg1 = (GameObject)Instantiate(stage1, new Vector3(0, 0, 0), Quaternion.identity);
                    stg1.SetActive(true);
                }
                break;

            case 2:
                if (stg2 == null)
                {
                    stg1.SetActive(false);
                    stg2 = (GameObject)Instantiate(stage2, new Vector3(0, 0, 0), Quaternion.identity);
                    stg2.SetActive(true);
                }
                break;
            case 3:
                if (stg3 == null)
                {
                    stg2.SetActive(false);
                    stg3 = (GameObject)Instantiate(stage3, new Vector3(0, 0, 0), Quaternion.identity);
                    stg3.SetActive(true);
                }
                break;
            case 4:
                if (stg4 == null)
                {
                    stg3.SetActive(false);
                    stg4 = (GameObject)Instantiate(stage4, new Vector3(0, 0, 0), Quaternion.identity);
                    stg4.SetActive(true);
                }
                break;
        }
    }
}
