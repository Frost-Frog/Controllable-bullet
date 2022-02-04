using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject Game;
    public float speed;
    public Transform Player;
    public Rigidbody2D rb;
    Vector2 Lookdir;
    
    void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Lookdir = Player.position - this.transform.position;
        rb.rotation = -(Mathf.Atan2(Lookdir.x, Lookdir.y) * Mathf.Rad2Deg - 90f);
        //Debug.Log(Camera.main.ScreenToWorldPoint( new Vector2(Screen.width, Screen.height)));
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + (Vector2)transform.right * Time.deltaTime * speed);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Game = GameObject.Find("GameManager");
        if(collision.gameObject.tag == "Character")
        {
            Game.GetComponent<GameManager>().LifeLost();
        }
        if(collision.gameObject.tag == "Gub")
        {
            this.gameObject.SetActive(false);
            Game.GetComponent<GameManager>().score++;
            Game.GetComponent<GameManager>().SetScore();
        }
    }
}
