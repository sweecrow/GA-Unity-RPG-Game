using UnityEngine;
using System.Collections;

public class LevelUp : MonoBehaviour {

    //variables
    public int level;
    public float experience;
    public float experienceRequired;
    

    public float hp; //Test only

    //Methods 
	void Start ()
    {
        level = 1;
        hp = 100;
        experience = 0;
        experienceRequired = 100;
	}

	void Update ()
    {
        Exp();

        if(Input.GetKeyDown(KeyCode.M))
        {
            experience += 100;
        }
	}

    void RankUp()
    {
        level += 1;
        experience = 0;

        switch(level)
        {
            case 1:
                hp = 110;
                experienceRequired = 400;
                break;
            case 2:
                hp = 120;
                experienceRequired = 1000;
                break;
        }
    }

    void Exp()
    {
        if (experience >= experienceRequired)
            RankUp();

        
    }
}