using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {
    public GameObject SubObject;
    public GameObject Hero;
    Rigidbody2D RB2D;
    Rigidbody2D SRB2D;
    // Use this for initialization
    void Start () {
        RB2D = GetComponent<Rigidbody2D>();
        SRB2D = SubObject.GetComponent<Rigidbody2D>();

    }
    private void FixedUpdate()
    {
        transform.position = Hero.transform.position * 2 - SubObject.transform.position;
     //   RB2D.velocity = -SRB2D.velocity;
     //   transform.position = -SubObject.transform.position;
    }
    // Update is called once per frame
    void Update () {
      //  Vector3 Vec3 = new Vector3(Hero.transform.position.x, Hero.transform.position.y,-10);
      //  transform.position = Vec3;

	}
}
