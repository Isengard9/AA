using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    #region Instance

    public static GameManager instance;
    
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    #endregion

    #region Bools

    public static bool isGameStarted = false;
    public static bool isGameEnded = false;

    #endregion

    #region Canvas

    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject lostPanel;

    #endregion

    #region OnLevel

    public void OnLevelSuccess()
    {
        winPanel.SetActive(true);
        isGameEnded = true;
        isGameStarted = false;
    }

    public void OnLevelFailed()
    {
        isGameEnded = true;
        isGameStarted = false;
        lostPanel.SetActive(true);
    }

    #endregion

    #region Buttons

    public void StartButton()
    {
        isGameStarted = true;
        isGameEnded = false;
        startPanel.SetActive(false);
        BigBallController.instance.StartRotationMove();
        //GamePanel.SetActive(true);
    }
    
    public void NextButton()
    {
        var levelCounter = PlayerPrefs.GetInt("LevelId", 0);
        levelCounter += 1;
        PlayerPrefs.SetInt("LevelId", levelCounter);
        winPanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void RestartButton()
    {
        lostPanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    #endregion
   
}
