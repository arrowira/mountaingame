using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZiplineScript : MonoBehaviour
{
    public bool NearZipline, OnZipline;
    public GameObject mrZipline;
    void Start()
    {
        NearZipline = false;
    }
    void Update()
    {
        if(NearZipline == true && Input.GetKeyDown(KeyCode.E))
        {
            OnZipline = true;
            Debug.Log("On Zipline");
        }
    }
    public void OnTriggerEnter2D(Collider2D Object)
    {
        if (Object.tag == "Zipline")
        {
            mrZipline = Object.gameObject;
            NearZipline = true;
        }
    }
    public void OnTriggerExit2D(Collider2D Object)
    {
        if (Object.tag == "Zipline")
        {
            NearZipline = false;
            if(OnZipline == true)
            {
                Debug.Log("Off Zipline");
                OnZipline = false;
            }
        }
    }
}
