using UnityEngine;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(-1)]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int world { get; private set; } = 1;
    public int stage { get; private set; } = 1;
    public int lives { get; private set; } = 1;
    public int coins { get; private set; } = 0;

    public int coinPoints { get; private set; } = 0;
    private void Awake()
    {
        if (Instance != null) {
            DestroyImmediate(gameObject);
        } else {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (Instance == this) {
            Instance = null;
        }
    }

    private void Start()
    {
        Application.targetFrameRate = 60;
        if (SceneManager.GetActiveScene().name == "Main Menu")
        {
            NewGame();
        }
    }

    public void NewGame()
    {
        lives = 3;
        coins = 0;
        coinPoints = 0;
        LoadLevel(1, 1);
    }

    public void GameOver()
    {
        NewGame();
    }

    public void LoadLevel(int world, int stage)
    {
  

        this.world = world;
        this.stage = stage;

        SceneManager.LoadScene($"{world}-{stage}");
    }
    public void LoadNextLevel()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        // SceneManager.LoadScene(currentIndex + 1);
        // SceneManager.LoadScene("LevelComplete"); 
        LoadLevel(1, 2);
    }
    public void NextLevel()
    {
        LoadLevel(1,2);
    }

    public void ResetLevel(float delay)
    {
        CancelInvoke(nameof(ResetLevel));
        Invoke(nameof(ResetLevel), delay);
    }

    public void ResetLevel()
    {
        lives--;

        if (lives > 0) {
            LoadLevel(world, stage);
        } else {
            GameOver();
        }
    }

    public void AddCoin()
    {
        coins++;
        coinPoints += 100;
        if (coinPoints == 1000)
        {
            coinPoints = 0;
            AddLife();
        }
    }

    public void AddLife()
    {
        lives++;
    }

}
