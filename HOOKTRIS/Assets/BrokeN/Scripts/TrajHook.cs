using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajHook : MonoBehaviour
{
    private Rigidbody2D rigid;

    private TempP player;
    private Vector2 direction;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Vector2 direc = (transform.position - player.transform.position).normalized;
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direc.y, direc.x) * Mathf.Rad2Deg + 270);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("wall") || collision.CompareTag("floor"))
        {
            Destroy(gameObject);
        }
    }

    public TrajHook Init(TempP player, Vector2 direction, float distance, float power)
    {
        this.player = player;
        this.direction = direction;

        rigid.velocity = (direction * (1f - (1f / distance)) * power) + direction * power;

        return this;
    }
}
