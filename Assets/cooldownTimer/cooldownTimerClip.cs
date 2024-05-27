using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class cooldownTimerClip : PlayableAsset, ITimelineClipAsset
{
    public cooldownTimerBehaviour template = new cooldownTimerBehaviour ();

    public ClipCaps clipCaps
    {
        get { return ClipCaps.None; }
    }

    public override Playable CreatePlayable (PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<cooldownTimerBehaviour>.Create (graph, template);
        cooldownTimerBehaviour clone = playable.GetBehaviour ();
        return playable;
    }
}
