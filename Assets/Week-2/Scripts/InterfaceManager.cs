using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InterfaceManager : MonoBehaviour
{

    public TextMeshProUGUI label;
    private MathTypes mathType = MathTypes.Multiply;

    public void InputValue(int n) {
        Debug.Log(n);
        label.text += n.ToString();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Equals() {
        if (mathType == MathTypes.Divide) { 
            //divide numbers
        }
    }

    //an enum is a class of values that is defined by words
    public enum MathTypes { 
        Add, Subtract, Multiply, Divide
    }
}
