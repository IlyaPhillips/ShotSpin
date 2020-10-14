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

    private void DrawLine() {
        LineRenderer nextShot = GetComponent<LineRenderer>();
        if (shotCount + 1 < shotList.Count) {
            Vector3 line = shotList[shotCount + 1];
            Vector3 lineDelta = spinList[shotCount + 1];
            Vector3 [] linePlot = new Vector3 [4];
            float time = 10;
            for (int i = 0; i < linePlot.Length; i++) {
                Vector2 temp = (Vector2)line*line.z;
                temp += (Vector2)lineDelta * time * i*lineDelta.z;
                linePlot[i] = temp;
                print(linePlot[i]);
            }
            nextShot.SetPositions(linePlot);
        }
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
        DrawLine();
    }
}

