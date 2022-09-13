using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int scoreNumber;
    private bool waitInvoke;
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(ScoreCounter), 1f);
    }


    private void ScoreCounter()
    {
        scoreNumber += 1;
        scoreText.SetText("" + scoreNumber);
        Invoke(nameof(ScoreCounter), 1f);
    }
}
