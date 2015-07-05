using UnityEngine;
using System.Collections;

public class Laughing : MonoBehaviour
{

    public AudioClip[] audioClips;

	// Use this for initialization
	void Start () {
        StartCoroutine(Laugh());
	}
	

    public IEnumerator Laugh()
    {
        int clipToPlay = Random.Range(0, audioClips.Length - 1);

        Debug.Log(clipToPlay);

        AudioClip audioClip = audioClips[clipToPlay];

        AudioSource.PlayClipAtPoint(audioClip, transform.position, 1f);

        yield return new WaitForSeconds(5f);


        StartCoroutine(Laugh());

        yield return 0;

    }
}
