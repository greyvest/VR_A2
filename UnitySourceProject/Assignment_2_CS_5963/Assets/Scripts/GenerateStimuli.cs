using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateStimuli : MonoBehaviour
{
    public GameObject redsphere;
    public GameObject blSphere;
    public GameObject blSphere2;

    bool turnedOff = false;
    float timer = 0.0f;

    float percievedScale;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 test = new Vector3(2, 4, 6);
        test /= 2;
        print(test);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            turnedOff = !turnedOff;
            redsphere.SetActive(!turnedOff);
            timer = 0.0f;
        }
        timer += Time.deltaTime;
        if (turnedOff && blSphere.activeSelf)
        {
            if (timer > 2.0f)
            {
                blSphere.SetActive(false);
                blSphere2.SetActive(false);
            }
        }
        else if (!turnedOff && !blSphere.activeSelf)
        {
            if (timer > 2.0f)
            {
                blSphere.SetActive(true);
                blSphere2.SetActive(true);
            }
        }

        /*   AUSTIN
        var redScale = redsphere.transform.localScale;
        var redDistance = (Camera.main.transform.position - redsphere.transform.position).magnitude;
        var redMatrix = redScale / redDistance;

        var bl1distance = (Camera.main.transform.position - blSphere.transform.position).magnitude;
        var one_size = redMatrix / bl1distance;
        blSphere.transform.localScale = one_size;

        var bl2distance = (Camera.main.transform.position - blSphere2.transform.position).magnitude;
        var two_size = redDistance * redScale / bl2distance;
        blSphere2.transform.localScale = two_size;
        */

        Vector3 redScale = redsphere.transform.lossyScale;
        float redDistance = (Camera.main.transform.position - redsphere.transform.position).magnitude;

        /*
         *  THIS WAS AN ATTEMPT TO GET THE RATION FROM THE CENTER POINT ON THE VECTOR FROM CAMERA TO B1
        Vector3 B1 = (blSphere.transform.position - Camera.main.transform.position);
        Vector3 MidPoint1;
        if (B1.magnitude > redDistance)
        {
            MidPoint1 = B1 - redsphere.transform.position;
            MidPoint1 = (MidPoint1 - B1) / 2;

        }
        else
        {
            MidPoint1 = redsphere.transform.position - B1;
            MidPoint1 = (MidPoint1 - redsphere.transform.position) / 2;
        }

        float ratio1 = MidPoint1.magnitude / redDistance;
        */
        float rationMag1 = (Camera.main.transform.position - blSphere.transform.position).magnitude / redDistance;
        blSphere.transform.localScale = redScale * (rationMag1 + .5f/redDistance);

        /*THIS WAS AN ATTEMPT TO GET THE RATION FROM THE CENTER POINT ON THE VECTOR FROM CAMERA TO B2
        Vector3 B2 = (blSphere2.transform.position - Camera.main.transform.position);
        Vector3 MidPoint2;
        if (B1.magnitude > redDistance)
        {
            MidPoint2 = B2 - redsphere.transform.position;
            MidPoint2 = (MidPoint2 - B2) / 2;

        }
        else
        {
            MidPoint2 = redsphere.transform.position - B2;
            MidPoint2 = (MidPoint2 - redsphere.transform.position) / 2;
        }

        float ratio2 = MidPoint2.magnitude / redDistance;
        */
        float rationMag2 = (Camera.main.transform.position - blSphere2.transform.position).magnitude / redDistance;
        blSphere2.transform.localScale = (redScale * (rationMag2 + .5f/redDistance));

    }
}
