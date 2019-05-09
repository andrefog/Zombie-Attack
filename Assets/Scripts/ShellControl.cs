using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellControl : MonoBehaviour
{
    public AudioClip ShellSound;

    public float ShellSpeed = 10;
    private float timeCounter;
    private Rigidbody rbShell;

    // Start is called before the first frame update
    void Start()
    {
        rbShell = GetComponent<Rigidbody>();
        AudioControl.playShellFallingDown();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timeCounter < 0.1)
        {
            rbShell.MovePosition(rbShell.position + 
                                   transform.forward * ShellSpeed * Time.deltaTime);
        }

        timeCounter += Time.deltaTime;

        if( timeCounter > 5)
        {
            Destroy(this.gameObject);
        }
    }
}
