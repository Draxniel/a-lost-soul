using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulControl : MonoBehaviour
{

    public GameObject door;
    public AudioClip soulSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SoundController.assignSound(soulSound);
        SoundController.setVolume(1.3f);
        SoundController.playSound();
        door.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    //Aqui dentro debe ir la llamada para que aparezca el final del nivel

}
