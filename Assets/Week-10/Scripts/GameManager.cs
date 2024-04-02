using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] UnityEvent GameOverEvent;
    private static GameManager instance;
    private int totalPoints;

    private void Awake()
    {
        instance = this;
        Bee.BeeKilledEvent.AddListener(OnBeeKilled);

    }

    [ContextMenu("Do Test GameOverEvent")]
    private void TestGameOverEvent()
    { 
        GameOverEvent.Invoke();
    }

    private void OnBeeKilled(int points)
    {
        totalPoints += points;
        Debug.Log(totalPoints);
    }

    public static UnityEvent GetGameOverEvent()
    {
        return instance.GameOverEvent;
    }

}
