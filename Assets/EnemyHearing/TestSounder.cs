using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSounder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SoundCor());
    }

    IEnumerator SoundCor()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            GameSoundSystem.MakeSound(transform.position, 4, 4);
        }
    }
}
