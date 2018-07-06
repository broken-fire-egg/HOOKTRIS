using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubCameraMove : MonoBehaviour {
    public GameObject Hero;
    Rigidbody2D HeroRB;
    HeroMove HM;
    public float elasticPointX;
    public float elasticPointY;
    Rigidbody2D RB2D;
    // Use this for initialization
    void Start()
    {
        HM = Hero.GetComponent<HeroMove>();
        HeroRB = Hero.GetComponent<Rigidbody2D>();
        RB2D = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {

        Vector3 Gap1 = transform.position - Hero.transform.position;
        RB2D.velocity = -new Vector2(Gap1.x * elasticPointX, Gap1.y * elasticPointY);

    }
}
