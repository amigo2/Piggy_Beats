using UnityEngine;
using System.Collections;

#pragma warning disable 0168 // variable declared but not used.
#pragma warning disable 0219 // variable assigned but not used.
#pragma warning disable 0414 // private field assigned but not used.
//Remove this for the product version

public class SoundScript : MonoBehaviour {

    public GameObject orangeEffect;
    public GameObject greenEffect;
    public GameObject yellowEffect;
    public GameObject blueEffect;
    public GameObject whiteEffect;
    public GameObject purpleEffect;
    public GameObject redEffect;

    //SOUNDS OF THE NOTES
    //MUSIC NOTES ENGLISH
    //c --> DO --> Black
    //d --> RE --> Green
    //e --> MI --> Yellow
    //f --> FA --> blue
    //g --> SOL --> White
    //a --> LA --> Purple
    //b --> SI --> Red

    public AudioClip c_Audio;
    public AudioClip d_Audio;
    public AudioClip e_Audio;
    public AudioClip f_Audio;
    public AudioClip g_Audio;
    public AudioClip a_Audio;
    public AudioClip b_Audio;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PlaySoundNote(int zPos)
    {
        if (zPos > 6)
        {
            zPos -= 7;
        }

        switch (zPos)
        {
            case 0: //C
                AudioSource.PlayClipAtPoint(c_Audio, Camera.main.transform.position);
                break;
            case 1: //D
                AudioSource.PlayClipAtPoint(d_Audio, Camera.main.transform.position);
                break;
            case 2: //E
                AudioSource.PlayClipAtPoint(e_Audio, Camera.main.transform.position);
                break;
            case 3: //F
                AudioSource.PlayClipAtPoint(f_Audio, Camera.main.transform.position);
                break;
            case 4: //G
                AudioSource.PlayClipAtPoint(g_Audio, Camera.main.transform.position);
                break;
            case 5: //A
                AudioSource.PlayClipAtPoint(a_Audio, Camera.main.transform.position);
                break;
            case 6: //B
                AudioSource.PlayClipAtPoint(b_Audio, Camera.main.transform.position);
                break;

        }
    }

    public void ShowParticle(string tileColorShown, Vector3 tilePosition)
    {
        switch (tileColorShown)
        {
            case "Orange":
                GameObject blackPart = (GameObject)GameObject.Instantiate(orangeEffect, tilePosition, Quaternion.identity);
                break;
            case "Green":
                GameObject greenPart = (GameObject)GameObject.Instantiate(greenEffect, tilePosition, Quaternion.identity);
                break;
            case "Yellow":
                GameObject yellowPart = (GameObject)GameObject.Instantiate(yellowEffect, tilePosition, Quaternion.identity);
                break;
            case "Blue":
                GameObject bluePart = (GameObject)GameObject.Instantiate(blueEffect, tilePosition, Quaternion.identity);
                break;
            case "White":
                GameObject whitePart = (GameObject)GameObject.Instantiate(whiteEffect, tilePosition, Quaternion.identity);
                break;
            case "Purple":
                GameObject purplePart = (GameObject)GameObject.Instantiate(purpleEffect, tilePosition, Quaternion.identity);
                break;
            case "Red":
                GameObject redPart = (GameObject)GameObject.Instantiate(redEffect, tilePosition, Quaternion.identity);
                break;
        }
    }
}
