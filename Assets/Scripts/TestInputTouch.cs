using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInputTouch : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2 touchInval = Vector2.zero;  
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount <= 0)
            return;
        if (Input.touches[0].phase == TouchPhase.Moved)
        {
            touchInval = new Vector2(Input.touches[0].deltaPosition.x, Input.touches[0].deltaPosition.y);
            transform.Translate(touchInval.x * Time.deltaTime, touchInval.y * Time.deltaTime,0);
        }
    }
    private void OnGUI()
    {
        GUI.Label(new Rect(100, 100, 100, 50), touchInval.ToString());
    }
}
