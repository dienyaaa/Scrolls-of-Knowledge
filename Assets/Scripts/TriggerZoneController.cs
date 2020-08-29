using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZoneController : MonoBehaviour
{
    [SerializeField]
    private QuestionManController mainController;
    public QuestionManController GetMainController(){
        return mainController;
    }
}
