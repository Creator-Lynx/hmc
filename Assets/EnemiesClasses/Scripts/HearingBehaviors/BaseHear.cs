using UnityEngine;

public class BaseHear : IHearable
{
    protected Enemy _owner;
    protected int _reactionLoud;
    public BaseHear(Enemy owner, int reactionLoud)
    {
        _owner = owner;
        _reactionLoud = reactionLoud;
        GameSoundSystem.hearables.AddListener(HearReaction);
    }
    public virtual void HearReaction(Vector3 soundPosition, int inputLoud, int soundDistance)
    {
        Debug.Log(string.Format("HearReaction of {0}", _owner.gameObject.name));
        float dist = (_owner.transform.position - soundPosition).magnitude;
        int loud = 0;
        if (dist <= soundDistance)
        {
            loud = (int)(inputLoud * ((soundDistance - dist) / soundDistance));
        }
        if (loud >= _reactionLoud)
        {
            Vector3[] points = { (soundPosition + 1.5f * Vector3.right),
                                 (soundPosition + 1.5f * Vector3.down),
                                 (soundPosition + 1.5f * Vector3.left),
                                 (soundPosition + 1.5f * Vector3.up) };
            _owner.patrolable = new NavMeshPatrolLoopBehavior(_owner.gameObject, points, 1.5f);
        }

    }
}
