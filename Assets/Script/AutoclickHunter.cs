using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class AutoclickHunter : MonoBehaviour
{
    public TextMeshProUGUI LeadScore;
    public TextMeshProUGUI Price;
    public int AutoclickPrice;
    public float AutoclickValue = 0.2f;
    private int AutoclickSpeed = 1;
    public bool AutoclickEnabled = false;
    public GameObject PrefabToInstantiate;
    public Image BackgroundPicture;
    public ClikerData clikerData;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AutoClick());
    }

    private IEnumerator AutoClick()
    {

        while (!AutoclickEnabled)
        {
            yield return new WaitForSeconds(AutoclickSpeed);
        }
        while (AutoclickEnabled)
        {
            
            AutoClickPoint();
            yield return new WaitForSeconds(AutoclickSpeed);
        }

    }

    public void AutoClickPoint()
    {
        // met a jour le score
        clikerData.ClickHunterScore1 += AutoclickValue;
        LeadScore.text = clikerData.ClickHunterScore1.ToString();
    }

    public void SetNewPrice()
    {
        if (clikerData.ClickHunterScore1 >= AutoclickPrice)
        {
            // Soustrait le prix du boost au score
            clikerData.ClickHunterScore1 -= AutoclickPrice;

            //met a jour les valeur des prix.
            AutoclickPrice += AutoclickPrice;
            Price.text = AutoclickPrice.ToString();
        }
        
    }

    public void OnbuttonClick()
    {
        
        if (!AutoclickEnabled)
        {
            AutoclickEnabled = true;
            Start();
            AddPicture();
            SetNewPrice();
        }
        else
        {

            AutoclickValue += (AutoclickValue * 0.2f);
            AddPicture();
            SetNewPrice();
        }
        
    }

    public void AddPicture()
    {
        RectTransform rt = BackgroundPicture.GetComponent<RectTransform>();

        float randomX = Random.Range(rt.rect.xMin, rt.rect.xMax);
        float randomY = Random.Range(rt.rect.yMin, rt.rect.yMax);

        Vector3 randomPosition = new Vector3(randomX, randomY, 0f);

        var newPics =Instantiate(PrefabToInstantiate, BackgroundPicture.transform);
        newPics.transform.localPosition = randomPosition;
    }
}
