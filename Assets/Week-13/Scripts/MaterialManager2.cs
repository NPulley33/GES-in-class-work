using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MaterialManager2
{

    private static Material mat_01;
    private static Material mat_02;
    private static Material mat_03;

    private static bool initialized;

    private static void Initialize()
    { 
        //mat_01 = (Material)Resources.Load("Materials/1");
        mat_01 = Resources.Load("Materials/1") as Material;
        mat_02 = Resources.Load("Materials/2") as Material;
        mat_02 = Resources.Load("Materials/3") as Material;

        initialized = true;
    }

    public static Material Get(int id)
    {
        if (initialized == false) Initialize();

        switch (id)
        {
            case 1:  return mat_01;
            case 2:  return mat_02;
            case 3:  return mat_03;
            default: return mat_01;
        }
    }

}   
