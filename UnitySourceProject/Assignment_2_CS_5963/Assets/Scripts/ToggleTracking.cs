using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ToggleTracking : MonoBehaviour
{
    public GameObject parent;
    bool Rotate = true;
    bool Move = true;

    Vector3 MovePoint;
    Vector3 ChildDist;

    Quaternion RotationDist;
    Vector3 originRotation;
    Vector3 originPin;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            Rotate = !Rotate;
            if (!Rotate)
            {

            }
        }
        if(Input.GetKeyDown(KeyCode.P))
        {
            Move = !Move;
            if(!Move)
            {
                MovePoint = new Vector3((transform.position.x + parent.transform.position.x) / 2, (transform.position.y + parent.transform.position.y) / 2, (transform.position.z + parent.transform.position.z) / 2);

                MovePoint.x += transform.position.x - MovePoint.x;
                MovePoint.y += transform.position.y - MovePoint.y;
                MovePoint.z += transform.position.z - MovePoint.z;
            }
        }
        
        if(!Move)
        {

            Vector3 currDist = new Vector3(MovePoint.x - transform.position.x, MovePoint.y - transform.position.y, MovePoint.z - transform.position.z);
            parent.transform.position = new Vector3(parent.transform.position.x + currDist.x, parent.transform.position.y + currDist.y, parent.transform.position.z + currDist.z);
            
        }

        if(!Rotate)
        {
  
        }
    }
}
