using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "あいうえおかきくけこ";

            //先頭から5文字を削除する
            string s1 = s.Remove(0, 5);
            //かきくけこ

            //2文字目（インデックスは1）から3文字を削除する
            string s2 = s.Remove(1, 3);
            //あおかきくけこ

            //6文字目から最後まで削除する
            string s3 = s.Remove(5);
            //あいうえお


            //先頭から5文字を削除する（6文字目以降を取得する）
            string s4 = s.Substring(5);
            //かきくけこ

            //2文字目から3文字を削除する（はじめの1文字と、5文字目以降を結合する）
            string s5 = s.Substring(0, 1) + s.Substring(4);
            //あおかきくけこ

            //6文字目から最後まで削除する（先頭から5文字を取得する）
            string s6 = s.Substring(0, 5);
            //あいうえお

            Console.WriteLine(s1);
            Console.WriteLine(s2);
            Console.WriteLine(s3);
            Console.WriteLine(s4);
            Console.WriteLine(s5);
            Console.WriteLine(s6);

            Console.WriteLine(s.Remove(s.Length-1));
            Console.WriteLine(s.Remove(3));

            
        }
    }
}
