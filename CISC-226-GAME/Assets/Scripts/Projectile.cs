using System.Collections;
using System.Collections.Generic;
using SuperTiled2Unity.Editor;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 start;
    private Rigidbody2D rb;
    private Vector3 worldPosition;
    protected float timePassed;
    
    
    // Start is called before the first frame update
    void Start()
    {
        worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        start = GameObject.FindWithTag("Player").transform.position;

        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (timePassed < 5f)
        {
            timePassed += Time.deltaTime;
            transform.position = MathParabola.Parabola(start, worldPosition, 5f, timePassed / 5f);

        }
        
    }
}
