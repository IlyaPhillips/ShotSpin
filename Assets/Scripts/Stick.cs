using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    Vector2 centre;
    Vector2 offset;
    bool isDragging;
    
    // Start is called before the first frame update
    void Start()
    {
        centre = transform.localPosition;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isDragging) {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePosition);
            if (Vector2.Distance(mousePosition, centre) > 0.4f)
            {
                offset = Vector2.ClampMagnitude((centre - mousePosition), 0.4f);
                transform.localPosition = -offset;
            }
        }
        
    }
    private void OnMouseDown()
    {
        isDragging = true;
    }
    private void OnMouseUp()
    {
        isDragging = false;
        //Vector2 pos2D = new Vector2(transform.position.x, transform.position.y);
        //transform.localPosition = Vector2.ClampMagnitude((centre - pos2D), 0.4f);
    }
    
}
