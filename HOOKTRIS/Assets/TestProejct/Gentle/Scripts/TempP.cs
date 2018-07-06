using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempP : MonoBehaviour
{

    public float speed;
    public float power;
    public float grabpower;
    public SpineManager SM;
    public float gravity;
    private Rigidbody2D rigid;
    
    [SerializeField]
    private Hook hookprefab;
    [SerializeField]
    private TrajHook trajhook;

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
    public void Wallwilling()
    {
        SM.ChangeAnimation("jump_0", 0, false);
    }
    private void Movement()
    {
        Vector2 move = new Vector2((Input.GetAxis("Horizontal") * speed), rigid.velocity.y);

        rigid.velocity = move;
    }
    public void Inv_ThrowHook()
    {
        if (hook != null)
            return;
       // rigid.gravityScale = 0f;
       Vector2 mousepos = Vector2.zero;

        mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        hook = GameObject.Instantiate(hookprefab).Init(this, (mousepos - (Vector2)transform.position).normalized, Vector2.Distance(mousepos, transform.position), power);
        hook.transform.position = transform.position + new Vector3(0, 1f);
    }
    private void ThrowHook()
    {
        if(Input.GetMouseButtonDown(0) && hook == null)
        {
            Vector2 mousepos = Vector2.zero;

            mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            InvokeRepeating("Parabola", 0f, 0.5f);
            

            if (mousepos.x < transform.position.x)
                transform.localRotation = new Quaternion(0,180f,0,1f);
            else
                transform.localRotation = new Quaternion();

            SM.ChangeAnimation("atk_0", 0, false);

        }
        if (Input.GetMouseButtonUp(0) && hook == null)
        {
            Invoke("Inv_ThrowHook", 0.2f);
            CancelInvoke("Parabola");
            SM.ChangeAnimation("atk_1", 0, false);
        }
        else if (Input.GetMouseButtonUp(0) && hook != null)
        {
            SM.ChangeAnimation("idle_0", 0, true);
            Destroy(hook.gameObject);
            hook = null;
          //  rigid.gravityScale = gravity;
        }
    }
    private void Parabola()
    {
        Vector2 mousepos = Vector2.zero;

        mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        TrajHook a = Instantiate(trajhook).Init(this, (mousepos - (Vector2)transform.position).normalized, Vector2.Distance(mousepos, transform.position), power);
        a.transform.position = transform.position + new Vector3(0, 1f);
        Destroy(a, 5f);
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
