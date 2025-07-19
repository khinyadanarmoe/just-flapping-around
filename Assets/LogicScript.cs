using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    // Start is called before the first frame update

    public int score = 0;
    public Text scoreText;
    public GameObject gameOverScreen;

    [ContextMenu("Reset Score")]
    public void incrementScore(int scoreIncrement)
    {
        score += scoreIncrement;
        Debug.Log($"Score updated: {score}");

        if (scoreText != null)
        {
            scoreText.text = score.ToString();
            Debug.Log($"Score text updated to: {scoreText.text}");
        }
        else
        {
            Debug.LogError("Score Text is null! Please assign it in the Inspector.");
        }

    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }


}
