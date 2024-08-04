using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animations_player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rigidBody;
    [SerializeField]
    private float runSpeed = 3.0f;
    private float direction;
    [SerializeField]
    private Animator anm;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        
        if (Mathf.Abs(rigidBody.velocity.x) > 0.1)
        {
           
            anm.SetBool("isWalking", true);
            anm.SetBool("isIdle", false);
            
        }
        
        else if (rigidBody.velocity.magnitude < 0.1)
        {
            anm.SetBool("isWalking", false);
            
            anm.SetBool("isIdle", true);
        }
    }
}
