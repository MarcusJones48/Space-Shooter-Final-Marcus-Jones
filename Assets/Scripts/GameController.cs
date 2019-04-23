using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject [] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text ScoreText;
    public Text restartText;
    public Text gameOverText;
    public Text winText;

    private int score;
    private bool restart;
    private bool gameOver;
    private bool win;
    public bool winCon;

    public AudioClip winMusic;
    public AudioClip loseMusic;
    public AudioSource musicSource;

    public BGScroller BGSpeed;
    public BGScroller SFSpeed;

    void Start()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        winText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine (SpawnWaves());
    }

    void Update()
    {
      if (restart)
        {
            restartText.text = "Press 'G' to Restart";
            if (Input.GetKeyDown (KeyCode.G))
            {
                SceneManager.LoadScene("Main");
            }
        }
    }

    IEnumerator SpawnWaves ()
    {
        yield return new WaitForSeconds (startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range (0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds (waveWait);

            if (gameOver)
            {
                restartText.text = "Press 'G' to Restart";
                restart = true;
                break;
            }
        }
    }
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        ScoreText.text = "Points: " + score;
        if (score >= 200)
        {
            winText.text = "You Win! Game created by Marcus Jones";
            gameOver = true;
            restart = true;
            BGSpeed.scrollSpeed = -10.00f;
            SFSpeed.scrollSpeed = -10.00f;


            musicSource.Stop();
            musicSource.clip = winMusic;
            musicSource.loop = false;
            musicSource.Play();
        }
    }

    public void GameOver ()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
        musicSource.Stop();
        musicSource.clip = loseMusic;
        musicSource.loop = false;
        musicSource.Play();
    }

    public void winCondition()
    {
        winCon = true;
    }
}
