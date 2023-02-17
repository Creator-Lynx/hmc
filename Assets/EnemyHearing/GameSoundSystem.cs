using UnityEngine;
using UnityEngine.Events;

public class GameSoundSystem : MonoBehaviour
{
    public static SimpleHear[] hearables;
    public static void MakeSound(Vector3 position, int inputLoud, float soundDistance)
    {
        foreach (SimpleHear hearable in hearables)
        {
            float dist = (hearable.GetPosition() - position).magnitude;
            if (dist <= soundDistance)
            {
                int loud = inputLoud * (int)(dist / soundDistance);
                hearable.HearReaction(position, loud);
            }
        }
    }
}
