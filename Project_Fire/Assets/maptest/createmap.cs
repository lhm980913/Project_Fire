﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Threading;

class Directions
{
    public static Vector2 none = new Vector2(0, 0);
    public static Vector2 up = new Vector2(0, 1);
    public static Vector2 down = new Vector2(0, -1);
    public static Vector2 left = new Vector2(-1, 0);
    public static Vector2 right = new Vector2(1, 0);

    public static Vector2[] all = { up, down, left, right };

}

class ninecube
{
    public static Vector2 one = new Vector2(-1, 1);
    public static Vector2 two = new Vector2(0, 1);
    public static Vector2 three = new Vector2(1, 1);
    public static Vector2 four = new Vector2(-1, 0);
    public static Vector2 five = new Vector2(0, 0);
    public static Vector2 six = new Vector2(1, 0);
    public static Vector2 seven = new Vector2(-1, -1);
    public static Vector2 eight = new Vector2(0, -1);
    public static Vector2 nine = new Vector2(1, -1);


    public static Vector2[] all = { one,two,three,four,five,six,seven,eight,nine };

}




enum Tiles
{
    Wall,
    Floor,
    Connect,
    Door,
    Tianchong
}

//确保地图的长宽是奇数
public class createmap : MonoBehaviour
{
    //尝试生成房间的数量
    public int numRoomTries = 50;
    //在已经连接的房间和走廊中再次连接的机会，使得地牢不完美
    public int extraConnectorChance;
    //控制生成房间的大小
    public int roomExtraSize = 0;
    public int roomMinSize = 0;
    //控制迷宫的曲折程度
    public int windingPercent = 0;
    public int scale;

    public int width;
    public int height;
    public GameObject wall, floor, connect,door,dead;

    private Transform mapParent;
    //生成的有效房间
    private List<Rect> rooms;
    //正被雕刻的区域的索引。(每个房间一个索引，每个不连通的迷宫一个索引，在连通之前)
    private int currentRegion = 0;
    //原文https://github.com/munificent/piecemeal Array2D
    //改成int[,]
    private int[,] _regions;
    private Tiles[,] map;

    Tiles[,] map1;
    
    void Start()
    {
        //int a = width;
        //width = height;
        //height = a;

        rooms = new List<Rect>();
        map = new Tiles[width, height];
        map1 = new Tiles[width + 4, height + 4];
        _regions = new int[width, height];
        mapParent = GameObject.FindGameObjectWithTag("mapParent").transform;
        Generate();
        mapParent.transform.localScale = Vector3.one * scale;
        
    }

    void Update()
    {
      


        if (Input.GetKeyDown(KeyCode.Q))
        {
            //Collider[] a = mapParent.GetComponentsInChildren<Collider>();
            //for (int i = 0; i < a.Length; i++)
            //{
            //    Destroy(a[i].gameObject);
            //}
            //rooms = new List<Rect>();
            //map = new Tiles[width, height];
            //_regions = new int[width, height];
            //mapParent = GameObject.FindGameObjectWithTag("mapParent").transform;
            Generate();
        }
    }

    public void Generate()
    {
       
        if (width % 2 == 0 || height % 2 == 0)
        {
            Debug.Log("地图长宽不能为偶数");
            return;
        }
        InitMap();
        AddRooms();
        FillMaze();
        ConnectRegions();
        RemoveDeadEnds();
        InstanceMap();
    }


    /*
     *生成房间
     *1.随机房间（随机大小，奇数）
     *2.查看是否重叠，否则加入房间数组
     */
    private void AddRooms()
    {
        for (int i = 0; i < numRoomTries; i++)
        {
            //确保房间长宽为奇数
            int size = Random.Range(roomMinSize, roomExtraSize) * 2 + 1;
            int rectangularity = Random.Range(0, 1 + size / 2) * 2;

            //int size1 = Random.Range(roomMinSize, roomExtraSize) * 2 + 1;
            int w = size, h = size;
            if (0 == Random.Range(0, 1))
            {
                w += rectangularity;
            }
            else
            {
                h += rectangularity;
            }
            int x = Random.Range(0, (width - w) / 2) * 2 + 1;
            int y = Random.Range(0, (height - h) / 2) * 2 + 1;
            //print(x+"  "+y);
            Rect room = new Rect(x, y, w, h);
            //判断房间是否和已存在的重叠
            bool overlaps = false;
            foreach (Rect r in rooms)
            {
                if (room.Overlaps(r))
                {
                    overlaps = true;
                    break;
                }
            }
            //如果重叠，抛弃该房间
            if (overlaps)
                continue;
            //如果不重叠，把房间放入rooms中
            rooms.Add(room);
            //设置新房间索引
            StartRegion();


            //修改部分，导入模板房间，获取房间方格属性
            for (int j = x; j < x + w; j++)
            {
                for (int k = y; k < y + h; k++)
                {
                    Carve(new Vector2(j, k));
                }
            }
        }
    }

    /*
     * 填充迷宫(洪水填充)
     * 
     */
    private void FillMaze()
    {
        //0处为墙
        for (int x = 1; x < width; x += 2)
        {
            for (int y = 1; y < height; y += 2)
            {
                Vector2 pos = new Vector2(x, y);
                //if (map [pos] == Tiles.Wall) {
                if (map[x, y] == Tiles.Wall)
                {
                    GrowMaze(pos);
                }
            }
        }
    }

    /*
     * 生成迷宫
     */
    private void GrowMaze(Vector2 start)
    {
        List<Vector2> cells = new List<Vector2>();
        Vector2 lastDir = Directions.none;
        StartRegion();
        //cells添加之前需要变成Floor
        Carve(start);
        cells.Add(start);
        while (cells != null && cells.Count != 0)
        {
            Vector2 cell = cells[cells.Count - 1];
            //可以扩展的方向的集合
            List<Vector2> unmadeCells = new List<Vector2>();
            //加入能扩展迷宫的方向
            foreach (Vector2 dir in Directions.all)
            {
                if (CanCarve(cell, dir))
                {
                    unmadeCells.Add(dir);
                }
            }
            if (unmadeCells != null && unmadeCells.Count != 0)
            {
                Vector2 dir;
                //得到扩展方向 windingPercent用来控制是否为原方向
                if (unmadeCells.Contains(lastDir) && Random.Range(0, 100) > windingPercent)
                {
                    dir = lastDir;
                }
                else
                {
                    dir = unmadeCells[Random.Range(0, unmadeCells.Count - 1)];
                }

                Carve(cell + dir);
                Carve(cell + dir * 2);
                //添加第二个单元
                cells.Add(cell + dir * 2);
                lastDir = dir;
            }
            else
            {
                //没有相邻可以雕刻的单元，就删除
                cells.Remove(cells[cells.Count - 1]);
                //置空路径
                lastDir = Directions.none;
            }

        }
    }

    /*
     * 连通房间和迷宫
     */
    private void ConnectRegions()
    {
        //找到区域所有可连接的空间墙wall
        Dictionary<Vector2, List<int>> connectorRegions = new Dictionary<Vector2, List<int>>();
        for (int i = 1; i < width - 1; i++)
        {
            for (int j = 1; j < height - 1; j++)
            {
                //不是墙的跳过
                if (map[i, j] != Tiles.Wall)
                    continue;
                List<int> regions = new List<int>();
                foreach (Vector2 dir in Directions.all)
                {
                    int region = _regions[i + (int)dir.x, j + (int)dir.y];
                    //如果周围不是墙（墙的索引为regions的初始值为0）
                    //去重
                    if (region != 0 && !regions.Contains(region))
                        regions.Add(region);
                }
                //如果这个墙没有连接一个以上的区域，那就不是一个连接点
                if (regions.Count < 2)
                    continue;
                connectorRegions[new Vector2(i, j)] = regions;
                map[i, j] = Tiles.Connect;
                //标志连接点
                //SetConnectCube(i,j);
            }
        }
        //所有连接点
        List<Vector2> connectors = connectorRegions.Keys.ToList<Vector2>();
        //跟踪哪些区域已合并。将区域索引映射为它已合并的区域索引。
        List<int> merged = new List<int>();
        List<int> openRegions = new List<int>();
        for (int i = 0; i <= currentRegion; i++)
        {
            merged.Add(i);
            openRegions.Add(i);
        }
        //使区域连接最终只剩下一个
        while (openRegions.Count > 1)
        {
           
            //随机选择一个连接点
            if (connectors.Count  <= 0)
            {
                return;
            }
            Vector2 connector = connectors[Random.Range(0, connectors.Count - 1)];


            //连接
            AddJunction(connector);
            //合并连接区域我们将选择第一个区域（任意）和
            //将所有其他区域映射到其索引。
            //connectorRegions[connector]
            List<int> regions = connectorRegions[connector];
            for (int i = 0; i < regions.Count; i++)
            {
                regions[i] = merged[regions[i]];
            }
            int dest = regions[0];
            regions.RemoveAt(0);
            List<int> sources = regions;
            //合并所有受影响的区域
            for (int i = 0; i < currentRegion; i++)
            {
                if (sources.Contains(merged[i]))
                {
                    merged[i] = dest;
                }
            }
            //移除已经连接的区域
            foreach (int s in sources)
            {
                openRegions.RemoveAll(value => (value == s));
            }
            connectors.RemoveAll(index => IsRemove(merged, connectorRegions, connector, index));
        }
    }


    /*
     * 简化迷宫
     */
    private void RemoveDeadEnds()
    {
        bool done = false;
        while (!done)
        {
            done = true;
            for (int i = 1; i < width - 1; i++)
            {
                for (int j = 1; j < height - 1; j++)
                {
                    if (map[i, j] == Tiles.Wall)
                        continue;
                    if (map[i, j] == Tiles.Tianchong)
                        continue;
                    int exists = 0;
                    foreach (Vector2 dir in Directions.all)
                    {
                        if (map[i + (int)dir.x, j + (int)dir.y] != Tiles.Floor&& map[i + (int)dir.x, j + (int)dir.y] != Tiles.Door)
                        {
                            exists++;
                        }
                    }
                    //如果exists==1则是三面环墙
                    if (exists != 3)
                    {
                        continue;
                    }
                    done = false;
                    _regions[i, j] = 0;//变成墙
                    map[i, j] = Tiles.Tianchong;
                }
            }
        }
    }

    /*
     *保存区域索引
     * 
     */
    private void StartRegion()
    {
        currentRegion++;
    }

    /*
     * 雕塑点，设置这个点的类型,默认地板
     * 
     */
    private void Carve(Vector2 pos, Tiles type = Tiles.Floor)
    {
        int x = (int)pos.x, y = (int)pos.y;
        //print(width +"   "+ height);
        //print("now:" + pos);
        map[x, y] = Tiles.Floor;
        _regions[x, y] = currentRegion;
    }

    //dir是方向
    private bool CanCarve(Vector2 pos, Vector2 dir)
    {
        Vector2 temp = pos + 3 * dir;
        int x = (int)temp.x, y = (int)temp.y;
        //判断是否超过边界
        if (x < 0 || x > width || y < 0 || y > height)
        {
            return false;
        }
        //需要判断方向第二个单元的原因是cells中需要添加下一个cell
        //所以下一个cell要变为Floor,然后需要判断是否第二个单元是否为墙
        //如果不为墙，则第一个cell被变为Floor为，和第二个单元就连通了，不可行
        //判断第二个单元主要用来判断不能＆其他房间或走廊（regions）连通
        temp = pos + 2 * dir;
        x = (int)temp.x;
        y = (int)temp.y;
        //是墙则能雕刻迷宫
        return map[x, y] == Tiles.Wall;
    }

    private void AddJunction(Vector2 pos)
    {
        map[(int)pos.x, (int)pos.y] = Tiles.Door;
    }

    /*
     * 删除不需要的连接点
     */
    private bool IsRemove(List<int> merged, Dictionary<Vector2, List<int>> ConnectRegions, Vector2 connector, Vector2 pos)
    {
        //不让连接器相连（包括斜向相连）
        if ((connector - pos).SqrMagnitude() < 2)
        {
            return true;
        }
        List<int> temp = ConnectRegions[pos];
        for (int i = 0; i < temp.Count; i++)
        {
            temp[i] = merged[temp[i]];
        }
        HashSet<int> set = new HashSet<int>(temp);
        //判断连接点是否和两个区域相邻，不然移除
        if (set.Count > 1)
        {
            return false;
        }
        //增加连接，使得地图连接不是单连通的



        //if (Random.Range(0, extraConnectorChance) == 0&&false)
        //{
        //    AddJunction(pos);

        //}
        return true;
    }

    //private void SetConnectCube(int i, int j)
    //{
    //    GameObject go = Instantiate(connect, new Vector3(i, j, 1), Quaternion.identity) as GameObject;
    //    go.transform.SetParent(mapParent);
    //    go.layer = LayerMask.NameToLayer("wall");
    //}

    /*
     * 地图全部初始化为墙
     * 
     */
    private void InitMap()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                map[x, y] = Tiles.Wall;
            }
        }
    }

    private void InstanceMap()
    {
        for (int x = 0; x < width+4; x++)
        {
            for (int y = 0; y < height+4; y++)
            {
                map1[x, y] = Tiles.Wall;
            }
        }
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                map1[2 + i, 2 + j] = map[i,j];

            }
        }


        for (int i = 1; i < width+3; i++)
        {
            for (int j = 1; j < height+3; j++)
            {
                if (map1[i, j] == Tiles.Floor)
                {
                    GameObject go = Instantiate(floor, new Vector3(i, j, 0), Quaternion.identity) as GameObject;
                    go.transform.SetParent(mapParent);
                    //设置层级
                    //chuancan(go,i,j);

                    go.layer = LayerMask.NameToLayer("floor");
                }
                else if (map1[i, j] == Tiles.Wall)
                {
                    GameObject go = Instantiate(wall, new Vector3(i, j, 0), Quaternion.identity) as GameObject;
                    go.transform.SetParent(mapParent);
                    chuancan(go, i, j);
                    go.layer = LayerMask.NameToLayer("Ground");
                }
                else if (map1[i, j] == Tiles.Connect)
                {
                    GameObject go = Instantiate(connect, new Vector3(i, j, 0), Quaternion.identity) as GameObject;
                    go.transform.SetParent(mapParent);
                    chuancan(go, i, j);
                    go.layer = LayerMask.NameToLayer("Ground");
                }
                else if (map1[i, j] == Tiles.Door)
                {
                    GameObject go = Instantiate(door, new Vector3(i, j, 0), Quaternion.identity) as GameObject;
                    go.transform.SetParent(mapParent);
                    //chuancan(go, i, j);
                    go.layer = LayerMask.NameToLayer("floor");
                }
                else if (map1[i, j] == Tiles.Tianchong)
                {
                    GameObject go = Instantiate(dead, new Vector3(i, j, 0), Quaternion.identity) as GameObject;
                    go.transform.SetParent(mapParent);
                    chuancan(go, i, j);
                    go.layer = LayerMask.NameToLayer("Ground");
                }
            }
        }
    }
    void chuancan(GameObject go,int i,int j)
    {
        int[] a;
        a = new int[9];
        for (int k = 0; k < 9; k++)
        {
            if (map1[i + (int)ninecube.all[k].x, j + (int)ninecube.all[k].y] == Tiles.Wall || map1[i + (int)ninecube.all[k].x, j + (int)ninecube.all[k].y] == Tiles.Tianchong || map1[i + (int)ninecube.all[k].x, j + (int)ninecube.all[k].y] == Tiles.Connect)
            {
                a[k] = 1;
            }
            else
            {
                a[k] = 0;
            }
        }
       
        go.GetComponent<cube>().suround = a;
    }

}
