using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotEntry : MonoBehaviour
{
    GameObject shotStick;
    GameObject spinStick;
    public List<Vector3> shotList = new List<Vector3>();
    public List<Vector3> spinList = new List<Vector3>();
    // Start is called before the first frame update
    void Start()
    {
        shotStick = transform.parent.GetChild(0).gameObject;
        spinStick = transform.parent.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        shotList.Add(shotStick.GetComponent<Joystick>().joyValue);
        spinList.Add(spinStick.GetComponent<Joystick>().joyValue);
        shotStick.GetComponent<Joystick>().Reset();
        spinStick.GetComponent<Joystick>().Reset();
    }
    public List<Vector3> getShotList() {
        return shotList;
    }
    public List<Vector3> getSpinList()
    {
        return spinList;
    }
}
