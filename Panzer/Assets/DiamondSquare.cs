using UnityEngine;
using System.Collections;

public class DiamondSquare : MonoBehaviour {

    public static int ysize = 2048, xsize = 2048;
    public static float[,] heighmap = new float[xsize, ysize];
    public static float roughness = 20f;      //Определяет разницу высот, чем больше, тем более неравномерная карта высот

    public static void Square(int lx, int ly, int rx, int ry)
    {
        int l = (rx - lx) / 2;

        float a = heighmap[lx, ly];              //  B--------C
        float b = heighmap[lx, ry];              //  |        |
        float c = heighmap[rx, ry];              //  |   ce   |
        float d = heighmap[rx, ly];              //  |        |        
        int cex = lx + l;                        //  A--------D
        int cey = ly + l;

        heighmap[cex, cey] = (a + b + c + d) / 4 + Random.Range(-l * 2 * roughness / ysize, l * 2 * roughness / ysize);
    }

    static bool lrflag = false;
    public static void Diamond(int tgx, int tgy, int l)
    {
        float a, b, c, d;

        if (tgy - l >= 0)
            a = heighmap[tgx, tgy - l];                        //      C--------
        else                                                   //      |        |
            a = heighmap[tgx, ysize - l];                      // B---t g----D  |
                                                               //      |        |
                                                               //      A--------
        if (tgx - l >= 0)
            b = heighmap[tgx - l, tgy];
        else
            if (lrflag)
            b = heighmap[xsize - l, tgy];
        else
            b = heighmap[ysize - l, tgy];


        if (tgy + l < ysize)
            c = heighmap[tgx, tgy + l];
        else
            c = heighmap[tgx, l];

        if (lrflag)
            if (tgx + l < xsize)
                d = heighmap[tgx + l, tgy];
            else
                d = heighmap[l, tgy];
        else
            if (tgx + l < ysize)
            d = heighmap[tgx + l, tgy];
        else
            d = heighmap[l, tgy];

        heighmap[tgx, tgy] = (a + b + c + d) / 4 + Random.Range(-l * 2 * roughness / ysize, l * 2 * roughness / ysize);
    }

    public static void DiamondS(int lx, int ly, int rx, int ry)
    {
        int l = (rx - lx) / 2;

        Square(lx, ly, rx, ry);

        Diamond(lx, ly + l, l);
        Diamond(rx, ry - l, l);
        Diamond(rx - l, ry, l);
        Diamond(lx + l, ly, l);
    }


    public static void MidPointDisplacement(int lx, int ly, int rx, int ry)
    {
        int l = (rx - lx) / 2;
        if (l > 0)
        {
            float a = heighmap[lx, ly];              //  B--------C
            float b = heighmap[lx, ry];              //  |        |
            float c = heighmap[rx, ry];              //  |   ce   |
            float d = heighmap[rx, ly];              //  |        |
            //  A--------D
            int cex = lx + l;
            int cey = ly + l;

            heighmap[cex, cey] = (a + b + c + d) / 4 + Random.Range(-l * 2 * roughness / xsize, l * 2 * roughness / xsize);

            heighmap[lx, cey] = (a + b) / 2 + Random.Range(-l * 2 * roughness / xsize, l * 2 * roughness / xsize);
            heighmap[rx, cey] = (c + d) / 2 + Random.Range(-l * 2 * roughness / xsize, l * 2 * roughness / xsize);
            heighmap[cex, ly] = (a + d) / 2 + Random.Range(-l * 2 * roughness / xsize, l * 2 * roughness / xsize);
            heighmap[cex, ry] = (b + c) / 2 + Random.Range(-l * 2 * roughness / xsize, l * 2 * roughness / xsize);

            MidPointDisplacement(lx, ly, cex, cey);
            MidPointDisplacement(lx, ly + l, lx + l, ry);
            MidPointDisplacement(cex, cey, rx, ry);
            MidPointDisplacement(lx + l, ly, rx, cey);
        }
    }


    public static void Generate()
    {
        heighmap[0, 0] = Random.Range(0.3f, 0.6f);
        heighmap[0, ysize - 1] = Random.Range(0.3f, 0.6f);
        heighmap[xsize - 1, ysize - 1] = Random.Range(0.3f, 0.6f);
        heighmap[xsize - 1, 0] = Random.Range(0.3f, 0.6f);

        heighmap[ysize - 1, ysize - 1] = Random.Range(0.3f, 0.6f);
        heighmap[ysize - 1, 0] = Random.Range(0.3f, 0.6f);

        for (int l = (ysize - 1) / 2; l > 0; l /= 2)
            for (int x = 0; x < xsize - 1; x += l)
            {
                if (x >= ysize - l)
                    lrflag = true;
                else
                    lrflag = false;

                for (int y = 0; y < ysize - 1; y += l)
                    DiamondS(x, y, x + l, y + l);
            }
    }

    // Use this for initialization
    void Start()
    {

        Terrain terrain = FindObjectOfType<Terrain>();
        terrain.terrainData.size = new Vector3(xsize, ysize, xsize);
        Generate();
        terrain.terrainData.SetHeights(xsize, ysize, heighmap);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
