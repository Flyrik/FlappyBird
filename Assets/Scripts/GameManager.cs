
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour

{
    public Player player;
    public TMPro.TextMeshProUGUI scoreText;
    public GameObject gameOver;
    public GameObject playButton;

    private int score;

    private void Awake()
    {
        gameOver.SetActive(false);
        Application.targetFrameRate = 60;
        Pause();
    }

    public void Play()
    {
        score = 0;  
        scoreText.text = score.ToString();

        gameOver.SetActive(false);
        playButton.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        playButton.SetActive(true);
        Pause();
    }

    public void IncreaseScore()
    {
        score ++;
        scoreText.text = score.ToString();
    }

}
