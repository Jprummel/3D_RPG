using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyDataBase : MonoBehaviour {

    public List<BaseEnemy> enemies = new List<BaseEnemy>();
    private int _randomEnemy;

    public void AddEnemies()
    {
        if(GameInformation.PlayerLevel<=5){
            
            enemies.Add(new Rat());
            enemies.Add(new Goblin());
            enemies.Add(new GoblinChief());
        }
        else if (GameInformation.PlayerLevel > 5 && GameInformation.PlayerLevel <= 10)
        {
            enemies.Add(new Knight());
        }
        else if (GameInformation.PlayerLevel > 10 && GameInformation.PlayerLevel <= 15)
        {

        }
    }

    public BaseEnemy SpawnRandomEnemy()
    {
        AddEnemies();
        _randomEnemy = Random.Range(0, enemies.Count); //Gets a random enemy from the list
        Debug.Log(enemies[_randomEnemy].EnemyName);
        return enemies[_randomEnemy]; //Returns a random enemy from the enemies list
    }
}
