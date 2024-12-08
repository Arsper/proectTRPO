using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject item;
    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    public void SpawnDropperItem()
    {
        Vector3 playerPos = new Vector3(player.position.x-1, player.position.y-1.7f, player.position.z+3);
        Instantiate(item, playerPos, Quaternion.identity);
    }
}
