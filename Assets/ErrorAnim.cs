using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorAnim : MonoBehaviour
{
    [SerializeField] private GameObject error;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        LeanTween.scale(error, new Vector2(2,2), time);
    }
}
