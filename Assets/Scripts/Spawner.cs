using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    
    public GameObject enemy;
    public float spot;
    public float spawntime;
    Vector3 Screenprop;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Spawnerz");
        Screenprop = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        Debug.Log(Screenprop);
    }

    // Update is called once per frame
    void Update()
    {
        
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
            Instantiate(this.enemy, new Vector3(spot, Screenprop.y, 0.0f), Quaternion.identity);
        }
        else if(spot > Screenprop.x && spot < Screenprop.x + Screenprop.y)
        {
            Instantiate(this.enemy, new Vector3(Screenprop.x, spot - Screenprop.x, 0.0f), Quaternion.identity);
        }
        if(spot > Screenprop.x + Screenprop.y && spot < (Screenprop.x * 2) + Screenprop.y)
        {
            Instantiate(this.enemy, new Vector3(spot - (Screenprop.x + Screenprop.y), 0.0f, 0.0f), Quaternion.identity);
        }
        else if(spot > (Screenprop.x * 2) + Screenprop.y)
        {
            Instantiate(this.enemy, new Vector3(0.0f, spot - ((Screenprop.x * 2) + Screenprop.y), 0.0f), Quaternion.identity);
        }
    }
}
