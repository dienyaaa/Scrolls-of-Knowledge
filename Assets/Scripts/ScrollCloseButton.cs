using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollCloseButton : MonoBehaviour
{
    void OnMouseDown(){
        FindObjectOfType<ScrollController>().CloseScroll();
    }
}
