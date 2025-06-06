using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public TextMeshProUGUI timeUI;
    public GameObject RankingUI;
    [SerializeField] private int mapNumber;

    void Start()
    {
         
    }
    void Update()
    {
        UpdateTimeUI();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TransitionEffect.instance.MoveScene("MenuScene");
        }
    }

    void UpdateTimeUI()
    {
        float time = GameManager.instance.runTime;
        float min = (int)time / 60;
        float sec = (int)time % 60;
        float other = (int)((time - (int)time) * 100);

        timeUI.text = $"{min,2:00} : {sec,2:00} : {other,2:00}";
    }

    public void PlayEndUI()
    {
        StartCoroutine(EndUIAnimation());
    }

    IEnumerator EndUIAnimation()
    {
        yield return new WaitForSeconds(1);

        RankingUI.SetActive(true);
        GameManager.instance.AddRecord("test", GameManager.instance.runTime, mapNumber);
    }

    public void BackToLobby()
    {
        TransitionEffect.instance.MoveScene("MenuScene");
    }
}
