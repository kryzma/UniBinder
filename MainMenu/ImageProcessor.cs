using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogIn
{
    class ImageProcessor
    {
        public Image defaultImage;
        public ImageProcessor()
        {
            SqlConnection connection = DataBaseInfo.getSqlConnection();
            connection.Open();

            string querry = "select image from images where id = -1 ";
            SqlCommand command = new SqlCommand(querry, connection);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();

            defaultImage = Base64ToImage(reader[0].ToString());

            connection.Close();
        }
        public string ImageToBase64(Image image, System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();

                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }

        public Image Base64ToImage(string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0,
              imageBytes.Length);

            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }
    }
}
