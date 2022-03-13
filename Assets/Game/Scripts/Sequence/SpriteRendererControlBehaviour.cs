using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class SpriteRendererControlBehaviour : PlayableBehaviour
{
    protected static readonly int shPropIntensity = Shader.PropertyToID("_GradientAdjustment");
    public AnimationCurve Curve;
    public float WaitTime;

    private float LastTime = 0f;
    
    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        float currentTime = (float)playable.GetTime();
        float totalTime = (float)playable.GetDuration();

        if(currentTime >= LastTime + WaitTime || LastTime == 0 || currentTime == totalTime)
        {
            SpriteRenderer spriteRenderer = playerData as SpriteRenderer;
        
            float percentualTime = currentTime/totalTime;
            spriteRenderer.sharedMaterial.SetFloat(shPropIntensity, Curve.Evaluate(percentualTime));

            LastTime = currentTime;
        }
    }
}
