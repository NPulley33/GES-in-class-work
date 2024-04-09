using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    [SerializeField] string LevelToLoad;

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene(LevelToLoad); //can load a level by int (build settings level index) or name
    }

}
