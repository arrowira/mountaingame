using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class feather : MonoBehaviour
{
    public PlayerMovement player_mov;
    [SerializeField]
    private bool special = false;
    [SerializeField]
    private float specialboost = 3.0f;
    // Start is called before the first frame update
    void Start()
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
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
