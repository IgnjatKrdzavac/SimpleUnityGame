using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
    public GameObject[] groundPrefabs;

    public float zSpawn = 0;

    public float tileLength = 170;

    public int numberOfGrounds = 5;

    public Transform playerTransform;

    private List<GameObject> activeGrounds = new List<GameObject>();

    // Start is called before the first frame updat
    void Start()
    {
       for(int i = 0; i < numberOfGrounds; i++){
            if(i == 0){
                SpawnGround(0);
            }else{
            SpawnGround(Random.Range(0, groundPrefabs.Length - 1));
            }
       }
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform.position.z - 200> zSpawn - (numberOfGrounds * tileLength)){
            SpawnGround(Random.Range(0, groundPrefabs.Length));
            DeleteGround();
        }
    }

    public void SpawnGround(int groundIndex){
        GameObject go = Instantiate(groundPrefabs[groundIndex],transform.forward * zSpawn, transform.rotation);
        activeGrounds.Add(go);
        zSpawn += tileLength;
    }

    private void DeleteGround(){
        Destroy(activeGrounds[0]);
        activeGrounds.RemoveAt(0);
    }
}
