using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuideBehavior : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float delta = 0.04f;
    private Vector3 basePos;
    GameObject player;
    GameObject CSwitch;
    GameObject ESwitch;
    GameObject GSwitch;
    GameObject EbSwitch;
    GameObject WallofZorpon;

    GameObject CSwitch2;
    GameObject ESwitch2;
    GameObject GSwitch2;

    public bool isSolved1 = false;
    public bool isSolved2 = false;


    
    public bool startInstructions = false;
    public bool ascendInstructions = false;
    public bool descendInstructions = false;
    public bool f3Instructions = false;
    public bool s3Instructions = false;
    public bool win = false;
    public bool l2 = false;
    public bool l2a = false;
    public bool l2win = false;

    public bool bigwin = false;
    public bool vd = false;

    public bool showInv = false;
    public bool hasZorp = false;




    public int index = 0;
    public int maxIndex = 17; 
    public string miniText = "Touch tiles to play notes!";
    public string[] sIA; //start instructions
    public string[] AIA; //ascend instructions
    public string[] F3; //failure instructions at step 3
    public string[] S3; //success instructions at step 3
    public string[] W; //win instructions (level 1)
    public string[] l2I;
    public string[] l2Ia;
    public string[] l2W;
    public string[] BW;
    public string[] V;





    



    public float[] pitches;

    public AudioSource audioSource;
    public AudioClip drop;
    public AudioClip majorChord;
    public AudioClip minorChord;

    public int musicoins = 100;


    


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        drop = this.GetComponent<AudioSource>().clip;

        player = GameObject.Find("Player");
        CSwitch = GameObject.Find("CSwitch");
        ESwitch = GameObject.Find("ESwitch");
        GSwitch = GameObject.Find("GSwitch");
        EbSwitch = GameObject.Find("EbSwitch");
        CSwitch2 = GameObject.Find("CSwitch (1)");
        ESwitch2 = GameObject.Find("ESwitch (1)");
        GSwitch2 = GameObject.Find("GSwitch (1)");

        WallofZorpon = GameObject.Find("LegendaryWallofZorpon");

        this.basePos = player.transform.position + new Vector3(-1.7f, 1.1184f, 0);
        pitches = new float[]  {
            0.84089641525f ,0.943874313f, 1.05946309436f, 1.12246204831f,
            1.25992104989f, 1.41421356237f,
            1.58740105197f, 1.68179283051f
        };

        sIA = new string[] {
             "You are awake I see. (X to continue)",
             "You are awake... (Z to see previous dialogue)",
             "Yes...",
             "This will do...",
             "Welcome.",
             "Welcome to the MusiCave.",
             "Many have fallen here.",
             "Thousands of years ago, my people lived in this cave.",
             "Playing songs...",
             "Building sculptures...",
             "Our people spoke in music, and it was our language.",
            "One day, an ancient prophet predicted a calamity, one that could not be avoided.",
            "Our people hid our treasures and protected them," +
            " so that only the worthy may one day find them and bring music back to the world.",
            "You are worthy.",
            "I will guide you through this cave, and you will unlock the secrets of our language.",
            "Touch the tiles to play notes (Sound on).",
            "Space to Jump, Left and Right to Move.",
            "Press S to Customize your Character.",
            "Press X to Start."
        };
        maxIndex = sIA.Length;


        AIA = new string[] {
             "Ah, what trouble lies ahead... (X to continue)",
             "I see that the two paths ahead diverge...(Z to see previous dialogue)",
             "Let me see if I can remember the ancient wisdom about this path...",
             "Ah yes, I have found it...",
             "The path onward sounds like this:"
        };

        F3 = new string[] {
             "You have gone away from the intended path.",
             "There is nothing for you here.",
             "Go back and try again."
        };
        
        S3 = new string[] {
             "Congratulations, I believe that was the right path.",
             "You are a promising adventurer.",
             "Onward, I see that two paths diverge yet again.",
             "If my ancient wisdom is correct, the next path sounds like this:",
        };

        W = new string[] {
             "Congratulations, I believe that was the right path.",
             "You have unlocked a portal to the next room.",
             "Let us go onward. (Press X)",
        };


        l2I = new string[] {
            "What a curious place we have ended up. (Press X to continue)",
            "It all seems very familiar... (Press Z to go back)",
            "Oh my stars!",
            "Those three round balls!",
            "Those are the legendary spheres of Zorpon!",
            "Legend has it that with the special artifact of Zorpon, you can make these spheres jump.",
            "Let me see if the special artifact is in my pockets...",
            "(Rummages through pockets)",
            "Ah! Here it is.",
            "Here, I put it in your inventory.",
            "(Press I to access your inventory)",
        };


        l2Ia = new string[] {
            "Before you, we see the legendary switches of Zorpon.",
            "Each switch plays a different note.",
            "In order to move onward, we must destroy the legendary wall of Zorpon.",
            "According to the legendary legend of Zorpon, we must play three notes at the same time to destroy the wall.",
            "Legend has it that the three notes will make this sound:"           
        };


        l2W = new string[] {
            "Astounding!",
            "You have solved the legendary puzzle of Zorpon!",
            "Zorpon the legend would be proud that is wall should be bested by a worthy explorer.",
            "Onward now, there is no time to waste. Onward to level n+1!",  
            "Let me see what is beyond the wall of Zorpon...",
            "I see...It appears the next puzzle was made by the Great Dorpon!",
            "Dorpon is Zorpon's brother, and the three notes that he has chosen sound like this:"           
        };

        BW = new string[] {
            "Tremendous!",
            "You have solved the Great puzzle of Dorpon!",
            "This is as far as we can go right now, but I wonder what will lie ahead in the future.",
            "Let us get some rest at the town and share our progress with the villagefolk."         
        };

        V = new string[] {
            "Welcome to my humble abode in the village of Bounceville, my friend!",
            "It's not much, but it's the best we can do!",
            "I see that you have obtained the legendary artifact of Zorpon!",
            "My name is Borpon, and I am the great-great grandchild of Dorpon",
            "Thank you for learning the secret of Dorpon!",
            "You are one step closer to moving to bringing music back to the people.",
            "Only a truly legendary explorer could have solved the puzzle of Dorpon...",
            "You must be my long lost sibling, Morpon!",
            "Anyway, Dorpon's secret was called the MINOR CHORD.",
            "You can rest here for the night."
        };

        startInstructions = true;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 basePos;
        if(startInstructions || ascendInstructions|| descendInstructions || f3Instructions || s3Instructions ||
        win || l2 ||  l2win || bigwin)
        {
             basePos = player.transform.position + new Vector3(-0.7f, 0.9f, -1.0f);
        }
        else {
             basePos = player.transform.position + new Vector3(-1.7f, 1.1184f, 0f);
        }
        Vector3 newPos = basePos;
        newPos.y += delta * Mathf.Sin(Time.time * moveSpeed);
        transform.position = newPos;

        
        if(Input.GetKeyDown(KeyCode.I))
        {
            showInv = !showInv;
        }

        if(Input.GetKeyDown(KeyCode.X))
        {
            if(index >= maxIndex - 1)
            {
                l2 = false;
                vd = false;

                if(ascendInstructions)
                {
                    StartCoroutine(playScaleAscending());
                }
                
                if(s3Instructions)
                {
                    StartCoroutine(playScaleDescending());
                }
                if(win)
                {
                    player.transform.position = new Vector3(-30f, -11.5f, 168.413f - 0.66138f);
                    l2 = true;
                    index = 0;
                    maxIndex = l2I.Length;
                    musicoins += 5;

                }
                if(l2)
                {
                    hasZorp = true;
                }
                if(l2a)
                {
                    playMajorChord();
                }
                 if(l2win)
                {
                    musicoins += 10;
                    playMinorChord();
                }
                if(bigwin)
                {
                    miniText = "Welcome to Bounceville";
                    player.transform.position = new Vector3(-13.18779f, 3.63f, 204.15f - 0.66138f);
                    vd = true;
                    index = 0;
                    maxIndex = V.Length;
                    musicoins += 50;
                }
                if(f3Instructions)
                {
                    musicoins = musicoins - 1;
                }
                startInstructions = false;
                ascendInstructions = false;
                f3Instructions = false;
                s3Instructions = false;
                descendInstructions = false;
                win = false;
                l2a = false;
                l2win = false;
                bigwin =false;

                index = 0;
            }
            else
            {
                index++;
            }
        }
        if(Input.GetKeyDown(KeyCode.Z))
        {
            if(index > 0)
            {           
                index--;
            }
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            l2win = true;
        }
        if(CSwitch.GetComponent<SwitchBehavior>().isPlaying &&
         ESwitch.GetComponent<SwitchBehavior>().isPlaying &&
         GSwitch.GetComponent<SwitchBehavior>().isPlaying)
        {
            //isSolved1 = true;
            Debug.Log("Level 2 Puzzle solved!");

            if (GameObject.Find("LegendaryWallofZorpon") != null)
            {
                Destroy(WallofZorpon);
            }

            startInstructions = false;
            ascendInstructions = false;
            f3Instructions = false;
            s3Instructions = false;
            descendInstructions = false;
            win = false;
            l2a = false;
            l2 = false;  
            bigwin = false;

            l2win  = true;
            maxIndex = 7;
            index = 0;
            miniText = "Dorpon's puzzle. Press D to hear the spirit's dialogue again.";
        }
        if(CSwitch2.GetComponent<SwitchBehavior>().isPlaying &&
         GSwitch2.GetComponent<SwitchBehavior>().isPlaying &&
         EbSwitch.GetComponent<SwitchBehavior>().isPlaying)
        {
            //Debug.Log("Level 3 Puzzle solved!");
            startInstructions = false;
            ascendInstructions = false;
            f3Instructions = false;
            s3Instructions = false;
            descendInstructions = false;
            win = false;
            l2a = false;
            l2 = false;  
            bigwin = true;

            l2win  = false;
            maxIndex = 4;
            index = 0;
        }

    }


    void OnGUI()
    {

        GUI.skin.box.wordWrap = true;
    
        var miniTextStyle = GUI.skin.GetStyle("Box");
        miniTextStyle.alignment = TextAnchor.MiddleCenter;
        miniTextStyle.fontSize = 25;

        var diagStyle = GUI.skin.GetStyle("Box");
        diagStyle.alignment = TextAnchor.MiddleCenter;

        var invStyle = GUI.skin.GetStyle("Box");

        var buttonStyle = GUI.skin.GetStyle("Button");
        buttonStyle.fontSize = 30;



        GUI.Box(new Rect(20, 20, 450, 100), miniText, miniTextStyle);

        Rect diag = new Rect(Screen.width/2 - 250, Screen.height/2 - 250, 500, 500);
        

        GUI.Box(new Rect(20, 205, 450, 75), "MusiCoins = " + musicoins);

        if (GUI.Button(new Rect(20, 125, 450, 75), "Click to Restart Game"))
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1.0f;
        }
        if (startInstructions)
        {
            diagStyle.fontSize = 45;
            diagStyle.alignment = TextAnchor.MiddleCenter;


            GUI.Box(diag, sIA[index], diagStyle);
        }
        if (ascendInstructions)
        {
            diagStyle.fontSize = 45;
            diagStyle.alignment = TextAnchor.MiddleCenter;

            GUI.Box(diag, AIA[index], diagStyle);
        }
        if(f3Instructions)
        {
            diagStyle.fontSize = 45;
            diagStyle.alignment = TextAnchor.MiddleCenter;

            GUI.Box(diag, F3[index], diagStyle);
        }
        if(s3Instructions)
        {
            diagStyle.fontSize = 45;
            diagStyle.alignment = TextAnchor.MiddleCenter;

            GUI.Box(diag, S3[index], diagStyle);
        }
        if(s3Instructions)
        {
            diagStyle.fontSize = 45;
            diagStyle.alignment = TextAnchor.MiddleCenter;

            GUI.Box(diag, S3[index], diagStyle);
        }
        if(win)
        {
            diagStyle.fontSize = 45;
            diagStyle.alignment = TextAnchor.MiddleCenter;

            GUI.Box(diag, W[index], diagStyle);
        }
        if(l2)
        {
            diagStyle.fontSize = 45;
            diagStyle.alignment = TextAnchor.MiddleCenter;

            GUI.Box(diag, l2I[index], diagStyle);
        }
        if(l2a)
        {
            diagStyle.fontSize = 45;
            diagStyle.alignment = TextAnchor.MiddleCenter;

            GUI.Box(diag, l2Ia[index], diagStyle);
        }
        if(l2win)
        {
            diagStyle.fontSize = 45;
            diagStyle.alignment = TextAnchor.MiddleCenter;

            GUI.Box(diag, l2W[index], diagStyle);
        }
        if(bigwin)
        {
            diagStyle.fontSize = 45;
            diagStyle.alignment = TextAnchor.MiddleCenter;

            GUI.Box(diag, BW[index], diagStyle);

        }
        if(vd)
        {
            diagStyle.fontSize = 45;
            diagStyle.alignment = TextAnchor.MiddleCenter;

            GUI.Box(diag, V[index], diagStyle);
        }
        if(showInv)
        {
            invStyle.fontSize = 35;
            invStyle.alignment = TextAnchor.UpperCenter;

            GUI.Box(new Rect(Screen.width/2 + 10, Screen.height/2 - 250, 250, 500), "Badges:", invStyle);
            if(hasZorp)
            {
                GUI.Box(new Rect(Screen.width/2 - 250, Screen.height/2 - 250, 250, 500), "Items:\n\n Legendary Artifact of Zorpon (Press C to use)", invStyle);
                
            }
            else
            {
                GUI.Box(new Rect(Screen.width/2 - 250, Screen.height/2 - 250, 250, 500), "Items:", invStyle);

            }

        }




    }

    IEnumerator playScaleAscending()
    {
        //yield return null;
        for (int i = 0; i < 8; i++)
        {
            audioSource.pitch = pitches[i];
            audioSource.Play();
            yield return new WaitForSeconds(0.5f);
        }
    }
    IEnumerator playScaleDescending()
    {
        for (int i = 7; i >= 0; i--)
        {
            audioSource.pitch = pitches[i];
            audioSource.Play();
            yield return new WaitForSeconds(0.5f);
        }
    }


    void playMajorChord()
    {
        audioSource.pitch = 1;
        audioSource.PlayOneShot(majorChord);
    }
    void playMinorChord()
    {
        audioSource.pitch = 1;
        audioSource.PlayOneShot(minorChord);
    }
}
