using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button[] buttons;
    bool gameOver;
    int score;
    public Text scoreText;

    public void Exit()
    {
        Application.Quit();
    }

    public void GameOver()
    {
        gameOver = true;

        foreach (Button button in buttons)
        {
            button.gameObject.SetActive(true);
        }
    }

    public void Pause()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void Menu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void ScoreUpdate()
    {
        if (!gameOver)
        {
            score += 1;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        score = 0;
        InvokeRepeating("ScoreUpdate", 1.0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;
    }
}
