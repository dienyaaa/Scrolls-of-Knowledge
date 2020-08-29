using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionManController : MonoBehaviour
{
    [SerializeField]
    private float correctAnswer;

    [SerializeField]
    private BoxCollider2D triggerZone;
    [SerializeField]
    private BoxCollider2D manColliderZone;

    [SerializeField]
    private Sprite correctSprite;

    [SerializeField]
    private SpriteRenderer manSprite;
    public bool Resolve(float answer){
        var result = answer.Equals(correctAnswer);
        if(result)
            MakeStateResolved();
       return result;
    }

    private void MakeStateResolved(){
        triggerZone.gameObject.SetActive(false);
        manColliderZone.isTrigger = true;
        manSprite.sprite = correctSprite;
    }
}
