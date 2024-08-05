using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    GameObject Player;
    void Start()
    {
        Player = GameObject.Find("player");
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Player.GetComponent<PlayerManager>().SetCheckpoint(transform.position);
            Debug.Log("Got Checkpoint!");
        }
    }
}
