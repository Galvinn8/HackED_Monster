using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject[] monsterReference; //we are going to create copy of the monster objects, an array!

    private GameObject spawnedMonster;

    [SerializeField  ]
    private Transform leftPos, rightPos;

    private int randomIndex;
    private int randomSide;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMonsters());  //call the corountian methods
    }

    IEnumerator SpawnMonsters() {
        //run forever
        while (true)
        {
            // since you have yield statement, it will wait for 1-5 second between each iteration
            yield return new WaitForSeconds(Random.Range(1, 5));   // between every 1 - 5 seocnd, we will spawn new mosntes
            randomIndex = Random.Range(0, monsterReference.Length);  // select randomly from the enermy we have
            randomSide = Random.Range(0, 2);

            spawnedMonster = Instantiate(monsterReference[randomIndex]);  // create copy of the monster, like a list

            //left side
            if (randomSide == 0)
            {
                spawnedMonster.transform.position = leftPos.position;  // in the game, we set attach the leftposition and right position to the reference variable leftPos. rightPOS
                spawnedMonster.GetComponent<Monster>().speed = Random.Range(4, 10);
            }

            //right side
            if (randomSide == 1)
            {
                spawnedMonster.transform.position = rightPos.position;  // in the game, we set attach the leftposition and right position to the reference variable leftPos. rightPOS
                spawnedMonster.GetComponent<Monster>().speed = Random.Range(-4, -10); // simply change it into negative
                spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f);  // -1 for the x to flip the monster
            }
        }
    }   
} //class

        
