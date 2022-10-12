using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityTemplateProjects.Systems;

public class SmallBallManager : MonoBehaviour
{
    
    #region Instance

    public static SmallBallManager instance;
    
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    #endregion

    #region Lists

    [SerializeField] private List<Vector3> smallBallPositions = new List<Vector3>();
    [SerializeField] private List<SmallBallController> smallBalls = new List<SmallBallController>();

    #endregion

    #region Definitions

    [SerializeField] private SmallBallController smallBallController;
    [SerializeField] private GameObject smallBall;
    [SerializeField] private GameObject smallBallPrefab;

    [SerializeField] private Vector3 startPoint = new Vector3(0, 0, -4);
    [SerializeField] private int smallBallCount = 7;

    #endregion
    
    void Start()
    {
        CreateSmallBalls();
    }


    void Update()
    {
        
    }

    private void CreateSmallBalls()
    {
        for (int i = 0; i < smallBallCount; i++)
        {
            smallBall = Instantiate(smallBallPrefab, transform);
            smallBall.transform.localPosition = startPoint;
            smallBallController = smallBall.GetComponent<SmallBallController>();
            AddToSmallBallList(smallBallController);
        }
        
        SortTheBalls();
        SetSmallBall();
    }

    private void SetSmallBall()
    {
        smallBall = smallBalls[0].gameObject;
        
        smallBallController = smallBalls[0];
        
        smallBallController.amINextBall = true;
    }

    private void SortTheBalls()
    {
        var count = FindTheLessCount();
        
        for (int i = 0; i < count; i++)
        {
            smallBalls[i].transform.localPosition = smallBallPositions[i];
        }
        
    }

    private int FindTheLessCount()
    {
        var count = 0;
        count = smallBallPositions.Count < smallBalls.Count ? smallBallPositions.Count : smallBalls.Count;

        return count;
    }

    public void SetSmallBallCount(int ball)
    {
        smallBallCount = ball;
    }

    #region Add/Remove List

    private void AddToSmallBallList(SmallBallController ball)
    {
        smallBalls.Add(ball);
    }
    
    public void RemoveFromSmallBallList(SmallBallController ball)
    {
        smallBalls.Remove(ball);
        SortTheBalls();
        SetSmallBall();
    }

    #endregion

    
}
