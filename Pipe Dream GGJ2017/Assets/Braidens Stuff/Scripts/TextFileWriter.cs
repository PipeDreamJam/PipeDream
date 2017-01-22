using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

//this will listen to the song's data, then write to the file, this is given to a single band
public class TextFileWriter : MonoBehaviour {
    string filePath; 
    void Awake()
    {
        filePath = Application.dataPath.ToString();
        string final = string.Concat(filePath, "/Resources/wrong.txt");

        //This will make sure that the file will be empty on level load
        File.WriteAllText(final, string.Empty);

        inputBand = new uint[32000];
        timeStamp = new float[32000];


        for (uint i = 0; i < 32000; i++)
        {
            inputBand[i] = i;
            timeStamp[i] = i;
        }
    }
    //write the 2digit system into the txt file
    //Bands = first digit (2 bands per obstacle type)
    //Amplitude = 2nd digit
   


    // we should get an array that has the info filled from this
    public uint[] inputBand;  //  1st digit
    public float[] timeStamp; // for amp

    //private static int colLength = 0;
    //private static int rowLength = 0;

    
    
    string totalPath;
    string[,] data = new string[1000, 32]; //Total amount of data that we should hold for 1 song

    
    // Use this for initialization
    void Start () {





        totalPath = string.Concat(filePath, "/Resources/wrong.txt");

        for (int i = 0; i < 1000; i++)
        {
            for (int j = 0; j < 32; j++)
            {
                int inde = i * 32 + j;

                data[i, j] = inputBand[inde].ToString() + timeStamp[inde].ToString();

                if (j == 31 && i < 999)
                {
                    data[i,j] += "*" + System.Environment.NewLine;
                }
                else if (j < 31)
                {
                    data[i, j] += ",";
                }


            }
        }



        // System.IO.File.WriteAllText(totalPath, "Hello World!");
        // System.IO.File.WriteAllText("C:\blahblah_yourfilepath\yourtextfile.txt", 
        //"This is text that goes into the text file")
        for (int i = 0; i < 1000; i++)
        {
            for (int j = 0; j < 32; j++)
            {
                System.IO.File.AppendAllText(totalPath, data[i,j].ToString());
                
            }
        }
        

        //change
    }

    // Update is called once per frame
   


    
}


/*
0 - 86 hz [2 samples]
1 - 172 hz (87 - 258)       [4 samples]
2 - 344 hz (259-602)        [8 samples]
3 - 688 hz (603-1290)       [16 samples]
4 - 1376 hz (1291-2666)     [32 samples]
5 - 2752 hz (2667-5418)     [64 samples]
6 - 5504 hz (5419 - 10922)  [128 samples]
7 - 11008 hz (10923 - 21930)    [256 samples]
43 hz per sample
total 22050 hz
512 samples
22050/512 = 43 hz per sample
8 bands
*/
