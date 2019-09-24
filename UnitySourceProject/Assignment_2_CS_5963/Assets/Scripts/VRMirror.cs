using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRMirror : MonoBehaviour
{
    public GameObject player;
    bool ToggleMatch = true;
    public float zoffset;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            
            ToggleMatch = !ToggleMatch;
            Debug.Log("TOGGLING" + ToggleMatch);
        }
        if(ToggleMatch)
        {
            transform.localRotation = player.transform.localRotation;
            Vector3 v3 = player.transform.localPosition;
            v3.z += zoffset;
            transform.localPosition = v3;
        }
        else
        {
            Vector3 vR = player.transform.localRotation.eulerAngles;
            vR.y *= -1;
            transform.localRotation = Quaternion.Euler(vR);

            Vector3 v3 = player.transform.localPosition;
            v3.z += zoffset;
            v3.x = -v3.x;
            transform.localPosition = v3;
        }
    }
}
