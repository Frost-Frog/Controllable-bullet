using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float xmove;
    public float ymove;
    public GameManager GameManager;
    public float speed;
    public float height;
    public float length;
    public Rigidbody2D rb;
    Vector2 Lookdir;
    Vector2 move;
    // Start is called before the first frame update
     void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        height = transform.localScale.y;
        length = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(this.transform.right);
        Lookdir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.transform.position;
        rb.rotation = -(Mathf.Atan2(Lookdir.x, Lookdir.y) * Mathf.Rad2Deg - 90f);
        xmove = Input.GetAxisRaw("Horizontal");
        ymove = Input.GetAxisRaw("Vertical");
        
        if (transform.position.y < GameManager.bottomleft.y + height/2 && ymove < 0)
        {
            ymove = 0;
        }
        if (transform.position.y > GameManager.topright.y - height/2 && ymove > 0)
        {
            ymove = 0;
        }
        if (transform.position.x < GameManager.bottomleft.x + length/2 && xmove < 0)
        {
            xmove = 0;
        }
        if (transform.position.x > GameManager.topright.x - length/2 && xmove > 0)
        {
            xmove = 0;
        }
        
    } 
    void FixedUpdate()
    {
        move = new Vector2(xmove, ymove);
        rb.MovePosition(rb.position + new Vector2(xmove, ymove) * Time.deltaTime * speed);
    }
}
