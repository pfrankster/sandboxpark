using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public GameObject scoreText;
    public static int theScore;


    // Start is called before the first frame update
    void Start()
    {
            scoreText.GetComponent<Text>().text = "";
        
    }

    // Update is called once per frame
    void Update()
    {
        string currentGS = GameManager.gameState.ToString();

        if (GameManager.gameState == 0)
        {
            scoreText.GetComponent<Text>().text = " GS: "+ currentGS + " Bases: " + theScore;
            if (theScore == 4)
            {
                theScore = 0;
                //SceneManager.LoadScene("MainScene");
                GameManager.gameState++;

            }
        }


        if ( GameManager.gameState == 1)
        {
            scoreText.GetComponent<Text>().text = " GS: " + currentGS +  "Estrelas: " + theScore;
            if (theScore == 10)
            {
                theScore = 0;
                //SceneManager.LoadScene("MainScene");
                GameManager.gameState++;

            }
        }

        if ( GameManager.gameState == 2)
        {
            scoreText.GetComponent<Text>().text = " GS: " + currentGS +  "Letras: " + theScore;
            if (theScore == 3)
            {
                theScore = 0;
                //SceneManager.LoadScene("MainScene");
                GameManager.gameState++;

            }
        }

        if ( GameManager.gameState == 3)
        {
            scoreText.GetComponent<Text>().text = " GS: " + currentGS +  "Arcos: " + theScore;
            if (theScore == 35)
            {
                theScore = 0;
                //SceneManager.LoadScene("MainScene");
                GameManager.gameState++;

            }
        }

        if ( GameManager.gameState == 4)
        {
            scoreText.GetComponent<Text>().text = " GS: " + currentGS +  "GAME OVER - RETORNE TO RESET";
            if (theScore == 20)
            {
                theScore = 0;
                //SceneManager.LoadScene("MainScene");
                GameManager.gameState++;

            }
        }
    }
}
