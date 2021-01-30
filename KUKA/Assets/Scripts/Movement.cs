using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
public class Movement : MonoBehaviour
{

    public GameObject NeckJoint,  HeadJoint, Turn, GripL, GripR;
    private SerialPort sp = new SerialPort("COM5", 9600);
    void Start()
    {
        //Run the code to open the serial port
        OpenSerialPort();
        NeckJoint= GameObject.FindWithTag("Neck");
        HeadJoint = GameObject.FindWithTag("Head");
        Turn = GameObject.FindWithTag("Rotation");
        GripL= GameObject.FindWithTag("GripL");
        GripR= GameObject.FindWithTag("GripR");
    }
    void OpenSerialPort()
    {
        //Open the serial port
        sp.Open();
        sp.ReadTimeout = 1;
    }
    void Motion(string Direction)
    {
        //Check what direction the arduino has passed on
        if (Direction == "One")
        {
            HeadJoint.transform.Rotate(0, 0, 5f);
        }
        if (Direction == "Two")
        {
            HeadJoint.transform.Rotate(0, 0, -5f);
        }
   
        if (Direction == "Three")
        {
           Turn.transform.Rotate(0, -5f, 0);
        }
        if (Direction == "Four")
        {
            Turn.transform.Rotate(0, 5f, 0);
        }
   
        if (Direction == "Six")
        {
            GripL.transform.Rotate(0, 5f, 0);
            GripR.transform.Rotate(0, -5f, 0);
        }
        if (Direction == "Seven")
        {
            GripL.transform.Rotate(0,-5f, 0);
            GripR.transform.Rotate(0, 5f, 0);
        }
  
        //Check what direction the arduino has passed on
        if (Direction == "Eight")
        {
            NeckJoint.transform.Rotate(0, 0, 5f);
        }
        if (Direction == "Nine")
        {
            NeckJoint.transform.Rotate(0, 0, -5f);
        }
    }

    
    void Update()
    {
        if (sp.IsOpen)
        {
            try
            {
                //while the serialport is open move execute the movement function and pass the line that the Arduino is printing
                Motion(sp.ReadLine());
               

            }
            catch (System.Exception)
            {
            }
        }
    }
}
