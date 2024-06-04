using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChangeTextureOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public RawImage rawImage; // Referencia a la RawImage que queremos cambiar
    public Texture hoverTexture; // La textura que se mostrar� al pasar el cursor
    private Texture originalTexture; // La textura original

    void Start()
    {
        // Guardar la textura original
        originalTexture = rawImage.texture;
    }

    // Este m�todo se llama cuando el cursor entra en el �rea del objeto
    public void OnPointerEnter(PointerEventData eventData)
    {
        rawImage.texture = hoverTexture;
    }

    // Este m�todo se llama cuando el cursor sale del �rea del objeto
    public void OnPointerExit(PointerEventData eventData)
    {
        rawImage.texture = originalTexture;
    }
}
