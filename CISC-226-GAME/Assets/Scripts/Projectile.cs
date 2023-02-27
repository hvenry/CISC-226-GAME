using System.Collections;
using System.Collections.Generic;
using SuperTiled2Unity.Editor;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject start;
    public GameObject target;

    public float speed = 50f;

    public float targetX;

    public float targetY;

    private float playerX;

    private float playerY;
    private float dist;
    private float nextX;
    private float baseY;
    private float height;

    private Rigidbody2D rb;
    private Vector3 worldPosition;
    
    
    // Start is called before the first frame update
    void Start()
    {
        worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        start = GameObject.FindWithTag("Player");
        targetX = worldPosition.x;
        targetY = worldPosition.y;
        playerX = start.transform.position.x;
        playerY = start.transform.position.y;
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        dist = targetX - playerX;
        nextX = Mathf.MoveTowards(rb.position.x, targetX, speed * Time.deltaTime);
        baseY = Mathf.Lerp(playerY, targetY, (nextX - playerX) / dist);
        height = 2 * (nextX - playerX) * (nextX - targetX) / (-0.25f * dist * dist);
        Vector2 movePosition = new Vector2(nextX, baseY + height);
        rb.MovePosition(new Vector2(nextX, baseY + height));
        
    }
}
