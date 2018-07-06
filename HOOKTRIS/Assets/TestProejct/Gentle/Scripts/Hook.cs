using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour {

    private Rigidbody2D rigid;
    private LineRenderer line;
    [SerializeField]
    private Sprite linesprite;

    private TempP player;
    private Vector2 direction;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        line = GetComponent<LineRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name != player.name && collision.gameObject.name != gameObject.name && !collision.CompareTag("TrajHook"))
        {
            rigid.bodyType = RigidbodyType2D.Kinematic;
            rigid.velocity = Vector2.zero;
        }
    }

    public void NextUpdate()
    {
        LineConnect();

        if (rigid.bodyType == RigidbodyType2D.Dynamic)
        {
            Vector2 direc = (transform.position - player.transform.position).normalized;
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direc.y, direc.x) * Mathf.Rad2Deg + 270);
        }
        else
            Grabbing();
    }

    public Hook Init(TempP player, Vector2 direction, float distance, float power)
    {
        this.player = player;
        this.direction = direction;

        rigid.velocity = (direction * (1f - (1f / distance)) * power) + direction * power;

        return this;
    }

    private void Grabbing()
    {
        if (player.shaking == false)
        {
            if (Vector2.Distance(transform.position, player.transform.position) > 1.5f)
            {
                Vector2 direc = (transform.position - player.transform.position).normalized * player.grabpower;

                player.Rigid.velocity += direc;
            }
            else if (Vector2.Distance(transform.position, player.transform.position) < 0.5f)
            {
                Vector2 direc = (transform.position - player.transform.position).normalized * player.grabpower / 3;
                player.Wallwilling();
                player.Rigid.velocity += direc;
            }
        }
        else if(player.shaking == true)
        {
            Vector2 direc = (transform.position - player.transform.position).normalized * player.grabpower;

            //direc.x += (transform.position - player.transform.position).x * player.grabpower * 0.5f;

            player.Rigid.velocity += direc * 0.068f;
        }

    }

    private void LineConnect()
    {
        line.SetPosition(0, transform.position);
        line.SetPosition(1, player.transform.position);
    }

}
