using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public GameObject[] prefabItem;
    private Vector3 randomSpawnPosition;
    private int randomIndex;

    public float timer = 0f;

    void Start()
    {

    }

    void Update()
    {
        // if(Input.GetMouseButtonDown(1)){
        //     randomIndex = Random.Range(0, prefabItem.Length);
        //     randomSpawnPosition = new Vector3(Random.Range(-8, 8), 0.7f, Random.Range(-8, 8));
        //     Instantiate(prefabItem[randomIndex], randomSpawnPosition, new Quaternion(45, 0, 45, 1));
        // }

        if(timer < 10f){
            timer += Time.deltaTime;
        }
        
        if(timer >= 10f){
            randomIndex = Random.Range(0, prefabItem.Length);
            randomSpawnPosition = new Vector3(Random.Range(-8, 8), 0.7f, Random.Range(-8, 8));
            Instantiate(prefabItem[randomIndex], randomSpawnPosition, new Quaternion(45, 0, 45, 1));
            timer = 0f;
        }
    }
}











