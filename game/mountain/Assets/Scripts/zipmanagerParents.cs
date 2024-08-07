using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class zipmanagerParents : MonoBehaviour
{
    [SerializeField]
    private bool isPlayer = true;
    [SerializeField]
    ZiplineScript zs;
    [SerializeField]
    private GameObject zipman;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    PlayerMovement pm;
    private Rigidbody2D rb;
    private float moveInput;
    // Start is called before the first frame update
    void Start()
    {
        rb = zipman.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayer && zs.OnZipline)
        {
            zipman.transform.rotation = zs.mrZipline.transform.rotation;
            player.transform.position = new Vector3(zipman.transform.position.x, zipman.transform.position.y, transform.position.z);
            pm.moveEnable = false;
            pm.resetVel();
        }
        if (!isPlayer && !zs.OnZipline)
        {
            zipman.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
            pm.moveEnable = true;
        }
        if (!isPlayer && zs.OnZipline)
        {
            moveInput = Input.GetAxis("Horizontal");
            rb.AddForce(((pm.moveSpeed * moveInput) - rb.velocity.x) * transform.right, ForceMode2D.Force);
        }
    }
}
