using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OraControl : MonoBehaviour {
    public BlockAirSupport BAS;
    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0) && BAS.isHook == false)
        {
            Vector2 mousepos = Vector2.zero;

            mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            transform.localPosition = new Vector3(mousepos.x, 9f);
        }
        else if (Input.GetMouseButtonUp(0) && BAS.isHook == false)
        {

        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
