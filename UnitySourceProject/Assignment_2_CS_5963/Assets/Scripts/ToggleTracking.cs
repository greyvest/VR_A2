using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ToggleTracking : MonoBehaviour
{
    public GameObject parent;
    bool Rotate = true;
    bool Move = true;
    bool Both = true;


    Vector3 MovePoint;
    Vector3 ChildDist;

    bool Debug = false;

    // ATTEMPT 2
    Quaternion ChildRotation;


    Vector3 ChildBothPos;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Both && Input.GetKeyDown(KeyCode.R))
        {
            Rotate = !Rotate;
            if(!Rotate)
            { 
                // ATTEMPT 2
                ChildRotation = transform.rotation;
            }
        }
        if(Both && Input.GetKeyDown(KeyCode.P))
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
        if(Rotate && Move && Input.GetKeyDown(KeyCode.B))
        {
            Both = !Both;
            if(!Both)
            {
                ChildRotation = transform.rotation;
                ChildBothPos = transform.position;
            }
        }
        
        if(!Move)
        {

            Vector3 currDist = new Vector3(MovePoint.x - transform.position.x, MovePoint.y - transform.position.y, MovePoint.z - transform.position.z);
            parent.transform.position = new Vector3(parent.transform.position.x + currDist.x, parent.transform.position.y + currDist.y, parent.transform.position.z + currDist.z);
            
        }

        if(!Rotate)
        {
            // Grab Spot to return to after operations
            Vector3 Child_pos_1 = transform.position;

            // Grab the child's current rotation
            Quaternion Child_Current_rot = transform.rotation;

            // Get the difference between old rotation and new (the angle to rotate by sort of)
            Quaternion Difference = ChildRotation * Quaternion.Inverse(Child_Current_rot);

            // Get the angle to rotate the parent by in order to counter act the child
            Difference = Difference * parent.transform.rotation;

            // Undo the rotation (Will move the child to a new position
            parent.transform.rotation = Difference;

            // Get the offest from the child's new position from its old
            Vector3 Offset = new Vector3(Child_pos_1.x - transform.position.x, Child_pos_1.y - transform.position.y, Child_pos_1.z - transform.position.z);

            // Move the parent by the offset to return the child to original position
            
        }

        if (!Both)
        {
            // SIMPLY REPEAAT THE NON ROTATIONAL FEATURE BUT USE THE POSITION FROM WHEN B IS PUSHED RATHER THAN EACH UPDATE

            Quaternion Child_Current_Rot = transform.rotation;
            Quaternion Differnce = ChildRotation * Quaternion.Inverse(Child_Current_Rot);
            Differnce = Differnce * parent.transform.rotation;
            parent.transform.rotation = Differnce;

            Vector3 Offset = new Vector3(ChildBothPos.x - transform.position.x, ChildBothPos.y - transform.position.y, ChildBothPos.z - transform.position.z);
            parent.transform.position = new Vector3(parent.transform.position.x + Offset.x, parent.transform.position.y + Offset.y, parent.transform.position.z + Offset.z);
        }
    }
}
