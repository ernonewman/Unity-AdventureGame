using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameSceneController : MonoBehaviour
{
    [Header("Game")]
    public Player CurrentPlayer;

    [Header("UI")]
    public GameObject[] Hearts;
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
            for (int i = 0; i < Hearts.Length; i++)
            {
                Hearts[i].SetActive(i < CurrentPlayer.Health);
            }

            BombText.text = $"Bombs: {CurrentPlayer.BombAmount}";
            ArrowText.text = $"Arrow: {CurrentPlayer.ArrowAmount}";
        }
        else
        {
            for (int i = 0; i < Hearts.Length; i++)
            {
                Hearts[i].SetActive(false);
            }

            //BombText.text = string.Empty;
            //ArrowText.text = string.Empty;
        }
    }
}
