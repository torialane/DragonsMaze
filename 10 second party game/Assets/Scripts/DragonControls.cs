using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DragonControls : MonoBehaviour
{
    public float timer = 10.0f;
    public TextMeshProUGUI starttext;
    public TextMeshProUGUI timertext;
    
    public AudioSource musicSource;
    public AudioClip Loss;
    public AudioClip Win;

    bool music = false;

    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;
    bool playing = false;
    float speed = 0.0f;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Return)&&playing==false)
        {
            musicSource.Play();
            playing = true;
            speed = 4.0f;
            starttext.text = "";
            

        }

        

            
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }
        if (timer >= 0 &&playing==true)
            
        {
            timer -= Time.deltaTime;
            timertext.text = timer.ToString();
            


        }
        if (timer <= 0)
        {
            starttext.text = "You lost game over! Press Escape to close the game.";
            speed = 0.0f;
            if (music == false)
            {
                music = true;
                musicSource.Stop();
                musicSource.clip = Loss;
                musicSource.loop = (false);
                musicSource.Play();

            }


        }
      
        if (rigidbody2d.position.y<=-4.0)
        {
            if (music == false)
            {
                music = true;
                musicSource.Stop();
                musicSource.clip = Win;
                musicSource.loop = (false);
                musicSource.Play();
            }
            speed = 0.0f;
            playing = false;
            starttext.text = "You win! Press Escape to close game.";

        }
       
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }
    

}