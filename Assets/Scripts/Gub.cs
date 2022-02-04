using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gub : MonoBehaviour
{
    public TrailRenderer trail;
    public GameManager GameManager;
    public Transform Player;
    public Movement PlayerMove;
    public Vector2 direction;
    public float speed;
    public float rotatespeed;
    public bool shot;
    public Color color1;

    Vector3 rotationRight = new Vector3(0, 30, 0);
    Vector3 rotationLeft = new Vector3(0, -30, 0);
    public Rigidbody2D rb;
    public Transform bullet;
    // Start is called before the first frame update
    void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
        trail = this.GetComponent<TrailRenderer>();
    }
    void Start()
    {
        bullet = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - Player.position;
        
        if(!shot)
        {
            this.transform.position = Player.position;
            rb.rotation = -(Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg - 90f);
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - Player.position;
                PlayerMove.enabled = false;
                shot = true;
            } 
        }
        
        if(this.transform.position.x <= GameManager.bottomleft.x || this.transform.position.x >= GameManager.topright.x || this.transform.position.y <= GameManager.bottomleft.y || this.transform.position.y >= GameManager.topright.y)
        {
            shot = false; 
            PlayerMove.enabled = true;
            this.transform.position = Player.position;
            trail.enabled = false;
        }
        if(shot)
        {
            trail.enabled = true;
            Debug.DrawRay(Player.position, direction * 5, color1);
            //transform.Translate(direction.normalized * speed);
        }
    }
    void FixedUpdate()
    {
        if(shot)
        {
            rb.MovePosition(rb.position + (Vector2)bullet.right * speed * Time.deltaTime);
            //Debug.Log(bullet.right);

            if (Input.GetKey(KeyCode.D))
            {
                rb.rotation -= rotatespeed;
            }

            if (Input.GetKey(KeyCode.A))
            {
                rb.rotation += rotatespeed;
            }
        }
        Debug.DrawRay(this.transform.position, bullet.right, Color.red);
    }
}
