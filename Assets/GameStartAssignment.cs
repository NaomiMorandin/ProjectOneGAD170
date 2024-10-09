using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // initial assignment of stats for use in update scripts.
    public int level = 1;
    public int power = 5;
    public int stamina = 20;
    public int expThreshold = 0;
    public int enemyHealth = 0;
    public int enemyDamage = 0;
    public int exp = 0;
    public int attackDamage = 0;
    public int playerHealth = 0;
    public GameObject hp;
    public GameObject fightButton;
    public GameObject fightButtonText;
    public GameObject eventText;
    public GameObject enemyHealthText;
    public bool enemyPresent = false;

    bool playerAlive(int a) {
        //Script to return if player is alive or dead
        if (a >= 0)
        {
            return false;
        }
        else
        {
            return true; }
    }
    // Start is called before the first frame update
    void Start()
    {
        expThreshold = 50 * level;
        // sets exp threshold for initial level up, future levels check under update

        int sceneSelector = (UnityEngine.Random.Range(1, 6));
        //scene selector picks a random number 1 through 5, switch has 5 cases assigned to it that will be chosen based on randomInt

        StatSet();
        hp.GetComponent<TextMeshProUGUI>().text = "HP: " + playerHealth;


    }
    // Update is called once per frame
    void Update()
    {
        if (exp == expThreshold)
        {
            //script that checks if the exp tally equals the threshold, if it does it increases level by 1 and sets the threshold to new value
            level++;
            expThreshold = 50 * level;
            exp = 0;

        }
        
        playerAlive(playerHealth);
        // tells the playerAlive bool what value playerHealth is currently set to, replaces int a in the script with playerHealth

        if (enemyPresent == true)
        {
            fightButtonText.GetComponent<TextMeshProUGUI>().text = "Attack";

        }
        else
        {
            eventText.GetComponent<TextMeshProUGUI>().text = "An enemy is approaching";
            fightButtonText.GetComponent<TextMeshProUGUI>().text = "fight";
        }
        // if else statement to change text for enemy being present

        // prints player health to UI





    }
    public void WhenPressed()
    {
       if (enemyPresent == false)
        {
            enemyPresent = true;
            eventText.GetComponent<TextMeshProUGUI>().text = "A Skeleton appears!";
            enemyHealthText.GetComponent<TextMeshProUGUI>().text = "Enemy HP:" + enemyHealth;
            StatSet();
        }
       else
        {
            Fight();
            
        }
       // button press spawns an enemy or performs a fight if an enemy is present


    }
    public void Fight()
    {
        
        if (enemyHealth <= 0)
        {
            enemyPresent = false;
            eventText.GetComponent<TextMeshProUGUI>().text = "The skeleton clatters to the floor dead... again.";
        }
        else if (enemyHealth > 0)
        {
            enemyHealth = enemyHealth - attackDamage;
            enemyHealthText.GetComponent<TextMeshProUGUI>().text = "Enemy HP:" + enemyHealth;
            playerHealth = playerHealth - enemyDamage;
            hp.GetComponent<TextMeshProUGUI>().text = "HP: " + playerHealth;
        }


    }
    public void StatSet()
    {
        int attackDamage = power * level;
        int playerHealth = stamina * level;
        int enemyHealth = 4 * level;
        int enemyDamage = 3 * level;
    }

}
