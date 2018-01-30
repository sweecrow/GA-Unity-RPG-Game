using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class XPsystem : MonoBehaviour {

    public int currentExp;
    public int currentLevel;

    public int[] toLevelUp;

    

    public Text xpText;
    public Text levelText;

    void Start()
    {
        xpText.text = "XP: " + currentExp.ToString();
        levelText.text = "Level: " + currentLevel.ToString();
    }

    void Update()
    {
        xpText.text = "XP: " + currentExp.ToString();
        levelText.text = "Level: " + currentLevel.ToString();

        if(currentExp >= toLevelUp[currentLevel])
        {
            currentLevel++;
        }

        
    }

    public void AddExperience (int experienceToAdd)
    {
        currentExp += experienceToAdd;
    }

    
}