using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public int levelStart = 1;
    public int power = 5;
    public int stamina = 20;
    public int numberOfLevelUp = 0;
    public int enemyHealth = 0;
    public int enemyDamage - 0
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int level = levelStart + numberOfLevelUp;
        int attackDamage = power * level;
        int playerHealth = stamina * level;
        bool alive = true;
        if (playerHealth >= 0) 
            {alive = false;}

    }
}
