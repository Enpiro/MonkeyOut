using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ball_events : MonoBehaviour
{

    public Rigidbody2D g_jumpForce;
    public GameObject ball_object;
    public GameObject player;
    public float speed;
    public Text score_count_tex;
    public Text level_count_tex;
    public Text lifes_count_tex;
    public int numberOfCollectible;
    public int count = 0;
    public int life = 3;
    public int total_scene_number = 4;


    private Vector2  initPositionBall;
    private Vector2 initPositionPlayer;
    private int nextLevel;
    private GameObject score_saver;
    private int initCount;
    private int max_collectible;
    private ScoreSaverScript score_script;


    void Start()
    {
        score_saver = GameObject.Find("Score_saver");
        if (score_saver != null)
        {
            DontDestroyOnLoad(score_saver);
            score_script = score_saver.GetComponent<ScoreSaverScript>();
            count = score_script.score;
            initCount = score_script.score;
            if (score_script.lifes_saver == 0)
            {
                life = 3;
            }
                else
            {
                life = score_script.lifes_saver;
            }
        }

        initPositionBall = ball_object.transform.position;
        initPositionPlayer = player.transform.position;
        level_count_tex.text = "Level: " + SceneManager.GetActiveScene().buildIndex.ToString();

        score_count_tex.text = "Score: " + count;
        lifes_count_tex.text = "Life's: " + life.ToString();
        nextLevel = SceneManager.GetActiveScene().buildIndex + 1;

    }

    void OnCollisionEnter2D(Collision2D caderea)
    {
        if (caderea.gameObject.CompareTag("ground_wall"))
        {
            LoseManagement();
        }

        if (caderea.gameObject.CompareTag("sky_wall"))
        {
            
            g_jumpForce.velocity = new Vector2(0f, -5f);
        }

        if (caderea.gameObject.CompareTag("collectible"))
        {

            caderea.gameObject.SetActive(false);
            count++;
            score_count_tex.text ="Score: " + count.ToString();

            LoadNextLevel();
           
        }

        if (caderea.gameObject.CompareTag("player"))
        {
            MovementManager(caderea.gameObject);          
        }
    }


    private void LoseManagement()
    {
        if (life > 1 )
        {
            ball_object.transform.position = initPositionBall;
            player.transform.position = initPositionPlayer;
            g_jumpForce.velocity = Vector2.zero;
            life--;
            lifes_count_tex.text = "Life's: " + life.ToString();
        }
        else
        {
            score_script.WinLosseText = "You Lose!";
            this.gameObject.SetActive(false);
            SceneManager.LoadScene(7);
        }
                       
    }

    private void LoadNextLevel()
    {
        max_collectible = initCount + numberOfCollectible;

        if (count == max_collectible )
        {
            if (nextLevel >= total_scene_number)
            {
                score_script.WinLosseText = "You Win!";
                SceneManager.LoadScene(7);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }

    private void MovementManager(GameObject player_caderea)
    {
        Movment movementScript = player.GetComponent<Movment>();
        if (movementScript.int_flagJump == 1)
        {
            g_jumpForce.velocity = new Vector2(0f, 10f);
            if (player_caderea.transform.position.x > ball_object.transform.position.x)
            {
                g_jumpForce.AddForce(Vector2.left * speed);
            }
            else
            {
                g_jumpForce.AddForce(Vector2.right * speed);
            }
        }

    }

}
