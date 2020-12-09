using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Game : MonoBehaviour
{
    public int score, highscore;
    private int currentMaxDistance, previousMaxDistance, scoreDistance, scoreGems;
    [SerializeField]
    private Player player;
    [SerializeField]
    private GameSpeed gameSpeed;
    [SerializeField]
    private TextMeshPro specialScoreText;
    [SerializeField]
    private TextMeshProUGUI scoreText, hiscoreText;

    private void Awake()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        // Fade in the game music to 0.6 volume in 4 sec.
        StartCoroutine(AudioSourceFade.StartFade(audioSource, 4, (float)0.5));
    }
    // Start is called before the first frame update.
    void Start()
    {
        // Start score from 0 each time game is loaded again.
        Load();

        // Save the hiscore
        highscore = PlayerPrefs.GetInt("Highscore", 0);

        hiscoreText.text = "Best: " + highscore;
        UpdateScore();
    }

    private void Update()
    {
        // Save player's last frame distance and current max distance.
        previousMaxDistance = currentMaxDistance;
        currentMaxDistance = player.maxDistance;

        // If max distance changes, call adding (and update) score.
        if (currentMaxDistance > previousMaxDistance)
        {
            // Update score gained from distance.
            overwriteDistanceScore(currentMaxDistance);
        }

        // If highscore is beaten by score, show that instead.
        if (score > highscore)
        {
            hiscoreText.text = "Best: " + score;
        }

        // If new distance is dividable by 25, check for gamespeed updates.
        if (currentMaxDistance % 25 == 0 && currentMaxDistance <= 300)
        {
            gameSpeed.SetGameSpeed(currentMaxDistance);
        }
    }

    // Distance score must overwrite last state of the distance score.
    // Also do the distance score calculation here.
    public void overwriteDistanceScore(int distance)
    {
        // 30 points per y distance.
        scoreDistance = distance * 30;
        UpdateScore();
    }

    public void addCollectiblesScore(int points)
    {
        scoreGems += points;
        showCollectiblesScore(points);
        StartCoroutine(showCollectiblesScore(points));
        UpdateScore();
    }

    public IEnumerator showCollectiblesScore(int points)
    {
        // Show the big score drop
        specialScoreText.text = "+ " + points.ToString();

        // Make the game wait 2 seconds before deleting the text once again.
        yield return new WaitForSeconds(1f);

        // Reset the text
        specialScoreText.text = "";
        }

    private void Save()
    {
        // PlayerPrefs can save info as key/value pair in the system.
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.SetInt("TotalScore", PlayerPrefs.GetInt("TotalScore", 0) + score);
    }

    private void Load()
    {
        // Load info saved in the key. Second parameter is "default", if the key does not exist.
        score = PlayerPrefs.GetInt("Score", 0);
    }

    public void EndGame()
    {
        // Set game speed to normal.
        Time.timeScale = 1F;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;

        // If the game ends, save this games score and add it to total score
        Save();

        // Check if score is higher than hiscore
        if (score > highscore)
        {
            PlayerPrefs.SetInt("Highscore", score);
        }

        // Load game over scene
        SceneManager.LoadScene("GameOver");
    }

    public void UpdateScore()
    {
        // Calculate score based on distance and gems
        score = scoreDistance + scoreGems;

        // Assign current score to the UI
        scoreText.text = score.ToString();
    }
}
