using UnityEngine;

public class SlimeBasic : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip slash1;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sword"))
        {
            print("hit");
            audioSource.PlayOneShot(slash1);
        }
            

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
