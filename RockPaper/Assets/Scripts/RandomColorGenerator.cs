using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomColorGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<Image>().color = new(GetRandomColor(), GetRandomColor(), GetRandomColor());
    }

    private float GetRandomColor() => Random.Range(0.5f, 1);

    // Update is called once per frame
    void Update()
    {
        
    }
}
