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
            var builder = new SqlConnectionStringBuilder();
            builder.DataSource = DataBaseInfo.DataSource;
            builder.UserID = DataBaseInfo.UserID;
            builder.Password = DataBaseInfo.Password;
            builder.InitialCatalog = DataBaseInfo.InitialCatalog;
            SqlConnection connection = new SqlConnection(builder.ConnectionString);
            connection.Open();

            StringBuilder sb = new StringBuilder();
            sb.Append("select image ");
            sb.Append("from images ");
            sb.Append("where id = -1;");
            string querry =  sb.ToString();
            SqlCommand command = new SqlCommand(querry, connection);
            SqlDataReader reader = command.ExecuteReader();

            
            if (reader.FieldCount.Equals(0))
            {
                defaultImage = Base64ToImage(reader.GetString(0));
            }

            connection.Close();
        }
        public void LoadUserImage()
        {

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
