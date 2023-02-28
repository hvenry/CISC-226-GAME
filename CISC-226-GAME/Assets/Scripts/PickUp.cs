using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform holdSpot;
    public Transform holdSpot2;
    public Transform holdSpot3;
    public Transform holdSpot4;
    public GameObject animalPrefab;
    
    public LayerMask pickUpMask;
    public GameObject destroyEffect;
    public Vector3 Direction { get; set; }
    private GameObject itemHolding;
    private GameObject itemHolding2;
    private GameObject itemHolding3;
    private GameObject itemHolding4;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
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

        if (Input.GetKeyDown(KeyCode.Alpha2))
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
        
        
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (itemHolding3)
            {
                itemHolding3.transform.position = transform.position + Direction;
                itemHolding3.transform.parent = null;
                if (itemHolding3.GetComponent<Rigidbody2D>())
                    itemHolding3.GetComponent<Rigidbody2D>().simulated = true;
                itemHolding3 = null;
            }
            else
            {
                Collider2D pickUpItem3 = Physics2D.OverlapCircle(transform.position + Direction, .4f, pickUpMask);
                
                if (pickUpItem3)
                {
                    itemHolding3 = pickUpItem3.gameObject;
                    itemHolding3.transform.position = holdSpot3.position;
                    itemHolding3.transform.parent = transform;
                    if (itemHolding3.GetComponent<Rigidbody2D>())
                        itemHolding3.GetComponent<Rigidbody2D>().simulated = false;
                }
                

                
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (itemHolding4)
            {
                itemHolding4.transform.position = transform.position + Direction;
                itemHolding4.transform.parent = null;
                if (itemHolding4.GetComponent<Rigidbody2D>())
                    itemHolding4.GetComponent<Rigidbody2D>().simulated = true;
                itemHolding4 = null;
            }
            else
            {
                Collider2D pickUpItem4 = Physics2D.OverlapCircle(transform.position + Direction, .4f, pickUpMask);
                
                if (pickUpItem4)
                {
                    itemHolding4 = pickUpItem4.gameObject;
                    itemHolding4.transform.position = holdSpot2.position;
                    itemHolding4.transform.parent = transform;
                    if (itemHolding4.GetComponent<Rigidbody2D>())
                        itemHolding4.GetComponent<Rigidbody2D>().simulated = false;
                }
                

                
            }
        }
        
        
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (itemHolding)
            {
                StartCoroutine(ThrowItem(itemHolding));
                itemHolding = null;
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (itemHolding)
            {
                Instantiate(animalPrefab, itemHolding.transform.position, Quaternion.identity);
                Destroy(itemHolding);
            }

            if (itemHolding2)
            {
                Instantiate(animalPrefab, itemHolding.transform.position, Quaternion.identity);
                Destroy(itemHolding2);
            }

            if (itemHolding3)
            {
                Instantiate(animalPrefab, itemHolding.transform.position, Quaternion.identity);
                Destroy(itemHolding3);
            }

            if (itemHolding4)
            {
                Instantiate(animalPrefab, itemHolding.transform.position, Quaternion.identity);
                Destroy(itemHolding4);
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