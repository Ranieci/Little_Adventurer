using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject losePanel;
    public GameObject winPanel;
    public int enemyCount = 2; 
    public bool isGameOver = false;
    public GameObject healthslider;
    public GameObject image1;
    public GameObject image2;
    public GameObject image3;

    void Awake()
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        losePanel.SetActive(false);
        winPanel.SetActive(false);
        enemyCount = FindObjectsOfType<EnemyHealth>().Length;
        Debug.Log("Enemy count: " + enemyCount);
    }
    
    public void GameOver()
    {
        isGameOver = true;
        if(healthslider != null)
            healthslider.SetActive(false);
            image1.SetActive(false);
            image2.SetActive(false);    
            image3.SetActive(false);
        losePanel.SetActive(true);
        if(AudioManager.instance != null)
            AudioManager.instance.PlayLoseSound();
    }

    public void EnemyKilled()
    {
        enemyCount--;
        Debug.Log("Enemy killed: " + enemyCount);
        if(enemyCount <= 0)
        {
            Invoke("Win", 2f);
        }
    }

    void Win()
    {
        isGameOver = true;
        if(healthslider != null)
            healthslider.SetActive(false);
            image1.SetActive(false);
            image2.SetActive(false);    
            image3.SetActive(false);
        winPanel.SetActive(true);
        if(AudioManager.instance != null)
            AudioManager.instance.PlayWinSound();
    }

    public void PlayAgain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
