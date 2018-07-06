using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempP : MonoBehaviour
{
    public float speed;
    public float power;
    public float grabpower;

    private Rigidbody2D rigid;
    
    [SerializeField]
    private Hook hookprefab;

    private Hook hook;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        hook = null;
    }

    void FixedUpdate()
    {
        Vector2 vel = rigid.velocity;
        rigid.velocity = Vector2.zero;
        Movement();

        ThrowHook();
        if (hook != null)
            hook.NextUpdate();

        if (rigid.velocity.x == 0)
            rigid.velocity = new Vector2(vel.x, rigid.velocity.y);
        if (rigid.velocity.y == 0)
            rigid.velocity = new Vector2(rigid.velocity.x, vel.y);

    }

    private void Movement()
    {
        Vector2 move = new Vector2((Input.GetAxis("Horizontal") * speed), rigid.velocity.y);

        rigid.velocity = move;
    }

    private void ThrowHook()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (hook != null)
            {
                Destroy(hook.gameObject);
                hook = null;
            }

            Vector2 mousepos = Vector2.zero;

            mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            hook = GameObject.Instantiate(hookprefab).Init(this, (mousepos - (Vector2)transform.position).normalized, Vector2.Distance(mousepos, transform.position), power);
            hook.transform.position = transform.position;
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (hook != null)
            {
                Destroy(hook.gameObject);
                hook = null;
            }
        }
    }

    #region Properties

    public Rigidbody2D Rigid
    {
        get
        {
            return rigid;
        }

        set
        {
            rigid = value;
        }
    }

    #endregion
}
