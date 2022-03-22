using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.Tilemaps;

public class TilemapRendererControlBehaviour : PlayableBehaviour
{
    protected static readonly int shPropIntensity = Shader.PropertyToID("_GradientAdjustment");
    private MaterialPropertyBlock materialPropertyBlock;

    public MaterialPropertyBlock MaterialPropertyBlock 
    { 
        get
        {
            if(materialPropertyBlock == null)
                materialPropertyBlock = new MaterialPropertyBlock();
            
            return materialPropertyBlock;
        } 
    }
    
    public AnimationCurve Curve;
    public float WaitTime;

    private float LastTime = 0f;

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {

        float currentTime = (float)playable.GetTime();
        float totalTime = (float)playable.GetDuration();

        if(currentTime >= LastTime + WaitTime || LastTime == 0 || currentTime == totalTime)
        {
            TilemapRenderer TilemapRenderer = playerData as TilemapRenderer;

            float percentualTime = currentTime/totalTime;
            
            MaterialPropertyBlock.SetFloat(shPropIntensity, Curve.Evaluate(percentualTime));
            TilemapRenderer.SetPropertyBlock(MaterialPropertyBlock);

            LastTime = currentTime;
        }
    }
}
