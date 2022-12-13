using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{


    [SerializeField] public TextMeshProUGUI scoreText;
    public static ScoreManager instance;

    int score = 0;

    private void Awake(){
    instance = this;
    }

    // Start is called before the first frame update
    void Start(){
        scoreText.text = score.ToString();
    }
    

    public void AddPoints(int value){
        score += value;
        scoreText.text = score.ToString();

    }

    

}
