using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gameController : MonoBehaviour
{

    public TMP_Text time_txt;
    public TMP_Text message_txt;
    public float score_timer;
    public bool play = false;
    
    public void setTime(){
        int minutes = (int)(score_timer / 60f);
        int seconds = (int)(score_timer - minutes * 60f);
        int cents = (int)((score_timer - (int)score_timer) * 100f);
        time_txt.text = string.Format("Tiempo: {0}:{1}:{2} m", minutes, seconds, cents);
    }

    public void win(){
        play = false;
        setTime();
        message_txt.text = "¡WINNER!";
    }

    public void lost(){
        play = false;
        setTime();
        message_txt.text = "GAME OVER";
    }

    public void PlayGame(){
        RestartGame();
        play = true;
    }

    public void QuitGame(){
        Application.Quit();
    }

    public void RestartGame(){
        
        // restart enemies
        foreach( GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy")){
            Destroy(enemy);
        }

        // restar player
        GameObject.Find("Player").GetComponent<player>().restart();

        // restart time and message
        message_txt.text = "";
        score_timer = 0.0f;
    }

    void Update()
    {
        if(play == true){
            score_timer += Time.deltaTime;
            setTime();
        }
    }
}
