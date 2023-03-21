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
        float dist = (_owner.transform.position - soundPosition).magnitude;
        int loud = 0;
        if (dist <= soundDistance)
        {
            loud = inputLoud * (int)(dist / soundDistance);
        }
        if (loud >= _reactionLoud)
        {
            Vector3[] points = { (soundPosition + Vector3.right), soundPosition };
            _owner.patrolable = new NavMeshPatrolPingPongBehavior(_owner.gameObject, points);
        }

    }
}
