using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObjSpawn : MonoBehaviour
{ 
     public Transform spawns;
     [SerializeField] GameObject[] objects;
     private float minSpawnTime = 10f;
     private float maxSpawnTime = 20f;
     private float spawnTime;
     private float difficulty;
     private float minDifficulty;
     private float maxDifficulty;
     private int spawnIndex;
 
     void Start()
     {
         difficulty = 60f;
         spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
         minDifficulty = minSpawnTime / 2f;
         maxDifficulty = maxSpawnTime /2f;
     }
 
     private void SpawnObjects( GameObject[] gameObjects, Transform locations, Transform Quaternion)
     {
 
         int gameObjectIndex = Random.Range( 0, gameObjects.Length );
         Instantiate(gameObjects[gameObjectIndex], locations.position, Quaternion.rotation);
         spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
     }

      void Update() 
     {    
         spawnTime = spawnTime - Time.deltaTime;
         Invoke("SpawnObjects", spawnTime);   
         if (spawnTime <= 0)
         {
             SpawnObjects( objects, spawns, spawns );
         }  
         IncreaseDifficulty();
     }

     void IncreaseDifficulty()
     {
         difficulty = difficulty - Time.deltaTime;
         if(difficulty <= 0)
         {
             if(minSpawnTime > minDifficulty)
             {
                 minSpawnTime = minSpawnTime - 0.1f;
             }
             if(maxSpawnTime > maxDifficulty)
             {
                 maxSpawnTime = maxSpawnTime - 0.1f;
             }
             difficulty = 60f;
         }
     }
 }
