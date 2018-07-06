using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour
{
    private Rigidbody2D rigid;
    private bool isClimbing, JumpAvailable, ClimbAvailable;

    public float jumpForce, throwForce;
    public int BlockLimit;
    public GameObject[] blocks;

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
        ThrowBlock();
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
    private void ThrowBlock()
    {
        if (Input.GetMouseButtonUp(1) && BlockLimit > 0)
        {
            Vector2 mousepos = Vector2.zero;
            mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            BlockLimit--;

            Instantiate(blocks[Random.Range(0, blocks.Length)], transform.position + new Vector3(0f, 0.5f), Quaternion.identity).GetComponent<Block>().Init((mousepos - (Vector2)transform.position).normalized, throwForce);
            
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
