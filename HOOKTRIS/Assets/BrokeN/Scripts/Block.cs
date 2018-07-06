using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private Rigidbody2D rigid;
    private Vector2 direction;
    private float power;

    public void Init(Vector2 dir, float pwr)
    {
        direction = dir;
        power = pwr;

        rigid = GetComponent<Rigidbody2D>();
        rigid.AddForce(direction * power);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 1 || collision.gameObject.layer == 0)
            return;

        if (collision.CompareTag("wall") || collision.CompareTag("floor"))
        {
            return;


        //{
        //    rigid.bodyType = RigidbodyType2D.Static;
        //    //GetComponent<Collider2D>().isTrigger = false;
        //    Destroy(GetComponent<Collider2D>());
        //    Destroy(rigid);

        //    for (int i = 0; i < GetComponentsInChildren<Collider2D>().Length; i++)
        //    {
        //        transform.GetComponentsInChildren<Collider2D>()[i].isTrigger = false;
        //    }
        }
    }
}
