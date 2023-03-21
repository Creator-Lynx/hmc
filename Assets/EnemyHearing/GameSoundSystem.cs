using UnityEngine;
using UnityEngine.Events;

public class GameSoundSystem : MonoBehaviour
{
    public static UnityEvent<Vector3, int, int> hearables = new UnityEvent<Vector3, int, int>();
    public static void MakeSound(Vector3 position, int inputLoud, int soundDistance)
    {
        hearables.Invoke(position, inputLoud, soundDistance);
    }
}
