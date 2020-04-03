using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    Text playerHealth;
    Player player;
    
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GetComponent<Text>();
        player = FindObjectOfType<Player>();
    }
    
    // Update is called once per frame
    void Update()
    {
        playerHealth.text = player.GetHealth().ToString();

    }
    
}
