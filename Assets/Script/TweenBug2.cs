using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenBug2 : MonoBehaviour
{
    public LeanTweenType easeType;
    [SerializeField] private GameObject terrain;
    [SerializeField] private float speed;
    [SerializeField] private float x,y;

    // Start is called before the first frame update
    void Start()
    {
        LeanTween.scale(terrain, new Vector2(x,y),speed).setEase(easeType).setLoopClamp();
    }
}
