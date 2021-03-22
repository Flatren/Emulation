using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Звери
{
    class Field
    {
        public int[,] ifield;
        public int[,] ifield_copy;
        public int[,] deepfield;
        int n;
        int m;
        public int max;
        public int deep;
        public int sid;
        public Field(int n, int m)
        {
            this.n = n;
            this.m = m;
            ifield = new int[n, m];
            ifield_copy = new int[n, m];
            deepfield = new int[n, m];
            deep = 6;
            max = 300;
            sid = 150;
        }

        public void GladV2()
        {
            int sum = 0;
            int avg = 0;
            int mod = 0;
            int count = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    ifield_copy[i, j] = 0;
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {

                    if (ifield[i, j] > deepfield[i, j])
                    {
                        count = 0;
                        sum = ifield[i, j] - deepfield[i, j];
                        ifield_copy[i, j] += deepfield[i, j];
                        if (i + 1 < n)
                        { count++; }
                        if (i - 1 >= 0)
                        { count++; }
                        if (j + 1 < m)
                        { count++; }
                        if (j - 1 >= 0)
                        { count++; }
                        if (j + 1 < m && i + 1 < n)
                        { count++; }
                        if (j - 1 >= 0 && i - 1 >= 0)
                        { count++; }
                        if (j + 1 < m && i - 1 >= 0)
                        { count++; }
                        if (j - 1 >= 0 && i + 1 < n)
                        { count++; }
                        mod = sum % count;
                        avg = sum / count;
                        ifield_copy[i, j] += mod;
                        if (i + 1 < n)
                        { ifield_copy[i + 1, j] += avg; }
                        if (i - 1 >= 0)
                        { ifield_copy[i - 1, j] += avg; }
                        if (j + 1 < m)
                        { ifield_copy[i, j + 1] += avg; }
                        if (j - 1 >= 0)
                        { ifield_copy[i, j - 1] += avg; }
                        if (j + 1 < m && i + 1 < n)
                        { ifield_copy[i + 1, j + 1] += avg; }
                        if (j - 1 >= 0 && i - 1 >= 0)
                        { ifield_copy[i - 1, j - 1] += avg; }
                        if (j + 1 < m && i - 1 >= 0)
                        { ifield_copy[i - 1, j + 1] += avg; }
                        if (j - 1 >= 0 && i + 1 < n)
                        { ifield_copy[i + 1, j - 1] += avg; }
                    }
                    else
                    {
                        ifield_copy [i , j] += ifield[i, j];
                    }
                }
            }
            int[,] vs = ifield_copy;
            ifield_copy = ifield;
            ifield = vs;
        }

        public void Glad()
        {
            int sum;
            int msum;
            //сглаживаем
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    ifield_copy[i, j] = 0;
                    if (ifield[i, j] > deepfield[i, j])
                    {

                        sum = ifield[i, j];
                        count = 1;
                        if(i+1 < n)
                            if (ifield[i, j] > ifield[i + 1, j])
                                { sum += ifield[i + 1, j]; count++; }
                        if (i - 1 >= 0)
                            if (ifield[i, j] > ifield[i - 1, j])
                                { sum += ifield[i - 1, j]; count++; }
                        if (j + 1 < m)
                            if (ifield[i, j] > ifield[i, j + 1])
                                { sum += ifield[i, j + 1]; count++; }
                        if (j - 1 >= 0)
                            if (ifield[i, j] > ifield[i, j - 1])
                            {   sum += ifield[i, j - 1]; count++; }

                        if (j + 1 < m && i + 1 < n)
                            if (ifield[i, j] > ifield[i + 1, j + 1])
                                {   sum += ifield[i + 1, j + 1]; count++; }
                        if (j - 1 >= 0 && i - 1 >= 0)
                            if (ifield[i, j] > ifield[i - 1, j - 1])
                        {   sum += ifield[i - 1, j - 1]; count++; }
                        if (j + 1 < m && i - 1 >= 0)
                            if (ifield[i, j] > ifield[i - 1, j + 1])
                        {   sum += ifield[i - 1, j + 1]; count++; }
                        if (j - 1 >=0 && i + 1 < n)
                            if (ifield[i, j] > ifield[i + 1, j - 1])
                        { sum += ifield[i + 1, j - 1]; count++; }
                        msum = sum % count;
                        sum = sum / count;

                        if (i + 1 < n)
                            if (ifield[i, j] > ifield[i + 1, j])
                            ifield[i + 1, j] = sum;
                        if (i - 1 >= 0)
                            if (ifield[i, j] > ifield[i - 1, j])
                            ifield[i - 1, j] = sum;
                        if (j + 1 < m)
                            if (ifield[i, j] > ifield[i, j + 1])
                            ifield[i, j + 1] = sum;
                        if (j - 1 >= 0)
                            if (ifield[i, j] > ifield[i, j - 1])
                            ifield[i, j - 1] = sum;

                        if (j + 1 < m && i + 1 < n)
                            if (ifield[i, j] > ifield[i + 1, j + 1])
                            ifield[i + 1, j + 1] = sum;
                        if (j - 1 >= 0 && i - 1 >= 0)
                            if (ifield[i, j] > ifield[i - 1, j - 1])
                            ifield[i - 1, j - 1] = sum;
                        if (j + 1 < m && i - 1 >= 0)
                            if (ifield[i, j] > ifield[i - 1, j + 1])
                            ifield[i - 1, j + 1] = sum;
                        if (j - 1 >=0 && i + 1 < n)
                            if (ifield[i, j] > ifield[i + 1, j - 1])
                            ifield[i + 1, j - 1] = sum;

                        ifield[i, j] = sum + msum;
                    }

                }
            }

           
        }

        public void GenericNewField()
        {
            Random rand = new Random(sid);
            //Заполняем двухмерный массив случайными даннными
            for (int i = 1; i < n-1; i++)
            {
                for (int j = 1; j < m-1; j++)
                {
                    ifield[i, j] = rand.Next(max)-max/2;
                    deepfield[i, j] = rand.Next(deep); 
                }
            }
            //ifield[n / 2+40, m / 2+40] = -100000000;
            //ifield[n/2, m/2] = 1000000;
            //ifield[n / 2, m / 2+40] = 100000;
           // ifield[n / 2+20, m / 2+20] = -10000000;
        }

        public Bitmap GetBitmap(Bitmap bitmap)
        {
            
            int color;
            double cof;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    
                    cof = Math.Abs(ifield[i, j]) / (double)(max);
                    color = 255 << 24;
                    //color += ((int)(cof * 255 )) << 16;
                    color += ((int)(cof * 255)) << 8;
                    //color += (int)(cof * 120);
                    bitmap.SetPixel(i,j,Color.FromArgb(color));
                }
            }
            return bitmap;
        }
    }
}
