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
        percievedScale = (Camera.main.fieldOfView * (Camera.main.transform.position - redsphere.transform.position).magnitude) / redsphere.transform.localScale.x;
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
        var distance = (Camera.main.transform.position - blSphere.transform.position).magnitude;
        var size = distance * FixedSize * Camera.fieldOfView;
        transform.localScale = Vector3.one * siz
        var size = 
    }
}
