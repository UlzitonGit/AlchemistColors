using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorMixer : MonoBehaviour
{
    [SerializeField] GameObject[] firstColor;
    [SerializeField] GameObject[] secondColor;
    [SerializeField] GameObject[] resultColor;
    public int firstColorId = 0;
    public int secondColorId = 0;
    public string currentColor = "green";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            if(firstColorId == firstColor.Length - 1)
            {
                print("yep");
                firstColorId = 0;
                firstColor[firstColor.Length - 1].SetActive(false);
                firstColor[firstColorId].SetActive(true);
            }
            else
            {
                firstColorId++;
                firstColor[firstColorId - 1].SetActive(false);
                firstColor[firstColorId].SetActive(true);
            }
            CheckResult();

        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            if (secondColorId == secondColor.Length - 1)
            {
                secondColorId = 0;
                secondColor[secondColor.Length - 1].SetActive(false);
                secondColor[secondColorId].SetActive(true);
            }
            else
            {
                secondColorId++;
                secondColor[secondColorId - 1].SetActive(false);
                secondColor[secondColorId].SetActive(true);
            }
            CheckResult();

        }
    }
    private void CheckResult()
    {
        for (int i = 0; i < resultColor.Length; i++)
        {
            if (resultColor[i].name.Contains(secondColor[secondColorId].name) && resultColor[i].name.Contains(firstColor[firstColorId].name))
            {
                resultColor[i].SetActive(true);
                currentColor = resultColor[i].GetComponent<ColorName>().color;
            }
            else
            {
                resultColor[i].SetActive(false);    
            }
        }
    }
}
