using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMaker : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public float zSpawning = 0;
    public float tileLength = 30;
    public int numoftiles = 5;
    public Transform playertransforms;
    private List<GameObject> activeTiles = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<numoftiles; i++)
        {
            if (i == 0)
                SpawnTile(0);
            else
            SpawnTile(Random.Range(0, tilePrefabs.Length));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playertransforms.position.z -35 > zSpawning - (numoftiles * tileLength))
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length));
            DeleteTile();
        }
    }
    public void SpawnTile(int tileIndex)
    {
        GameObject go = Instantiate(tilePrefabs[tileIndex], transform.forward * zSpawning, transform.rotation);
        activeTiles.Add(go);
        zSpawning += tileLength;
    }
    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
