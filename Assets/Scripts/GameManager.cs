using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public enum GameState
{
    menu,
    inGame,
    pause,
    gameOver
}

public class GameManager : MonoBehaviour
{
    public static int puntosTotales = 0;
    public TextMeshProUGUI textMeshPro;

    public bool isPause = false;
    public bool isGame = true;
    public bool isGameOver = false;
    public GameObject PauseObjects;
    public GameObject GameOverObj;
    public AudioSource backgroundAudio;
    public AudioSource GMAudio;

    public static GameManager sharedInstance;
    [SerializeField] GameState currentGameState;
    public PlayerMovement movement;
    
    

    private void Awake()
    {
        if (sharedInstance == null)
            sharedInstance = this;
    }

    void Start()
    {
        currentGameState = GameState.inGame;
        movement = GameObject.Find("Player").GetComponent<PlayerMovement>();

        PauseObjects.SetActive(false);
    }

    private void Update()
    {
        textMeshPro.text = "Puntos Totales: " + puntosTotales.ToString();

        if (Input.GetKeyDown(KeyCode.P))
        {
            
            if (isPause)
                ResumeGame();
            else
                PauseGame();
        }



    }


    public void PauseGame()
    {
        isPause = true;
        isGame = false;
        Time.timeScale = 0f;
        PauseObjects.SetActive(true);
        backgroundAudio.Pause();
        currentGameState = GameState.pause;

    }

    public void ResumeGame()
    {
        isPause = false;
        isGame = true;
        Time.timeScale = 1f;
        PauseObjects.SetActive(false);
        backgroundAudio.Play();
        currentGameState = GameState.inGame;
    }

    public void GameOver()
    {
        isGameOver = true;
        isGame = false;
        Time.timeScale = 0f;
        GameOverObj.SetActive(true);
        backgroundAudio.Pause();
        currentGameState = GameState.gameOver;

    }

    public void ReturnToMM()
    {
        SceneManager.LoadScene(0);
    }

    public void Retry()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Aplication.Quit();
#endif
    }
}