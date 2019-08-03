using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatController : MonoBehaviour
{
    [SerializeField] float beatTime = 1f;
    float beatCoutdown;
    [SerializeField] FieldController field;
    [SerializeField] AudioClip beat;
    AudioSource audioSource;
    [SerializeField] PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (beatCoutdown > 0)
        {
            beatCoutdown -= Time.deltaTime;
        }
        else
        {
            beatCoutdown = beatTime;
            player.CallAction();
            field.NextBeatField();
            audioSource.PlayOneShot(beat);
        }
    }
}
