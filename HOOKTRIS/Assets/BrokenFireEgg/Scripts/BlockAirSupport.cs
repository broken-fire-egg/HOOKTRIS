using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BlockAirSupport : MonoBehaviour {
    
    public Image button;
    public bool isHook;
    public Sprite hookspr;
    public Sprite airsupportspr;

    public GameObject Player;
    public GameObject Ora;
    public GameObject VJ;

    public GameObject[] blocks;
    public GameObject currentBlock;
    
    private void Start()
    {
        isHook = true;
    }
    public void ToggleButton()
    {
        isHook = !isHook;
        if(isHook)
        {
            VJ.SetActive(true);
            Ora.SetActive(false);
            button.sprite = hookspr;
        }
        else
        {
            VJ.SetActive(false);
            Ora.transform.position = Player.transform.position + new Vector3(0,4f);
            Ora.SetActive(true);
            button.sprite = airsupportspr;
        }
    }
    public void DropBlock()
    {
        if(currentBlock !=null)
            Destroy(currentBlock);
        Debug.Log("asd");
        currentBlock = Instantiate(blocks[Random.Range(0, blocks.Length)], Ora.transform.position + new Vector3(0,7f), Quaternion.identity);
    }

    public void HoldBlock()
    {
        Rigidbody2D RBC = currentBlock.GetComponent<Rigidbody2D>();
        RBC.gravityScale = 0f;
        RBC.velocity = new Vector2();
        RBC.bodyType = RigidbodyType2D.Static;
        isHook = true;
        Ora.GetComponent<OraControl>().blockfalling = false;
        Ora.SetActive(false);
        
        button.sprite = hookspr;
        VJ.SetActive(true);
    }
}
