using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyReplay : MonoBehaviour {

    private const int bufferFrames = 1000;
    private MyKeyFrame[] keyFrame = new MyKeyFrame[bufferFrames];
    private Rigidbody rigid;
    private GameManager manager;



	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody>();
        manager = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (manager.recording)
        {
            Record();
        }
        else
        {
            PlayBack();
        }

    }

    void PlayBack()
    {
        rigid.isKinematic = true;
        int frame = Time.frameCount % bufferFrames;
        //print("Reading Frame: " + frame);
        transform.position = keyFrame[frame].pos;
        transform.rotation = keyFrame[frame].rot;
    }


    void Record()
    {
        rigid.isKinematic = false;
        int frame = Time.frameCount % bufferFrames;
        float time = Time.time;
        //print("Writting frame: " + frame);
        keyFrame[frame] = new MyKeyFrame(time, transform.position, transform.rotation);
    }
}

/// <summary>
/// Structure for storing time, rotation and position.
/// </summary>
public struct MyKeyFrame { // value type

    public float time;
    public Vector3 pos;
    public Quaternion rot;

    public MyKeyFrame(float time, Vector3 pos, Quaternion rot)
    {
        this.time = time;
        this.pos = pos;
        this.rot = rot;
    }
}