using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabdomObjSpawn : MonoBehaviour
{ 
     public Transform spawns;
     [SerializeField] GameObject[] objects;
     public float minSpawnTime;
     public float maxSpawnTime;
     private float spawnTime;
     private int spawnIndex;
 
     void Start()
     {
         SpawnObjects( objects, spawns, spawns );
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
     }
 }
