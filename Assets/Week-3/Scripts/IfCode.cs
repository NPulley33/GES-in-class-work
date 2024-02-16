using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class IfCode : MonoBehaviour
{

    public int apples;
    public int bananas;

    // Start is called before the first frame update
    void Start()
    {

    }

    [ContextMenu("Execute If Text")]
    void ExectueIfText() {

        bool has4applesOr2bananas = apples == 4 && bananas == 2;
        bool has3OR4apples = apples == 4 || apples == 3;
        int moneyOwed2 = 0;

        int moneyOwed = (apples == 4 && bananas == 2) ? 200 : -200; // ? ifTrueValue : ifFalseValue
        //this if/else statement is the same as the line above
        //if apples is 4 OR apples is 3
        if (has3OR4apples)
        {
            Debug.Log(string.Format("We have {0} apples", apples));
            moneyOwed2 = 200;
        }
        //else still connected to the first previous if statement
        else
        {
            Debug.Log("We do not have 3 or 4 apples");
            moneyOwed2 = -200;
        }
        Debug.Log(moneyOwed2);

        //if apples is 4 AND bananas is 2
        if (has4applesOr2bananas) {
            Debug.Log("We have 4 apples and 2 bananas");
        }
        //if apples is 2 OR apples is 4 and bananas is more than 0
        else if (apples == 2 || (apples == 4 && bananas > 0)) { 
            
        }
    }

}
