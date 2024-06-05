using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChangeTextureOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public RawImage rawImage; // Referencia a la RawImage que queremos cambiar
    public Texture hoverTexture; // La textura que se mostrará al pasar el cursor
    private Texture originalTexture; // La textura original

    void Start()
    {
        // Guardar la textura original
        originalTexture = rawImage.texture;
    }

    // Este método se llama cuando el cursor entra en el área del objeto
    public void OnPointerEnter(PointerEventData eventData)
    {
        rawImage.texture = hoverTexture;
    }

    // Este método se llama cuando el cursor sale del área del objeto
    public void OnPointerExit(PointerEventData eventData)
    {
        rawImage.texture = originalTexture;
    }
}
