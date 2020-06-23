using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawn : MonoBehaviour
{
    public GameObject[] trees;

    public float minDelay;
    public float maxDelay;
    public float minY;
    public float maxY;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnTree");
    }

    private IEnumerator SpawnTree()
    {
        while (true)
        {
            float y = Random.Range(minY, maxY);
            int treeID = Random.Range(0, trees.Length);

            Instantiate(trees[treeID], new Vector3(12, y, 25), Quaternion.identity);

            yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
        }
    }
}
