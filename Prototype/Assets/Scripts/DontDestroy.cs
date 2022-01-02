using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    void Start()
    {
        //Debug.Log("DontDestroy Player");
        for (int i = 0; i < Object.FindObjectsOfType<DontDestroy>().Length; i++)
        {
            if (Object.FindObjectsOfType<DontDestroy>()[i] != this) 
            {
                
                if (Object.FindObjectsOfType<DontDestroy>()[i].name == gameObject.name)
                {                    
                    Destroy(Object.FindObjectsOfType<DontDestroy>()[i]);
                }
            }
        }
        Object.FindObjectOfType<DontDestroy>();
        DontDestroyOnLoad(gameObject);
    }

    
    void Update()
    {
        
    }
}
