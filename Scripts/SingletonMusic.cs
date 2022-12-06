using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonMusic : MonoBehaviour
{
    private static SingletonMusic obje = null;

    void Awake()
    {
        if (obje == null)
        {
            obje = this;
            DontDestroyOnLoad(this);
        }
        else if (this != obje)
        {
            Destroy(gameObject);
        }
    }


}
