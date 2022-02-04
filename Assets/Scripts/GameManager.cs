using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> enemies;
    public GameObject enemy;
    GameObject enemyprop;
    public float spot;
    public float spawntime;
    Vector3 Screenprop;
    public int lives;
    public TextMeshProUGUI scoretext;
    public float score;
    public Vector2 bottomleft, topright;
    public GameObject Player;
    Vector2 startingpos;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Spawnerz");
        Screenprop = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        Debug.Log(Screenprop);
        startingpos = Player.transform.position;
        bottomleft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        topright = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LifeLost()
    {
        lives--;
        if(lives == 0)
        {
            GameOver();
        }
        else
        {
            Player.transform.position = startingpos;
        }
    }
    public void SetScore()
    {
        scoretext.text = score.ToString();
    }
    public void GameOver()
    {
        enemies.ToArray();
        foreach(GameObject enemy in enemies)
        {
            enemy.SetActive(false);
        }
        Player.SetActive(false);
    }
    
    IEnumerator Spawnerz()
    {
        yield return new WaitForSeconds(spawntime);
        Spawn();
        StartCoroutine("Spawnerz");
    }

    void Spawn()
    {
        spot = Random.Range(0.0f, (Screenprop.x * 2) + (Screenprop.y * 2));
        if(spot < Screenprop.x)
        {
            this.enemyprop = Instantiate(this.enemy, new Vector3(spot, Screenprop.y, 0.0f), Quaternion.identity);
            enemies.Add(this.enemyprop);
        }
        else if(spot > Screenprop.x && spot < Screenprop.x + Screenprop.y)
        {
            this.enemyprop = Instantiate(this.enemy, new Vector3(Screenprop.x, spot - Screenprop.x, 0.0f), Quaternion.identity);
            enemies.Add(this.enemyprop);
        }
        if(spot > Screenprop.x + Screenprop.y && spot < (Screenprop.x * 2) + Screenprop.y)
        {
            this.enemyprop = Instantiate(this.enemy, new Vector3(spot - (Screenprop.x + Screenprop.y), 0.0f, 0.0f), Quaternion.identity);
            enemies.Add(this.enemyprop);
        }
        else if(spot > (Screenprop.x * 2) + Screenprop.y)
        {
            this.enemyprop = Instantiate(this.enemy, new Vector3(0.0f, spot - ((Screenprop.x * 2) + Screenprop.y), 0.0f), Quaternion.identity);
            enemies.Add(this.enemyprop);
        }
    }
}
