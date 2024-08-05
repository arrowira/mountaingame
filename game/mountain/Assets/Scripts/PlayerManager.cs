using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Vector2 LastCheckpoint;
    void Start()
    {
        LastCheckpoint = new Vector2(0, 0);
    }
    void Update()
    {
        
    }
    public void SetCheckpoint(Vector2 Position)
    {
        LastCheckpoint = Position;
    }
    public void Respawn()
    {
        transform.SetPositionAndRotation(new Vector3(LastCheckpoint.x, LastCheckpoint.y, -1), this.transform.rotation);
    }
}
