using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public ApiController ac;
    public ApiResponseQuestion[] questions;
    public ApiResponseQuestion currentQuestion;
    public int currentQuestionID;

    void Start()
    {
        
    }

    void PrepareGame()
    {
        // Generate Game
        ac.generateGame();
    }

    void LoadQuestion(int questionID)
    {
        currentQuestion = questions[questionID];
    }
}
