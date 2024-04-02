using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bee : MonoBehaviour
{
    /// <summary>
    /// Arg: points
    /// </summary>
    public static UnityEvent<int> BeeKilledEvent = new UnityEvent<int>();

    //add a summary comment over (///) to tell what arguments should be since they won't have names
    //public static UnityAction<int, string, Bee, bool> BeeKilledEvent; //can have multiple arguments

    // Start is called before the first frame update
    void Start()
    {
        //subscribing to the event
        GameManager.GetGameOverEvent().AddListener(OnGameOver);
    }

    void OnGameOver()
    {
        Destroy(gameObject);
    }

    [ContextMenu("Kill Bee")]
    private void KillBee()
    {
        BeeKilledEvent.Invoke(3);
        Destroy(gameObject);
    }

}
