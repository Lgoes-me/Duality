using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SpriteRendererControlAsset : PlayableAsset
{
    public AnimationCurve Curve;
    public float WaitTime;

    public override Playable CreatePlayable (PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<SpriteRendererControlBehaviour>.Create(graph);

        var materialControlBehaviour = playable.GetBehaviour();
        materialControlBehaviour.Curve = Curve;
        materialControlBehaviour.WaitTime = WaitTime;

        return playable;
    }
}