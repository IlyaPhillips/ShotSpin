using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick : MonoBehaviour
{
    GameObject stick;
    public Vector3 joyValue;
    // Start is called before the first frame update
    void Start()
    {
        stick = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        joyValue = transform.position - stick.transform.position;
        float mag = Vector3.Magnitude(transform.position - stick.transform.position);
        joyValue.z = Mathf.Clamp(mag,0,1.5f);
        
    }
    public void Reset()
    {
        print(joyValue);
        stick.transform.position = transform.position;
    }
}
