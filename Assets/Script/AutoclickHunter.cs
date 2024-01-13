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
            Debug.Log("je fonctionne");
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

            //utilise l'équation pour calculer le nouveau prix et le convertit en integer.
            //oui Louis, c'est l'équation qui calcul l'expérience dans pokemon 1ere génération.
            //non ce n'est pas un clin d'oeil, juste que sa me paraissait plus doux que celle de DnD
            float newFloatPrice = Mathf.Round((4 * Mathf.Pow(AutoclickPrice, 3)) / 5);
            int newIntPrice = Mathf.RoundToInt(newFloatPrice);

            //met a jour les valeur des prix.
            AutoclickPrice = newIntPrice;
            Price.text = AutoclickPrice.ToString();
        }
        
    }

    public void OnbuttonClick()
    {
        Debug.Log("AutoClick " +AutoclickEnabled);
        if (!AutoclickEnabled)
        {
            AutoclickEnabled = true;
            Start();
        }
        else
        {
            AutoclickValue *= 0.2f;

            RectTransform rt = BackgroundPicture.GetComponent<RectTransform>();
            Vector3 imageBottomLeft = rt.position;

            // Instancie le prefab à la position du coin inférieur gauche du UI Image
            Instantiate(PrefabToInstantiate, imageBottomLeft, Quaternion.identity);
        }
        
    }
}
