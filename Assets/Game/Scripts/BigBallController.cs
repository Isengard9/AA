using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BigBallRotationModifier
{
    [SerializeField] public float speed;
    [SerializeField] public float time;
}

public class BigBallController : MonoBehaviour
{

    #region Instance

    public static BigBallController instance;
    
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    #endregion

    [SerializeField] private List<BigBallRotationModifier> rotModifiers;

    #region BaseStats

    [SerializeField] private float speed = 0;
    [SerializeField] private float time = 0;

    #endregion

    #region Fields

    public Transform ballPosition;

    #endregion

    public void SetLevel(List<BigBallRotationModifier> modifier)
    {
        rotModifiers = modifier;
    }


    void Update()
    {
        if (GameManager.isGameEnded || !GameManager.isGameStarted)
            return;
        
        
        RotateTheBall();
    }

    private void RotateTheBall()
    {
        transform.Rotate(Vector3.up, speed);
    }

    public void StartRotationMove()
    {
        StartCoroutine(RotationMove());
    }

    private int index = 0;
    private IEnumerator RotationMove()
    {
        while (true)
        {
            if (rotModifiers[index].time == 0)
            {
                while (true)
                {
                    speed = rotModifiers[index].speed;
                    yield return null;
                }
            }
            else
            {
                speed = rotModifiers[index].speed;
                yield return new WaitForSeconds(rotModifiers[index].time);
            }
            index += 1;
            
            if (index >= rotModifiers.Count)
            {
                index = 0;
            }
        }

        
    }
}
