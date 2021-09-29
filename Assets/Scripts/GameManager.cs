using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject[] spawnPoints;
    public GameObject alien;
    public int maxAliensOnScreen;
    public int totalAliens;
    public float minSpawnTime;
    public float maxSpawnTime;
    public int aliensPerSpawn;

    private int aliensOnScreen = 0;
    private float generatedSpawnTime = 0;
    private float currentSpawnTime = 0;

        // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Accumulates the amount of time that has passes between each frame
        currentSpawnTime += Time.deltaTime;

        if (currentSpawnTime > generatedSpawnTime)
        {
            currentSpawnTime = 0;

            //SpawnTime randomizer, creates a time between minSpawnTime and maxSpawnTime
            generatedSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);

            //Check whether to spawn alien or not. 
            if (aliensPerSpawn > 0 && aliensOnScreen < totalAliens)
            {
                //creates array of where aliens spawn
                List<int> previousSpawnLocations = new List<int>();

                //Limits the amount of aliens at each spawn point
                if (aliensPerSpawn > spawnPoints.Length)
                {
                    aliensPerSpawn = spawnPoints.Length - 1;
                }

                //If aliensPerSpawn exceeds the maximum,then the amount of spawns will reduce.
                aliensPerSpawn = (aliensPerSpawn > totalAliens) ? 
                    aliensPerSpawn - totalAliens : aliensPerSpawn;

                //iterates for each spawned alien
                for (int i = 0; i < aliensPerSpawn; i++)
                {
                    if (aliensOnScreen < maxAliensOnScreen)
                    {
                        aliensOnScreen += 1;
                        int spawnPoint = -1;

                        while (spawnPoint == -1)
                        {
                            //produces a random number as a possible spawn point
                            int randomNumber = Random.Range(0, spawnPoints.Length - 1);

                            //checks the previousSpawnLocations array to see if that random number is an active spawn point.
                            //If there’s no match, then you have your spawn point.
                            //The number is added to the array and the spawnPoint is set
                            if (!previousSpawnLocations.Contains(randomNumber))
                            {
                                previousSpawnLocations.Add(randomNumber);
                                spawnPoint = randomNumber;
                            }
                        }

                        //grabs the spawn point based on the index that is generated 
                        GameObject spawnLocation = spawnPoints[spawnPoint];

                        //Spawn the alien
                        GameObject newAlien = Instantiate(alien) as GameObject;

                        //Positions the alien at the spawn point
                        newAlien.transform.position = spawnLocation.transform.position;

                        //Get reference to alien script
                        Alien alienScript = newAlien.GetComponent<Alien>();

                        //Set target to the players current position
                        alienScript.target = player.transform;

                        //Rotate Alien towards the target
                        Vector3 targetRotation = new Vector3(player.transform.position.x, newAlien.transform.position.y,
                            player.transform.position.z);
                        newAlien.transform.LookAt(targetRotation);
                    }
                }
            }
        }
    }
}
