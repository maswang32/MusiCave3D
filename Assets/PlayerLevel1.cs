using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel1 : MonoBehaviour
{

    public Dictionary<string, float> pitches;
    public float jumpVelocity = 4.5f;
    public float moveSpeed = 2f;
    
    public GameObject guide; 

    private float lrInput;
    private Rigidbody _rb;

    public AudioClip drop; 
    public AudioClip fail;

    public bool hasTouchedSwitch = false;


    // Start is called before the first frame update
    void Start()
    {
        guide = GameObject.Find("Guide");
        _rb = GetComponent<Rigidbody>();
        pitches = new Dictionary<string, float>();
        pitches.Add("CCollider", 0.84089641525f);
        pitches.Add("DCollider",0.943874313f);
        pitches.Add("EbCollider", 1);
        pitches.Add("ECollider", 1.05946309436f);
        pitches.Add("FCollider", 1.12246204831f);
        pitches.Add("FsCollider", 1.189207115f);
        pitches.Add("GCollider", 1.25992104989f);
        pitches.Add("GsCollider", 1.33483985417f);
        pitches.Add("ACollider", 1.41421356237f);
        pitches.Add("AsCollider", 1.49830707688f);
        pitches.Add("BCollider", 1.58740105197f);
        pitches.Add("ChCollider", 1.68179283051f);
    }

    void Update()
    {
        lrInput = Input.GetAxis("Horizontal") * moveSpeed;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
        }


        if (Input.GetKeyDown(KeyCode.S))
        {
            GameObject cylinder = transform.Find("GameObject/Cylinder").gameObject;
            GameObject sphere = transform.Find("GameObject/Sphere").gameObject;
            
            cylinder.GetComponent<Renderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f,1f), Random.Range(0f,1f));
            sphere.GetComponent<Renderer>().material.color = new Color(Random.Range(0f, 1f),Random.Range(0f,1f),Random.Range(0f,1f));

        }
    }
    void FixedUpdate()
    {
        _rb.MovePosition(this.transform.position + this.transform.right * lrInput * Time.fixedDeltaTime);
    }

    void OnCollisionEnter(Collision collision)  //Plays Sound Whenever collision detected
     {
        string othername = collision.gameObject.name;
        if(pitches.ContainsKey(othername))
        {
            GetComponent<AudioSource>().pitch = pitches[othername];
            GetComponent<AudioSource>().Play();
            //Activate Halo
            GameObject other = collision.transform.parent.gameObject;
            Behaviour h = (Behaviour) other.GetComponent("Halo");
            h.enabled = true;
            StartCoroutine(TurnOffHalo(other));
        }
        if(othername == "Instruction2")
        {
            //activate second 
            setAllFalse();
            guide.GetComponent<GuideBehavior>().ascendInstructions = true;
            guide.GetComponent<GuideBehavior>().maxIndex = 5;
            guide.GetComponent<GuideBehavior>().index = 0;
            guide.GetComponent<GuideBehavior>().miniText = "Touch the tile again to see instructions again";
        }
        if(othername == "Instruction3Fail")
        {
            setAllFalse();
            //activate failure instructions
            guide.GetComponent<GuideBehavior>().f3Instructions = true;
            guide.GetComponent<GuideBehavior>().maxIndex = 3;
            guide.GetComponent<GuideBehavior>().index = 0;
            guide.GetComponent<GuideBehavior>().miniText = "Go back and Try again";
            GetComponent<AudioSource>().PlayOneShot(fail);
        }
        if(othername == "Instruction3Success")
        {
            setAllFalse();
            guide.GetComponent<GuideBehavior>().s3Instructions = true;
            guide.GetComponent<GuideBehavior>().maxIndex = 4;
            guide.GetComponent<GuideBehavior>().index = 0;
            guide.GetComponent<GuideBehavior>().miniText = "Touch the tile again to see instructions again";

        }
        if(othername == "Win")
        {
            setAllFalse();
            guide.GetComponent<GuideBehavior>().win = true;
            guide.GetComponent<GuideBehavior>().maxIndex = 3;
            guide.GetComponent<GuideBehavior>().index = 0;
            guide.GetComponent<GuideBehavior>().miniText = "Congratulations!";

        }
        if((!hasTouchedSwitch)&&((othername == "CSwitch" )||(othername == "DSwitch" )||(othername == "ESwitch" )||
        (othername == "FSwitch" )||(othername == "GSwitch" )))
        {
            setAllFalse();
            guide.GetComponent<GuideBehavior>().l2a = true;
            guide.GetComponent<GuideBehavior>().maxIndex = 5;
            guide.GetComponent<GuideBehavior>().index = 0;
            guide.GetComponent<GuideBehavior>().miniText = "Push the weights onto the blocks to play notes. I to access inventory.";
            hasTouchedSwitch = true;
        }
     }

     IEnumerator TurnOffHalo(GameObject other)
     {
        yield return new WaitForSeconds(1.0f);
        Behaviour h = (Behaviour) other.GetComponent("Halo");
        h.enabled = false;
     }
     void setAllFalse()
     {
        guide.GetComponent<GuideBehavior>().startInstructions = false;
        guide.GetComponent<GuideBehavior>().ascendInstructions = false;
        guide.GetComponent<GuideBehavior>().f3Instructions = false;
        guide.GetComponent<GuideBehavior>().s3Instructions = false;
        guide.GetComponent<GuideBehavior>().descendInstructions = false;
        guide.GetComponent<GuideBehavior>().win = false;
        guide.GetComponent<GuideBehavior>().l2a = false;
        guide.GetComponent<GuideBehavior>().l2 = false;  
        guide.GetComponent<GuideBehavior>().l2win = false;
        guide.GetComponent<GuideBehavior>().bigwin = false;
        guide.GetComponent<GuideBehavior>().vd = false;
     }
}
