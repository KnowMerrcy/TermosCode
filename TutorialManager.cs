using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] tutotialPanels;
    public int panelIndex = 0;

    // Update is called once per frame
    void Update()
    {
        if (GlobalVariables.isGamePlayedFirstTime)
        {
            StartCoroutine(Wait());
           
            for (int i = 0; i < tutotialPanels.Length; i++)
            {
                if (i == panelIndex)
                {
                    tutotialPanels[panelIndex].SetActive(true);
                }
                else
                {
                    tutotialPanels[i].SetActive(false);
                }
            }

            if (Input.touchCount > 0)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    panelIndex++;
                    if (panelIndex > tutotialPanels.Length - 1)
                    {
                        tutotialPanels[tutotialPanels.Length - 1].SetActive(false);
                        StopAllCoroutines();
                        Time.timeScale = 1;
                        GlobalVariables.isGamePlayedFirstTime = false;
                        this.enabled = false;
                        
                    }
                }
            }
        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.8f);
        Time.timeScale = 0;
    }
}
