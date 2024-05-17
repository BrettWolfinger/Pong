using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Attach to score zones on either end to handle keeping score
public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreUI;
    AudioSource audioSource;
    int score = 0;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnEnable() {
        GameManager.ResetState += Reset;
    }

    private void OnDisable() {
        GameManager.ResetState -= Reset;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        audioSource.Play();
        score++;
        scoreUI.text = score.ToString();
    }

    private void Reset()
    {
        score = 0;
        scoreUI.text = score.ToString();
    }
}
