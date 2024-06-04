using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageHoverController : MonoBehaviour
{
    public Texture2D nuevaTextura; // Asigna la nueva textura en el Inspector
    private RawImage rawImage;
    public Texture2D texturaOriginal;

    private void Start()
    {
        rawImage = GetComponent<RawImage>();
        texturaOriginal = rawImage.texture as Texture2D;
    }

    public void OnPointerEnter()
    {
        rawImage.texture = nuevaTextura;
    }

    public void OnPointerExit()
    {
        rawImage.texture = texturaOriginal;
    }
}

