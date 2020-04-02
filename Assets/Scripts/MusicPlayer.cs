using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        //GetType() returns same type as current class. In this instance MusicPlayer as opposed to FindObjectsOfType<>. 
        if (FindObjectsOfType(GetType()).Length > 1 )
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
        // if there is more than one MusicPlayer, destroy the new one else don't destroy. This stops music stop/start
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
