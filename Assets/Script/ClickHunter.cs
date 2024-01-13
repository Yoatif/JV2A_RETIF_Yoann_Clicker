using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClickHunter : MonoBehaviour
{
    public TextMeshProUGUI scoreTextHunter1;
    //public TextMeshProUGUI scoreTextHunter2;

    public Image HunterPicture;
    public ClikerData clikerData;
    // Start is called before the first frame update
    void Start()
    {
        clikerData.ClickHunterScore1 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void UpdateHunterScore()
    {
        scoreTextHunter1.text = clikerData.ClickHunterScore1.ToString();
        //scoreTextHunter2.text = clikerData.ClickHunterScore2.ToString();
    }

    public void UpdateHunterPicture()
    {
        if (clikerData.HunterType>=0 && clikerData.HunterType<clikerData.HunterPic.Length)
        {
            HunterPicture.sprite = clikerData.HunterPic[clikerData.HunterType];
        }
    }

    public void HunterCliker()
    {
        if (clikerData.HunterHealth > 0)
        {
            clikerData.HunterHealth--;
            
            if(clikerData.HunterHealth <= 0)
            {
                GenerateNewHunter();
                UpdateHunterPicture();
            }

            switch (clikerData.HunterType)
            {
                case 0:
                    clikerData.ClickHunterScore1++;
                    break;
                case 1:
                    clikerData.ClickHunterScore2++;
                    break;
            }

            UpdateHunterScore();
        }
    }

    public void GenerateNewHunter()
    {
        clikerData.HunterType = Random.Range(0, 1);
        

        switch(clikerData.HunterType)
        {
            case 0:
                clikerData.HunterHealth = 20;
                break;
            case 1:
                clikerData.HunterHealth = 100;
                break;
        }
    }
}
