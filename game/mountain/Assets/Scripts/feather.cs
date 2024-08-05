using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class feather : MonoBehaviour
{
    public PlayerMovement player_mov;
    [SerializeField]
    private bool special = false;

    private SpriteRenderer sr;
    [SerializeField]
    private float specialboost = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }
    private void respawn()
    {

    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player"){
            player_mov = col.gameObject.GetComponent<PlayerMovement>();
            if (special)
            {
                player_mov.featherboost = specialboost;
            }
            player_mov.jumps += 1;
            sr.enabled = false;
            Invoke("respawn", 3);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
