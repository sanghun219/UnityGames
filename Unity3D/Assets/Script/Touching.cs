using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Touching 
{
    RaycastHit hit;
    float click_delayTime = 0f;

    public void ClickMe(Action action)
    {
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        click_delayTime += Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                //double click 방지용
                if (click_delayTime >= 0.1)
                {
                    action();
                    click_delayTime = 0;
                }
                

            }   

        }

    }



}
