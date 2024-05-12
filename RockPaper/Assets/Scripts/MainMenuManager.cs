using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private Button PlayButton;
    [SerializeField] private TextMeshProUGUI HighScoreText;

    private void Start(){
        HighScoreText.text = PlayerPrefs.GetInt(Constants.HIGH_SCORE).ToString();
        PlayButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(1);
        });
    }
}
