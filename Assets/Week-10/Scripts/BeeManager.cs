using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeManager : MonoBehaviour
{
    [SerializeField] GameObject bee;

    // Start is called before the first frame update
    void Start()
    {
        
        for (int i = 0; i < 10; i++)
        {
            GameObject newBee = Instantiate(bee);
            float randX = UnityEngine.Random.Range(-100f, 100f);
            float randY = UnityEngine.Random.Range(-100f, 100f);
            newBee.transform.position = new Vector2(randX, randY);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
