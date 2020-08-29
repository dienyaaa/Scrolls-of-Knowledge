using UnityEngine.UI;
using UnityEngine;

public class OpenScrolls : MonoBehaviour
{
    public Button openScroll;
    public Image scrollImg;
    public Button closeScroll;

    public void btnOpenScroll()
    {
        Time.timeScale = 0;
        scrollImg.gameObject.SetActive(true);
        closeScroll.gameObject.SetActive(true);
    }

    public void btnCloseScroll()
    {
        Time.timeScale = 1;
        scrollImg.gameObject.SetActive(false);
        closeScroll.gameObject.SetActive(false);
    }


    
}
