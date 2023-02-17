using UnityEngine;

public class SimpleHear : IHearable
{
    Enemy _owner;
    int _reactionLoud;
    public SimpleHear(Enemy owner, int reactionLoud)
    {
        _owner = owner;
        _reactionLoud = reactionLoud;
    }
    public void HearReaction(Vector3 soundPosition, int loud)
    {
        if (loud >= _reactionLoud)
        {
            Vector3[] points = { (soundPosition - Vector3.left), soundPosition };
            _owner.patrolable = new NavMeshPatrolPingPongBehavior(_owner.gameObject, points);
        }

    }
    public Vector3 GetPosition() => _owner.transform.position;
}
