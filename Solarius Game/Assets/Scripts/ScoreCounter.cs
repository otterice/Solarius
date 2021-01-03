using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{

    public static int scoreValue = 0;
    Text score;
    GameSession gameSession;

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
        gameSession = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + gameSession.GetScore().ToString();
    }
}
