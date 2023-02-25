using System.Collections;
using System.Collections.Generic;
using SuperTiled2Unity.Editor;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject start;
    public GameObject target;

    public float speed = 10f;

    private float targetX;

    private float targetY;

    private float playerX;

    private float playerY;
    private float dist;
    private float nextX;
    private float baseY;
    private float height;

    
    
    // Start is called before the first frame update
    void Start()
    {
        start = GameObject.FindWithTag("Player");
        targetX = Input.mousePosition.x;
        targetY = Input.mousePosition.y;
        playerX = start.transform.position.x;
        playerY = start.transform.position.y;
        
    }

    // Update is called once per frame
    void Update()
    {
        dist = targetX - playerX;
        nextX = Mathf.MoveTowards(transform.position.x, targetX, speed * Time.deltaTime);
        baseY = Mathf.Lerp(playerY, targetY, (nextX - playerX) / dist);
        height = 2 * (nextX - playerX) * (nextX - targetX) / (-0.25f * dist * dist);
        Vector2 movePosition = new Vector2(nextX, baseY + height);
    }
}
