using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITween : MonoBehaviour
{
    public LeanTweenType easeType;
    [SerializeField] private GameObject Title, PressAnyButton;
    [SerializeField] private float speed;
    void Start()
    {
        titleAnimation();
        
    }

    private void pressbuttonAnimation()
    {
        LeanTween.moveLocalZ(PressAnyButton,0,speed);
    }
    private void titleAnimation()
    {
        LeanTween.scale(Title,new Vector3(1f,1f,1f),speed).setEase(easeType).setOnComplete(pressbuttonAnimation);
    }
}
