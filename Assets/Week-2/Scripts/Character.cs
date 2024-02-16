using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    //bool didUpdate = false;
    //bool didLateUpdate = false;

    //most comments are notes from class


    //called before start: when the object is created/set awake/when program starts
    void Awake() {
        //Debug.Log("I am Awake"); //outputs to console for testing
    }

    // Start is called before the first frame update
    void Start() {
        //Debug.Log("I am Starting");
    }

    // Update is called once per frame
    void Update() {

        //if (didUpdate == false) { 
        //    Debug.Log("I am Updating");
        //    Debug.LogWarning("Stop"); //gives yeild sign/warning
        //    Debug.LogError("This should not be happening- email"); //throws an error in the console
        //    didUpdate = true;
        //}
    }

    //happens after all (?) other updates (calculations are already run)
    private void LateUpdate() {
        //if (didLateUpdate == false) {
        //    Debug.Log("Late Update");
        //    didLateUpdate = true;
        //}
    }

    //executes after a set amount of time - keeps updating through lag until game updates
    //use for physics related things
    private void FixedUpdate() {
        
    }


    private void OnEnable()
    {
        Debug.Log("enabled");
    }

    private void OnDisable()
    {
        Debug.Log("disabled");
    }

    //don't need a comment saying what this method does, but why it's needed & what it's used for
    //explain the thought process
    //30% comments to lines of code
    int Add2Numbers(int n1, int n2) { 
        return n1 + n2;
    }
}
