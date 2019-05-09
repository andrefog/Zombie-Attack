using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour {
    public AudioClip ShellFallingSound;
    public AudioClip GunShotSound;
    public AudioClip ZombieSound;

    public static AudioSource aSource;
    private static AudioClip shellFallingSound;
    private static AudioClip gunShotSound;
    private static AudioClip zombieSound;

    void Awake () {
        aSource = GetComponent<AudioSource>();
        shellFallingSound = ShellFallingSound;
        gunShotSound = GunShotSound;
        zombieSound = ZombieSound;
	}

    public static void playShellFallingDown()
    {
        aSource.PlayOneShot(shellFallingSound);
    }

    public static void playGunShot()
    {
        aSource.PlayOneShot(gunShotSound);
    }

    public static void playZombie()
    {
        aSource.PlayOneShot(zombieSound);
    }

    public static void playPlayerHurt()
    {

    }
}
