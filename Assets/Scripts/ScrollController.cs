﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class ScrollController : MonoBehaviour
{
    public int currentIndex = -1;

    [SerializeField]
    private GameObject scrollHolder;

    [SerializeField]
    private GameObject scrollCloser;
 
    [SerializeField]
    private GameObject nextScroll;
 
    [SerializeField]
    private Image scrollImage;

    [SerializeField]
    private GameObject previuosScroll;
    
    private List<Sprite> scrolls;
 
    void Awake(){
        scrolls = new List<Sprite>();
        SetActiveUI(false);
    }
 

    public void OpenScroll(bool isButton = false){
        if(scrollHolder.activeSelf && isButton){
            CloseScroll();
            return;
        }
        if(isValidIndex){
            SetActiveUI(true);
            scrollImage.sprite = scrolls[currentIndex];
        }
    }
      
    public void CloseScroll(){
        if(isValidIndex){
            SetActiveUI(false);
        }
    }
 
    public void TakeScroll(ScrollDate scroll){
        if(scroll == null) return;
        currentIndex++;
        scrolls.Add(scroll.scroll);
        if(scrollHolder.activeSelf){
            OpenScroll();
        }
    }
 
    public void GoNextScroll(){
        if(isValidIndex){
            if(currentIndex < scrolls.Count - 1)
            {
                currentIndex++;
                OpenScroll();
            }
        }
    }
 
    public void GoPreviousScroll(){
        if(isValidIndex){
            if(currentIndex > 0)
            {
                currentIndex--;
                OpenScroll();
            }
        }
    }
 
    private void SetActiveUI(bool isActive){
        scrollHolder.SetActive(isActive);
        scrollCloser.SetActive(isActive);
        nextScroll.SetActive(isActive && currentIndex < scrolls.Count - 1);
        previuosScroll.SetActive(isActive && currentIndex > 0);
    }
 
    private bool isValidIndex => currentIndex > -1 && currentIndex < scrolls.Count;
}