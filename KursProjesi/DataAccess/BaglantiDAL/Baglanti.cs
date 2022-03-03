using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursProjesi.DataAccess.BaglantiDAL
{
    public static class Baglanti //Program boyunca değişmesin diye
                                 //static başta yarattığımız nesnesin değişmesini istemediğimiz için kıllanırız
    {
        private static SqlConnection baglantiNesnesi;

        public static SqlConnection BaglantiNesnesi
        {
            get //veriyi alırken get tetiklenir
            {
                if(baglantiNesnesi==null)
                { 
                     baglantiNesnesi = new SqlConnection(ConfigurationManager.ConnectionStrings["CsKurslar"].ConnectionString);//CsKurslar yerine 0 da yazblirsin
                }
                return baglantiNesnesi; 
            }
            set 
            {
                baglantiNesnesi = value; 
            }
        }

        public static void Ac()
        {
            if (BaglantiNesnesi.State==ConnectionState.Closed)
            {
                BaglantiNesnesi.Open();
            }
        }
        public static void Kapa()
        {
            if (BaglantiNesnesi.State!=ConnectionState.Open) BaglantiNesnesi.Close();
            
        } 

    }
}
