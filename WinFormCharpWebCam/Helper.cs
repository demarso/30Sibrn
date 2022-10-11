using AcessoBancoDados;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;


namespace WinFormCharpWebCam
{

    //Design by Pongsakorn Poosankam
    class Helper
    {
                
        public static void SaveImageCapture(System.Drawing.Image image)
        {
            AcessoDadosSqlServer acessoDadosSqlServer = new AcessoDadosSqlServer();
            string idPessoal = acessoDadosSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspPessoalMaxId").ToString();
            int idPessoa = Convert.ToInt32(idPessoal);
            idPessoa = idPessoa + 1;
            string idP = Convert.ToString(idPessoa);

            SaveFileDialog s = new SaveFileDialog();
            s.FileName = idP;// Default file name
            s.DefaultExt = ".Jpg";// Default file extension
            s.Filter = "Image (.jpg)|*.jpg"; // Filter files by extension

            // Show save file dialog box
            // Process save file dialog box results
            if (s.ShowDialog()==DialogResult.OK)
            {
                // Save Image
                string filename = s.FileName;
                FileStream fstream = new FileStream(filename, FileMode.Create);
                image.Save(fstream, System.Drawing.Imaging.ImageFormat.Jpeg);
                fstream.Close();

            }

        }

        private static string MaxId()
        {
            throw new NotImplementedException();
        }
    }
}
