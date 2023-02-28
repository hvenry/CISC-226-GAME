using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform holdSpot;
    public Transform holdSpot2;
    public Transform holdSpot3;
    public Transform holdSpot4;
    private Transform[] spots = new Transform[4];
    public GameObject animalPrefab;
    
    public LayerMask pickUpMask;
    public GameObject destroyEffect;
    public Vector3 Direction { get; set; }
    private GameObject itemHolding;
    private GameObject itemHolding2;
    private GameObject itemHolding3;
    private GameObject itemHolding4;
    private GameObject[] holdings = new GameObject[4];

    void Start()
    {
        holdings = new GameObject[] { itemHolding, itemHolding2, itemHolding3, itemHolding4 };
        spots = new Transform[] { holdSpot, holdSpot2, holdSpot3, holdSpot4 };
    }
    void Update()
    {
        // for (int i = 0; i < holdings.Length; i++)
        // {
        //     GameObject item = holdings[i];
        //     if (item)
        //     {
        //         item.transform.position = spots[i].position;
        //     }
        // }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Collider2D pickUpItem = Physics2D.OverlapCircle(transform.position + Direction, .4f, pickUpMask);

            if (pickUpItem)
            {
                for (int i = 0; i < holdings.Length;i++)
                {
                    GameObject item = holdings[i];
                    if (item)
                        continue;
                    item = pickUpItem.gameObject;
                    item.transform.position = spots[i].position;
                    item.transform.parent = transform;
                    MovementSM script = item.GetComponent<MovementSM>();
                    script.ChangeState(script.heldState);
                    item.GetComponent<Rigidbody2D>().simulated = false;

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
                MovementSM script = itemHolding.GetComponent<MovementSM>();
                script.ChangeState(script.thrownState);
                itemHolding.GetComponent<Rigidbody2D>().simulated = true;
                itemHolding = itemHolding2;
                itemHolding2 = itemHolding3;
                itemHolding4 = null;
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