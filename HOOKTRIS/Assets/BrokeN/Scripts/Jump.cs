using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private Rigidbody2D rigid;
    private bool isClimbing, JumpAvailable, ClimbAvailable;

    public float jumpForce;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        isClimbing = false;
        JumpAvailable = false;
        ClimbAvailable = true;
    }

    private void Update()
    {
        jump();
    }

    private void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (JumpAvailable)
            {
                if (isClimbing)
                {
                    isClimbing = false;
                    rigid.bodyType = RigidbodyType2D.Dynamic;
                    StartCoroutine("ClimbCooltime");
                }
                rigid.AddForce(Vector2.up * jumpForce);
                JumpAvailable = false;
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("floor"))
            JumpAvailable = true;

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("wall") && ClimbAvailable)
        {
            isClimbing = true;
            JumpAvailable = true;
            rigid.bodyType = RigidbodyType2D.Static;
        }
    }

    IEnumerator ClimbCooltime()
    {
        ClimbAvailable = false;
        yield return new WaitForSeconds(0.35f);
        ClimbAvailable = true;
    }
}
