using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayScore : MonoBehaviour
{
    public static DisplayScore instance;

    public void Awake(){

        if(instance == null) instance = this;
        else Destroy(this);

        _increment_Text.gameObject.SetActive(false);
    }

    [SerializeField] private TMP_Text _score_Text;
    [SerializeField] private TMP_Text _increment_Text;
    private int _score = 0;
    private int _increment_amount = 0;

    public void IncrementScore(int value){

        _score += value;
        _score_Text.text = $"Score : {_score}";
        _increment_amount = value;

        StartCoroutine(nameof(DisplayIncrement));
    }

    private IEnumerator DisplayIncrement(){

        _increment_Text.text = $"+{_increment_amount}";
        _increment_Text.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        _increment_Text.gameObject.SetActive(false);

    }
}
