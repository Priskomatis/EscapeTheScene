using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightEffect : MonoBehaviour
{
    private Renderer renderer;
    private Material material;
    private bool isEmissionEnabled = false;
    private Color originalEmissionColor;


    void Start()
    {
        renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            material = renderer.material;

            // Store the original emission color
            originalEmissionColor = material.GetColor("_EmissionColor");
        }
    }

    public void ToggleEmission()
    {
        // Toggle emission state
        isEmissionEnabled = !isEmissionEnabled;

        if (isEmissionEnabled)
        {
            // Enable emission and set the desired color
            material.EnableKeyword("_EMISSION");
            material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
            material.SetColor("_EmissionColor", new Color(84f / 255f, 67f / 255f, 0f));
        }
        else
        {
            // Disable emission and restore the original color
            material.DisableKeyword("_EMISSION");
            material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
            material.SetColor("_EmissionColor", originalEmissionColor);
        }
    }
}