using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    #endregion
   
    
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    #region Buttons

    public void StartButton()
    {
        isGameStarted = true;
        isGameEnded = false;
        startPanel.SetActive(false);
        //GamePanel.SetActive(true);
    }
    /*
    public void NextButton()
    {
        levelCounter += 1;
        PlayerPrefs.SetInt("LevelId", levelCounter);
        WinPanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void RestartButton()
    {
        LostPanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
*/
    #endregion
   
}
