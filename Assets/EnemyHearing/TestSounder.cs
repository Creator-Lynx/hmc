using System.Net.NetworkInformation;
using UnityEngine;

public class Sounder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameSoundSystem.MakeSound(transform.position, 4, 4);
    }


}
