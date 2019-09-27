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

        var redScale = redsphere.transform.localScale;
        var redDistance = (Camera.main.transform.position - redsphere.transform.position).magnitude;
        var redMatrix = redScale / redDistance;

        var bl1distance = (Camera.main.transform.position - blSphere.transform.position).magnitude;
        var one_size = redMatrix / bl1distance;
        blSphere.transform.localScale = one_size;

        var bl2distance = (Camera.main.transform.position - blSphere2.transform.position).magnitude;
        var two_size = redDistance * redScale / bl2distance;
        blSphere2.transform.localScale = two_size;
        
    }
}
