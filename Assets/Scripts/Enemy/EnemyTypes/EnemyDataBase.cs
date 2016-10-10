using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyDataBase {

    private Party _party = GameObject.FindGameObjectWithTag(Tags.PARTYMANAGER).GetComponent<Party>();
    public List<BaseEnemy> enemies = new List<BaseEnemy>();
    private int _randomEnemy;

    public void AddEnemies()
    {
        if(_party.characters[0].Level<=5){
            
            enemies.Add(new Rat());
            enemies.Add(new Goblin());
            enemies.Add(new GoblinChief());
        }
        else if (_party.characters[0].Level > 5 && _party.characters[0].Level <= 10)
        {
            enemies.Add(new Knight());
        }
        else if (_party.characters[0].Level > 10 && _party.characters[0].Level <= 15)
        {

        }
    }

    public BaseEnemy SpawnRandomEnemy()
    {
        AddEnemies();
        _randomEnemy = Random.Range(0, enemies.Count); //Gets a random enemy from the list
        Debug.Log(enemies[_randomEnemy].Name);
        return enemies[_randomEnemy]; //Returns a random enemy from the enemies list
    }
}
