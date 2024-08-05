using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBoxManager : MonoBehaviour
{
    public GameObject Player;
    void Start()
    {
        Player = GameObject.Find("player");
    }
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player.GetComponent<PlayerManager>().Respawn();
        }
    }
}
