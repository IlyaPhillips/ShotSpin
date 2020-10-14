using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launch : MonoBehaviour
{
    GameObject input;
    GameObject player;
    List<Vector3> shotList;
    List<Vector3> spinList;
    // Start is called before the first frame update
    void Start()
    {
        input = transform.parent.GetChild(2).gameObject;
        player = GameObject.FindGameObjectWithTag("Player");
        shotList = input.GetComponent<ShotEntry>().getShotList();
        spinList = input.GetComponent<ShotEntry>().getSpinList();
        player.GetComponent<Movement>().SetShot(shotList);
        player.GetComponent<Movement>().SetSpin(spinList);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        shotList = input.GetComponent<ShotEntry>().getShotList();
        spinList = input.GetComponent<ShotEntry>().getSpinList();
        player.GetComponent<Movement>().SetShot(shotList);
        player.GetComponent<Movement>().SetSpin(spinList);
    }
}
