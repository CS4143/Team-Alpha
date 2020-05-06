using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    public GameObject prefab;
    Vector3 center;
    public float radius;
    private List<GameObject> enemies;
    public int EnemiesAtRoundStart;
    public float enemyGains;
    public TextMeshPro Eliminations;
    public TextMeshPro Rounds;
    public TextMeshPro Timer;
    public TextMeshPro healthDisplay;
    private float time = 0f;
    bool timeClock = false;
    private GameObject PlayerObject;

    private float round = 0;
    //private float time = 0;
    private int eliminations = 0;
    // Start is called before the first frame update
    void Start()
    {
        PlayerObject = GameObject.FindGameObjectWithTag("Player");
        center = this.transform.position;
        enemies = new List<GameObject>();
        Vector3 pos = new Vector3(0, .17f, 23.5f);
        Rounds.text = round.ToString();
        Eliminations.text = eliminations.ToString();
        Timer.text = "0";
        enemies.Add(Instantiate(prefab, pos, prefab.transform.rotation));
    }

    // Update is called once per frame
    void Update()
    {
        int health = PlayerObject.GetComponent<Player>().currentHealth;
        if(health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        healthDisplay.text = health.ToString();
        if (timeClock)
            Timer.text = (time += Time.deltaTime).ToString().Substring(0,6);

        if (checkRoundEnd())
        {
            timeClock = true;
            print("spawningEnemies");
            round++;
            Rounds.text = round.ToString();
            SpawnEnemy(enemies, EnemiesAtRoundStart);
            EnemiesAtRoundStart = Mathf.RoundToInt(EnemiesAtRoundStart * enemyGains);
        }
        
        for(int i = 0; i < enemies.Count; ++i)
        {
            if (enemies[i] == null)
            {
                eliminations++;
                Eliminations.text = eliminations.ToString();
                enemies.RemoveAt(i);
            }
        }
    }

    void SpawnEnemy(List<GameObject> enemies, int enemiesToSpawn)
    {
        for (int i = 0; i < EnemiesAtRoundStart; ++i)
        {
            Vector3 PlayerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
            Vector3 pos = PlayerPos;
            while (Vector3.Distance(pos, PlayerPos) < 9){
                float ang = Random.value * 360;
                pos.x = center.x + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
                pos.y = 0;
                pos.z = center.z + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
            }
            enemies.Add(Instantiate(prefab, pos, prefab.transform.rotation));
        }
        ///enemy = Instantiate(prefab);
            
    }

    bool checkRoundEnd()
    {
        return !(enemies.Count > 0);
    }
}
