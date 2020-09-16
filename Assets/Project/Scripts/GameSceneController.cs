using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSceneController : MonoBehaviour
{
    [Header("Game")]
    public Player CurrentPlayer;

    [Header("UI")]
    public Text HealthText;
    public Text BombText;
    public Text ArrowText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentPlayer != null)
        {
            HealthText.text = $"Health: {CurrentPlayer.Health}";
            BombText.text = $"Bombs: {CurrentPlayer.BombAmount}";
            ArrowText.text = $"Arrow: {CurrentPlayer.ArrowAmount}";
        }
        else
        {
            HealthText.text = "Health: 0";
            BombText.text = string.Empty;
            ArrowText.text = string.Empty;
        }
    }
}
