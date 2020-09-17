using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Vector2 [] shotList;
    public Vector2 [] spinList;
    public Vector2 [] power;
    public float powerScale;
    private float shotPower;
    private float spinPower;
    private Rigidbody2D rb;
    private Vector2 shot;
    private Vector2 spin;
    private int shotCount;

    // Start is called before the first frame update
    void Start()
    {
        shotCount = 0;
        rb = gameObject.GetComponent<Rigidbody2D>();
        Shoot();
    }

    private void Shoot()
    {
        shot  = shotList[shotCount];
        shot.Normalize();
        shotPower = power[shotCount].x;
        shot *= shotPower*powerScale;

        spin = spinList[shotCount];
        spin.Normalize();
        spinPower = power[shotCount].y*0.05f;
        spin *= spinPower*powerScale;
        rb.velocity = shot;
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(spin);
        if (Input.GetButtonDown("Fire1")) {
            NewShot();
        }
    }
    

    private void NewShot()
    {
        shotCount++;
        Shoot();
    }
}
