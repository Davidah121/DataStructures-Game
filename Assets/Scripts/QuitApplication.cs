﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitApplication : MonoBehaviour
{
   public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Application Quit");
    }
}
