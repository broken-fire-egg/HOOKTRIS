using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OraControl : MonoBehaviour {
    public BlockAirSupport BAS;
    public bool blockfalling = false;

    private void FixedUpdate()
    {
        Physics2D.IgnoreLayerCollision(2, 1);
        if (blockfalling)
        {
            if(Input.GetMouseButtonUp(0))
            {
                BAS.HoldBlock();
            }
        }
        if (Input.GetMouseButton(0) && !BAS.isHook && !blockfalling)
        {
            Vector2 mousepos = Vector2.zero;

            mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            transform.localPosition = new Vector3(mousepos.x, 9f);
        }
        else if (Input.GetMouseButtonUp(0) && BAS.isHook == false && blockfalling == false)
        {
            BAS.DropBlock();
            blockfalling = true;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
            return;
    }
    // Update is called once per frame
    void Update () {
		
	}
}
