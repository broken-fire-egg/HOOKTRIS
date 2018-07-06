using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour
{
    private Rigidbody2D rigid;
    private bool JumpAvailable;

    public float jumpForce, throwForce;
    public VirtualJoystick VJ;
    public int BlockLimit;
    public GameObject[] blocks;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        JumpAvailable = false;
    }

    private void Update()
    {
        jump();
        ThrowBlock();
    }

    private void jump()
    {
        if (VJ.Vertical() > 0.8)
        {
            if (JumpAvailable)
            {
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

            Instantiate(blocks[Random.Range(0, blocks.Length)], transform.position + new Vector3(0f, 0.7f), Quaternion.identity).GetComponent<Block>().Init((mousepos - (Vector2)transform.position).normalized, throwForce);
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("floor"))
            JumpAvailable = true;

    }
}
