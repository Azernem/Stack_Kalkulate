using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace steck_kalkulator
{
    interface Ikalkan
    {
        void Adding(float t);
        float Popping();

    }
    class Spisok : Ikalkan
    {
        float b1;
        float b2;
        List<float> spis = new List<float>();
        public void Adding(float t)
        {
            spis.Add(t);
        }
        public float Popping()
        {
            float last_el = spis[spis.Count - 1];
            spis.RemoveAt(spis.Count - 1);
            return last_el;
        }
        public dynamic Answer_1(string z) // здесь долго разбирался с типом возвращаемого значения. Сначала написал var, не получилось. Затем В Интернете нашёл подходящий тип dynamic
        {
            string[] s = z.Split(' ');
            for (int i = 0; i < s.Length; ++i)
            {
                if (s[i] == " ")
                {
                    continue;
                }
                else if (s[i] == "+")
                {
                    b1 = Popping();
                    b2 = Popping();
                    Adding(b1 + b2);
                }
                else if (s[i] == "-")
                {
                    b1 = Popping();
                    b2 = Popping();
                    Adding(b2 - b1);
                }
                else if (s[i] == "/")
                {
                    b1 = Popping();
                    if (Math.Abs(b1) < 1e-7) { goto kc; }
                    b2 = Popping();
                    Adding(b2 / b1);

                }
                else if (s[i] == "*")
                {
                    b1 = Popping();
                    b2 = Popping();
                    Adding(b1 * b2);
                }
                else
                {
                    Adding(int.Parse(s[i]));
                }
            
            }
            return Popping();

        kc:;
            return "Mistake";


        }
        
        
        
    }

    class Massiv : Ikalkan
    {
        float b1;
        float b2;
        float[] mas = new float[1];
        public void Adding(float t)
        {
            Array.Resize(ref mas, mas.Length + 1);
            mas[mas.Length - 1] = t;
        }
        public float Popping()
        {
            float last_el = mas[mas.Length - 1];
            Array.Resize(ref mas, mas.Length - 1);
            return last_el;
        }
        public dynamic Answer_2(string z)
        {
            string[] s = z.Split(' ');
            for (int i = 0; i < s.Length; ++i)
            {
                if (s[i] == " ")
                {
                    continue;
                }
                else if (s[i] == "+")
                {
                    b1 = Popping();
                    b2 = Popping();
                    Adding(b1 + b2);
                }
                else if (s[i] == "-")
                {
                    b1 = Popping();
                    b2 = Popping();
                    Adding(b2 - b1);
                }
                else if (s[i] == "/")
                {
                    b1 = Popping();
                    if (Math.Abs(b1) < 1e-7) {  goto kc; }
                    b2 = Popping();
                    Adding(b2 / b1);

                }
                else if (s[i] == "*")
                {
                    b1 = Popping();
                    b2 = Popping();
                    Adding(b1 * b2);
                }
                else
                {
                    Adding(int.Parse(s[i]));
                }
            }
            return Popping();
        kc:;
            return "Mistake";
        }
    }

    internal class Program
    { 
    static void Main(string[] args)
        {
            string s = Console.ReadLine();
            Spisok c1 = new Spisok();
            Massiv c2 = new Massiv();
            Console.WriteLine(c1.Answer_1(s));
            Console.WriteLine(c2.Answer_2(s));
            
        }
    }
}
    



