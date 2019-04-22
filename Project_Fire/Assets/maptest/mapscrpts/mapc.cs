using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Exit
{
    Up,
    Down,
    Left,
    Right
}
public struct Modledetil
{
    public GameObject modle;
    public int upexit;
    public int downexit;
    public int leftexit;
    public int rightexit;
    public int width;
    public int length;
}


public class mapc : UnityEngine.MonoBehaviour
{
    public int length;
    public int width;
    public GameObject wall;
    public GameObject ground;
    public GameObject modle;
    public int exitsnum;
    public int Mapcomplexity;
    List<Exit> exits;
    // Start is called before the first frame update
    void Start()
    {
        exitsnum = 4;
        //Fcreatwall();
        Modledetil start = Fcreatmod(Random.Range(10, 50), Random.Range(10, 50), Random.Range(4, 4));

        Fcreatmod(Random.Range(10, 50), Random.Range(10, 50), Random.Range(4, 4));
        Fcreatmod(Random.Range(10, 50), Random.Range(10, 50), Random.Range(4, 4));
        Fcreatmod(Random.Range(10, 50), Random.Range(10, 50), Random.Range(4, 4));
        Fcreatmod(Random.Range(10, 50), Random.Range(10, 50), Random.Range(4, 4));

        Fcreatmod(Random.Range(10, 50), Random.Range(10, 50), Random.Range(4, 4));
        Fcreatmod(Random.Range(10, 50), Random.Range(10, 50), Random.Range(4, 4));
        Fcreatmod(Random.Range(10, 50), Random.Range(10, 50), Random.Range(4, 4));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void creat()
    {
        int nowcom = 0;
        for(int i=0; i<Mapcomplexity; i+=nowcom)
        {
            Modledetil now = Fcreatmod(Random.Range(10, 50), Random.Range(10, 50), Random.Range(1, 4));
        }
    }
    void Fcreatwall()
    {
        GameObject wall_width =  Instantiate(wall, new Vector3(0, 1, 0), Quaternion.Euler(Vector3.zero));
        GameObject wall_length = Instantiate(wall);
        GameObject wall_width1 = Instantiate(wall,new Vector3(length,0,0),Quaternion.Euler(Vector3.zero));
        GameObject wall_length1 = Instantiate(wall, new Vector3(1, width, 0), Quaternion.Euler(Vector3.zero));
        
        wall_length.transform.localScale = new Vector3(length, wall_length.transform.localScale.y, wall_length.transform.localScale.z);
        wall_width.transform.localScale = new Vector3(wall_width.transform.localScale.x,width , wall_width.transform.localScale.z);

        wall_length1.transform.localScale = new Vector3(length, wall_length1.transform.localScale.y, wall_length1.transform.localScale.z);
        wall_width1.transform.localScale = new Vector3(wall_width1.transform.localScale.x, width, wall_width1.transform.localScale.z);
    }
    Modledetil Fcreatmod(int modwhith, int modlength, int exitnum ,Exit zhiding)
    {
        Modledetil thismod;
        thismod.width = modwhith;
        thismod.length = modlength;
        GameObject map_mod = Instantiate(modle);
        thismod.modle = map_mod;
        GameObject wall1 = Instantiate(wall, Vector3.zero, Quaternion.Euler(Vector3.zero));
        wall1.transform.localScale = new Vector3(modlength, 1, 1);
        wall1.transform.SetParent(map_mod.transform);
        GameObject wall2 = Instantiate(wall, new Vector3(0, 1, 0), Quaternion.Euler(Vector3.zero));
        wall2.transform.localScale = new Vector3(1, modwhith, 1);
        wall2.transform.SetParent(map_mod.transform);
        GameObject wall3 = Instantiate(wall, new Vector3(modlength, 0, 0), Quaternion.Euler(Vector3.zero));
        wall3.transform.localScale = new Vector3(1, modwhith, 1);
        wall3.transform.SetParent(map_mod.transform);
        GameObject wall4 = Instantiate(wall, new Vector3(1, modwhith, 0), Quaternion.Euler(Vector3.zero));
        wall4.transform.localScale = new Vector3(modlength, 1, 1);
        wall4.transform.SetParent(map_mod.transform);
        thismod.upexit = -1;
        thismod.downexit = -1;
        thismod.leftexit = -1;
        thismod.rightexit = -1;

        exits = Frandom(exitnum ,zhiding);

        for (int i = 0; i < exits.Count; i++)
        {
            switch (exits[i])
            {
                case Exit.Down:
                    {

                        Destroy(wall1);
                        int exit = Random.Range(0, modlength - 3);
                        GameObject wall_down1 = Instantiate(wall, Vector3.zero, Quaternion.Euler(Vector3.zero));
                        wall_down1.transform.localScale = new Vector3(exit, 1, 1);
                        wall_down1.transform.SetParent(map_mod.transform);
                        GameObject wall_down2 = Instantiate(wall, new Vector3(exit + 3, 0, 0), Quaternion.Euler(Vector3.zero));
                        wall_down2.transform.localScale = new Vector3(modlength - 3 - exit, 1, 1);
                        wall_down2.transform.SetParent(map_mod.transform);
                        thismod.downexit = exit;
                    }
                    break;
                case Exit.Left:
                    {
                        Destroy(wall2);
                        int exit = Random.Range(0, modwhith - 3);
                        GameObject wall_down1 = Instantiate(wall, new Vector3(0, 1, 0), Quaternion.Euler(Vector3.zero));
                        wall_down1.transform.localScale = new Vector3(1, exit, 1);
                        wall_down1.transform.SetParent(map_mod.transform);
                        GameObject wall_down2 = Instantiate(wall, new Vector3(0, exit + 4, 0), Quaternion.Euler(Vector3.zero));
                        wall_down2.transform.localScale = new Vector3(1, modwhith - 3 - exit, 1);
                        wall_down2.transform.SetParent(map_mod.transform);
                        thismod.leftexit = exit;
                    }
                    break;
                case Exit.Right:
                    {
                        Destroy(wall3);
                        int exit = Random.Range(0, modwhith - 3);
                        GameObject wall_down1 = Instantiate(wall, new Vector3(modlength, 0, 0), Quaternion.Euler(Vector3.zero));
                        wall_down1.transform.localScale = new Vector3(1, exit, 1);
                        wall_down1.transform.SetParent(map_mod.transform);
                        GameObject wall_down2 = Instantiate(wall, new Vector3(modlength, exit + 3, 0), Quaternion.Euler(Vector3.zero));
                        wall_down2.transform.localScale = new Vector3(1, modwhith - 3 - exit, 1);
                        wall_down2.transform.SetParent(map_mod.transform);
                        thismod.rightexit = exit;
                    }
                    break;
                case Exit.Up:
                    {
                        Destroy(wall4);
                        int exit = Random.Range(0, modlength - 3);
                        GameObject wall_down1 = Instantiate(wall, new Vector3(1, modwhith, 0), Quaternion.Euler(Vector3.zero));
                        wall_down1.transform.localScale = new Vector3(exit, 1, 1);
                        wall_down1.transform.SetParent(map_mod.transform);
                        GameObject wall_down2 = Instantiate(wall, new Vector3(exit + 4, modwhith, 0), Quaternion.Euler(Vector3.zero));
                        wall_down2.transform.localScale = new Vector3(modlength - 3 - exit, 1, 1);
                        wall_down2.transform.SetParent(map_mod.transform);
                        thismod.upexit = exit;
                    }
                    break;
            }
        }

        return thismod;

    }

    Modledetil Fcreatmod(int modwhith,int modlength,int exitnum)
    {
        Modledetil thismod;
        thismod.width = modwhith;
        thismod.length = modlength;
        GameObject map_mod = Instantiate(modle);
        thismod.modle = map_mod;
        GameObject wall1 = Instantiate(wall, Vector3.zero, Quaternion.Euler(Vector3.zero));
        wall1.transform.localScale = new Vector3(modlength, 1, 1);
        wall1.transform.SetParent(map_mod.transform);
        GameObject wall2 = Instantiate(wall, new Vector3(0, 1, 0), Quaternion.Euler(Vector3.zero));
        wall2.transform.localScale = new Vector3(1, modwhith, 1);
        wall2.transform.SetParent(map_mod.transform);
        GameObject wall3 = Instantiate(wall, new Vector3(modlength, 0, 0), Quaternion.Euler(Vector3.zero));
        wall3.transform.localScale = new Vector3(1, modwhith, 1);
        wall3.transform.SetParent(map_mod.transform);
        GameObject wall4 = Instantiate(wall, new Vector3(1, modwhith, 0), Quaternion.Euler(Vector3.zero));
        wall4.transform.localScale = new Vector3(modlength, 1, 1);
        wall4.transform.SetParent(map_mod.transform);
        thismod.upexit = -1;
        thismod.downexit = -1;
        thismod.leftexit = -1;
        thismod.rightexit = -1;

        exits = Frandom(exitnum);

        for (int i=0;i<exitnum;i++)
        {
            switch(exits[i])
            {
                case Exit.Down:
                    {
                        
                        Destroy(wall1);
                        int exit = Random.Range(0, modlength - 3);
                        GameObject wall_down1 = Instantiate(wall, Vector3.zero, Quaternion.Euler(Vector3.zero));
                        wall_down1.transform.localScale = new Vector3(exit, 1, 1);
                        wall_down1.transform.SetParent(map_mod.transform);
                        GameObject wall_down2 = Instantiate(wall, new Vector3(exit+3,0,0), Quaternion.Euler(Vector3.zero));
                        wall_down2.transform.localScale = new Vector3(modlength -3-exit, 1, 1);
                        wall_down2.transform.SetParent(map_mod.transform);
                        thismod.downexit = exit;
                    }
                    break;
                case Exit.Left:
                    {
                        Destroy(wall2);
                        int exit = Random.Range(0, modwhith - 3);
                        GameObject wall_down1 = Instantiate(wall, new Vector3(0,1,0), Quaternion.Euler(Vector3.zero));
                        wall_down1.transform.localScale = new Vector3(1, exit, 1);
                        wall_down1.transform.SetParent(map_mod.transform);
                        GameObject wall_down2 = Instantiate(wall, new Vector3(0, exit + 4, 0), Quaternion.Euler(Vector3.zero));
                        wall_down2.transform.localScale = new Vector3(1, modwhith - 3 - exit, 1);
                        wall_down2.transform.SetParent(map_mod.transform);
                        thismod.leftexit = exit;
                    }
                    break;
                case Exit.Right:
                    {
                        Destroy(wall3);
                        int exit = Random.Range(0, modwhith - 3);
                        GameObject wall_down1 = Instantiate(wall, new Vector3(modlength, 0, 0), Quaternion.Euler(Vector3.zero));
                        wall_down1.transform.localScale = new Vector3(1, exit, 1);
                        wall_down1.transform.SetParent(map_mod.transform); 
                        GameObject wall_down2 = Instantiate(wall, new Vector3(modlength, exit + 3, 0), Quaternion.Euler(Vector3.zero));
                        wall_down2.transform.localScale = new Vector3(1, modwhith - 3 - exit, 1);
                        wall_down2.transform.SetParent(map_mod.transform);
                        thismod.rightexit = exit;
                    }
                    break;
                case Exit.Up:
                    {
                        Destroy(wall4);
                        int exit = Random.Range(0, modlength - 3);
                        GameObject wall_down1 = Instantiate(wall, new Vector3(1,modwhith,0), Quaternion.Euler(Vector3.zero));
                        wall_down1.transform.localScale = new Vector3(exit, 1, 1);
                        wall_down1.transform.SetParent(map_mod.transform);
                        GameObject wall_down2 = Instantiate(wall, new Vector3(exit + 4, modwhith, 0), Quaternion.Euler(Vector3.zero));
                        wall_down2.transform.localScale = new Vector3(modlength - 3 - exit, 1, 1);
                        wall_down2.transform.SetParent(map_mod.transform);
                        thismod.upexit = exit;
                    }
                    break;
            }
        }

        return thismod;

    }
    
    List<Exit> Frandom(int exitnum)
    {
        int a;
        List<Exit> exits = new List<Exit>();
        List<int> ex= new List<int>(new int[4] { 0,1,2,3});

        for (int i=0;i<exitnum;i++)
        {
            a= Random.Range(0, 4-i);

            exits.Add((Exit)ex[a]);

       
            ex.RemoveAt(a);
          
        }


        return exits;

    }


    List<Exit> Frandom(int exitnum, Exit zhiding)
    {
        int a;
        bool b = false;
        List<Exit> exits = new List<Exit>();
        List<int> ex = new List<int>(new int[4] { 0, 1, 2, 3 });

        for (int i = 0; i < exitnum; i++)
        {
            a = Random.Range(0, 4 - i);

            exits.Add((Exit)ex[a]);
            if((Exit)ex[a]==zhiding)
            {
           
                b = true;
            }

            ex.RemoveAt(a);

        }
       
        if(!b)
        {
        
            exits.Add(zhiding);
        }
      
        

        return exits;

    }
}
