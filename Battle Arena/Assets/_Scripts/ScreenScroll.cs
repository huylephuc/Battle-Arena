using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenScroll : MonoBehaviour
{
    [SerializeField] private RawImage _rawImage;
    [SerializeField] private float x, y;

    private void Update()
    {
        _rawImage.uvRect = new Rect(_rawImage.uvRect.position + new Vector2(x, y) * Time.deltaTime,_rawImage.uvRect.size);
    }
}
