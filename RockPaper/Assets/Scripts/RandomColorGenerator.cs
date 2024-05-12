using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomColorGenerator : MonoBehaviour
{
    private void Start()
    {
        transform.GetComponent<Image>().color = new(GetRandomColor(), GetRandomColor(), GetRandomColor());
    }

    private float GetRandomColor() => Random.Range(0.5f, 1);
}
