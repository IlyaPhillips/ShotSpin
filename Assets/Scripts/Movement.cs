using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //public Vector2 [] shotList;
    //public Vector2 [] spinList;
    //public Vector2 [] power;
    public float powerScale;
    public float spinScale;
    private float shotPower;
    private float spinPower;
    private List<Vector3> shotList;
    private List<Vector3> spinList;
    private Rigidbody2D rb;
    private Vector2 shot;
    private Vector2 spin;
    private int shotCount;
    public Vector3 [] plot;
    
    void Start()
    {
        shotCount = 0;
        rb = gameObject.GetComponent<Rigidbody2D>();
        //Shoot();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(spin);
        if (Input.GetButtonDown("Jump")) {
            NewShot();
        }
    }

    public void DrawLine(int shot) {
        LineRenderer nextShot = GetComponent<LineRenderer>();
        nextShot.useWorldSpace = false;
        //if (shotCount + 1 < shotList.Count) {
            Vector3 line = shotList[shot + 1];
            Vector3 lineDelta = spinList[shot + 1];
            Vector3 [] linePlot = new Vector3 [15];
            float time = 1;
            Vector2 tempVel = (Vector2)line * line.z;
            Vector2 tempAcc = (Vector2)lineDelta* lineDelta.z * spinScale;
            for (int i = 0; i < linePlot.Length; i++) {
                float timeIt = time * i;
                Vector2 temp = new Vector2(tempVel.x*timeIt + (tempAcc.x*timeIt*timeIt), tempVel.y*timeIt + ( tempAcc.y * timeIt*timeIt));
                
                linePlot[i] = temp;
            }
            plot = linePlot;
            nextShot.SetPositions(linePlot);
        //}
    }

    private void NewShot()
    {
        shotCount++;
        Shoot();
    }
    private void OnMouseDown()
    {
        Shoot();
    }
    public void SetShot(List<Vector3> shots) {
        shotList = shots;
    }
    public void SetSpin(List<Vector3> spins) {
        spinList = spins;
    }
    private void Shoot()
    {
        shot = (Vector2)shotList[shotCount];
        shot.Normalize();
        shotPower = shotList[shotCount].z;
        shot *= shotPower * powerScale;

        spin = (Vector2)spinList[shotCount];
        spin.Normalize();
        spinPower = spinList[shotCount].z * spinScale;
        spin *= spinPower * powerScale;
        rb.velocity = shot;
        DrawLine(shotCount);
    }
}

