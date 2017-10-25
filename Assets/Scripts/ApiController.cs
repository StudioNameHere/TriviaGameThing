using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ApiToken
{
    public string token;
    public Time created;
}

[System.Serializable]
public class ApiResponse
{
    public Time created;
    public ApiResponseQuestion[] results;
}

[System.Serializable]
public class ApiResponseQuestion
{
    public string category;
    public string type;
    public string difficulty;
    public string question;
    public string correct_answer;
    public string[] incorrect_answers;
}

public class ApiController : MonoBehaviour
{
    public ApiToken token;
    public ApiResponse response;

    // Generate Token
    public void generateToken()
    {
        // Start API CoRoutine
        StartCoroutine(IE_generateToken());
    }
    IEnumerator IE_generateToken()
    {
        WWW api = new WWW("https://opentdb.com/api_token.php?command=request");
        yield return api;

        if (string.IsNullOrEmpty(api.error))
        {
            token = JsonUtility.FromJson<ApiToken>(api.text);
            Debug.Log("IE_generateToken: Done!");
        }
        else
        {
            Debug.Log(api.error);
        }
    }

    // Generate Questions
    public void generateQuestions()
    {
        StartCoroutine( IE_generateQuestions() );
    }
    IEnumerator IE_generateQuestions()
    {
        WWW api = new WWW("https://opentdb.com/api.php?amount=10&token=" + token.token);
        yield return api;

        if (string.IsNullOrEmpty(api.error))
        {
            response = JsonUtility.FromJson<ApiResponse>(api.text);
            Debug.Log("IE_generateQuestions: Done!");
        }
        else
        {
            Debug.Log(api.error);
        }
    }

    // Generate Token & Questions
    public void generateGame()
    {
        StartCoroutine( IE_generateGame() );
    }
    IEnumerator IE_generateGame()
    {
        yield return StartCoroutine( IE_generateToken() );
        StartCoroutine( IE_generateQuestions() );
    }
}
