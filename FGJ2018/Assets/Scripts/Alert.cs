using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alert : MonoBehaviour
{
    public bool danger;
    public AudioSource alertSound;
    public AudioSource messageCenter;
    public List<string> messages;
    public List<AudioClip> soundLibrary; // 0-9 numbers 10-35 letters , rest messages
    public List<int> SoundList;
    int nextSound;
    
    private int currentSound;
	// Use this for initialization
	void Start ()
    {
       
		
	}

    public void StartAlert(string message, string letter, int number)
    {
        danger = true;
        
        if (messages.Count == 0)
        {
            alertSound.Play();
        }
        Debug.Log("Alert! " + message);
        breakMessage(message, letter, number);

    }

    public void endAlert(string message,string letter,int number)
    {
        messages.Remove(message);
        if (messages.Count == 0)
        {
            danger = false;
            alertSound.Stop();
        }
    }

    void ReadMessages()
    {
        if (messageCenter.isPlaying != true)
        {    
            messageCenter.clip = soundLibrary[SoundList[nextSound]];
            messageCenter.Play();
            nextSound++;

        }
    }

    void breakMessage(string message,string letter,int number)
    {
        int messageID =0;
        int letterID = 0;
       

        switch(message)
        {
            case "Hacker in point":
                messageID = 35 + 1; //36 is first message in soundlist
                break;
        }
        switch (letter)
        {
            case "A":
                messageID = 10;
                break;
            case "B":
                messageID = 11; 
                break;
            case "C":
                messageID = 12; 
                break;
            case "D":
                messageID = 13; 
                break;
            case "E":
                messageID = 14; 
                break;
            case "F":
                messageID = 15; 
                break;
            case "G":
                messageID = 16; 
                break;
            case "H":
                messageID = 17; 
                break;
            case "I":
                messageID = 18; 
                break;
            case "J":
                messageID = 19; 
                break;
            case "K":
                messageID = 20; 
                break;
            case "L":
                messageID = 21; 
                break;
            case "M":
                messageID = 22; 
                break;
            case "N":
                messageID = 23; 
                break;
            case "O":
                messageID = 24; 
                break;
            case "P":
                messageID = 25; 
                break;
            case "Q":
                messageID = 26; 
                break;
            case "R":
                messageID = 27; 
                break;
            case "S":
                messageID = 28; 
                break;
            case "T":
                messageID = 29; 
                break;
            case "U":
                messageID = 30; 
                break;
            case "V":
                messageID = 31; 
                break;
            case "W":
                messageID = 32; 
                break;
            case "X":
                messageID = 33; 
                break;
            case "Y":
                messageID = 34; 
                break;
            case "Z":
                messageID = 35; 
                break;

        }
        
        SoundList.Add(messageID); // example: "hacking detected in sector"
        SoundList.Add(letterID); // letter of sector

        if (number > 9)
        {
            var numberString = number.ToString();
            var numberArray = numberString.ToCharArray();

            for (int i = 0; i < numberArray.Length; i++)
            {
                SoundList.Add((int)numberArray[i]);
            }

        }
        else
        {
            SoundList.Add(number);
        }
        
    }


	// Update is called once per frame
	void Update ()
    {
        if (danger)
        {
            if (messages.Count > 1)
            {
                ReadMessages();
            }

        }
        
		
	}
}
