using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMove : MonoBehaviour {
    private Rigidbody2D RB2D;
    [Range(0f, 5f)]
    public float speed;
    public SpineManager SM;
    public VirtualJoystick VJ;
    int status = 0;
	// Use this for initialization
	void Start () {
        RB2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        Move();

    }
    public void Move()
    {
        Vector2 dir = new Vector2();
        dir.x = VJ.Horizontal();
        if (dir.x < 0f)
            transform.localRotation = new Quaternion(0f, 180f, 0f, 1f);
        else if (dir.x > 0f)
            transform.localRotation = new Quaternion(0f, 0f, 0f, 1f);

        if (dir.x != 0f)
        {
            if(dir.x > 0f && status != 1)
            {
                status = 1;
                SM.ChangeAnimation("move_0", 0,true);
            }
            else if(dir.x < 0f && status != -1)
            {
                status = -1;
                SM.ChangeAnimation("move_0", 0,true);
            }
        }
        else if(dir.x == 0f && dir.y == 0f && status !=0)
        {
            status = 0;
            SM.ChangeAnimation("idle_0", 0, true);
        }



       // RB2D.velocity = dir * speed;
        //if()
    }
}
