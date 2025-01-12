using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace otto
{
    internal class Sekor
    {
        public string nama;
        public int skor;

        public Sekor(string nama, int skor)
        {
            this.nama = nama;
            this.skor = skor;
        }
        public string Nama { get; set; }
        public int Skor { get; set; }

        public override string ToString()
        {
            return $"{nama} - {skor}";
        }
    }
}
