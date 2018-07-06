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
        if (Input.GetMouseButtonUp(0) && hook == null)
        {
            Vector2 mousepos = Vector2.zero;

            mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            hook = GameObject.Instantiate(hookprefab).Init(this, (mousepos - (Vector2)transform.position).normalized, power);
            hook.transform.position = transform.position + new Vector3(0,1f);
        }
        else if (Input.GetMouseButtonUp(0) && hook != null)
        {
            Destroy(hook.gameObject);
            hook = null;
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
