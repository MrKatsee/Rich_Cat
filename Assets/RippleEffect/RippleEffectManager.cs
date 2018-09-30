using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class RippleEffectManager:MonoBehaviour
{
    static public List<RippleEffect> rippleEffects = new List<RippleEffect>();

    private void Awake()
    {
        rippleEffects = new List<RippleEffect>();
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (rippleEffects.Count == 0)
        {
            Graphics.Blit(source, destination);
        }
        if (rippleEffects.Count == 1)
        {
            Graphics.Blit(source, destination, rippleEffects[0].Material);
            return;
        }

        RenderTexture tempTexture = RenderTexture.GetTemporary(source.width, source.height);
        for (int i = 0; i < rippleEffects.Count; i++)
        {
            if (i == 0)
                Graphics.Blit(source, tempTexture, rippleEffects[i].Material);
            else if (i != rippleEffects.Count - 1)
                Graphics.Blit(tempTexture, rippleEffects[i].Material);
            else //if (i == rippleEffects.Count - 1)
                Graphics.Blit(tempTexture, destination, rippleEffects[i].Material);
        }
        RenderTexture.ReleaseTemporary(tempTexture);

    }

}