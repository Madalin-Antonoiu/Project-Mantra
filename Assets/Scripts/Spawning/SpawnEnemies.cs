using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour {
   
    public GameObject enemy;
    public GameObject enemy1;
    public int xPos ;
    public int yPos;
    public int zPos ;
    public int enemyCount;


    void Update(){
        xPos = Random.Range(1,10);
        zPos = Random.Range(1,24);
        

        if(Input.GetKeyDown(KeyCode.P)){
            Instantiate(enemy, new Vector3(xPos, yPos,zPos), Quaternion.identity);
        }

        // At 95% drop enemies, at 80,70,60, 50 double etc
    }
}
