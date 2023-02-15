using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform holdSpot;
    public Transform holdSpot2;
    public Transform holdSpot3;
    public Transform holdSpot4;
    
    public LayerMask pickUpMask;
    public GameObject destroyEffect;
    public Vector3 Direction { get; set; }
    private GameObject itemHolding;
    private GameObject itemHolding2;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (itemHolding)
            {
                itemHolding.transform.position = transform.position + Direction;
                itemHolding.transform.parent = null;
                if (itemHolding.GetComponent<Rigidbody2D>())
                    itemHolding.GetComponent<Rigidbody2D>().simulated = true;
                itemHolding = null;
            }
            else
            {
                Collider2D pickUpItem = Physics2D.OverlapCircle(transform.position + Direction, .4f, pickUpMask);

                if (pickUpItem)
                {
                    itemHolding = pickUpItem.gameObject;
                    itemHolding.transform.position = holdSpot.position;
                    itemHolding.transform.parent = transform;
                    if (itemHolding.GetComponent<Rigidbody2D>())
                        itemHolding.GetComponent<Rigidbody2D>().simulated = false;
                }
                
            }
            
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (itemHolding2)
            {
                itemHolding2.transform.position = transform.position + Direction;
                itemHolding2.transform.parent = null;
                if (itemHolding2.GetComponent<Rigidbody2D>())
                    itemHolding2.GetComponent<Rigidbody2D>().simulated = true;
                itemHolding2 = null;
            }
            else
            {
                Collider2D pickUpItem2 = Physics2D.OverlapCircle(transform.position + Direction, .4f, pickUpMask);
                
                if (pickUpItem2)
                {
                    itemHolding2 = pickUpItem2.gameObject;
                    itemHolding2.transform.position = holdSpot2.position;
                    itemHolding2.transform.parent = transform;
                    if (itemHolding2.GetComponent<Rigidbody2D>())
                        itemHolding2.GetComponent<Rigidbody2D>().simulated = false;
                }
                

                
            }
        }
        
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (itemHolding)
            {
                StartCoroutine(ThrowItem(itemHolding));
                itemHolding = null;
            }
        }
    }

    IEnumerator ThrowItem(GameObject item)
    {
        Vector3 startPoint = item.transform.position;
        Vector3 endPoint = transform.position + Direction * 2;
        item.transform.parent = null;
        for (int i = 0; i < 25; i++)
        {
            item.transform.position = Vector3.Lerp(startPoint, endPoint, i * .04f);
            yield return null;
        }
        if (item.GetComponent<Rigidbody2D>())
            item.GetComponent<Rigidbody2D>().simulated = true;
        Instantiate(destroyEffect, item.transform.position, Quaternion.identity);
        Destroy(item);
    }

}