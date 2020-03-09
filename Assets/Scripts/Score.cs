using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score instance;

    public int actualLevel = 1; 
    public int linesDestroyed = 0;
    public int[] nextLvl;
    public int maxLvl = 10;
    public Text level, lines;
    public float newFallTime = 0.8f;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        nextLvl = new int[maxLvl];
        nextLvl[1] = actualLevel;

        lines.text = linesDestroyed.ToString();
        level.text = actualLevel.ToString();

        for (int i = 1; i < nextLvl.Length; i++)
        {
            //change number beside ; to change exp curve to next levels
            nextLvl[i] = nextLvl[i - 1] + 10;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //test
        if (Input.GetKeyDown(KeyCode.L))
        {
            LinesDestroyed();
        }
    }

    public void LinesDestroyed()
    {
        //linesDestroyed++;
        linesDestroyed += 10;
        lines.text = linesDestroyed.ToString();
        level.text = actualLevel.ToString();

        if (actualLevel < maxLvl)
        {
            if(linesDestroyed > nextLvl[actualLevel] - 1)
            {
                actualLevel++;
                level.text = actualLevel.ToString();
                newFallTime = TetrisBlock.fallTime * 0.5f;
                TetrisBlock.fallTime = newFallTime;
            }
        }
    }
}
