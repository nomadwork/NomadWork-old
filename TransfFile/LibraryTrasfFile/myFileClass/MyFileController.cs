using LibraryTrasfFile.sendClass;
using LibraryTrasfFile.utils;
using System;

namespace LibraryTrasfFile.myFileClass
{
    public class MyFileController
    {
        #region Test
        public MyFile DownloadFileTest(string send)
        {
            MyFile myFile = null;
            try
            {
                myFile = VerifyFileOk(new MyFileData().GetFileTest(send));
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return myFile;
        }

        #endregion

        public MyFile DownloadFile(string shipping)
        {
            MyFile myFile = null;
            try
            {
                myFile = VerifyFileOk(new MyFileData().GetFile(shipping));
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return myFile;
        }
      
        public bool SaveFile(Send send)
        {
            var ok = false;
            
            try
            {
                send.MyFileSend = VerifyFileOk(send.MyFileSend);

                if (new SendController().InsertSend(send)
                    && new MyFileData().InsertFile(send))
                {
                    ok = true;
                    Log.LogIt(send,send.Shipping);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Salvar Arquivo: " + ex.Message + " ");
            }
            return ok;

        }
      
        private MyFile VerifyFileOk(MyFile myFile)
        {

            myFile.FileName = myFile.FileName.Replace(" ", "_").Replace(".", "_");
            try
            {
                if (myFile.FileBytes.Length > 2000000)
                {
                    throw new Exception("Não foi possível enviar este arquivo!\n" + myFile.FileName + myFile.FileType + " é maior que 2Mb!");
                }

                if (myFile.FileBytes.Length == 0)
                {
                    throw new Exception("Não foi possível enviar este arquivo!\n" + myFile.FileName + myFile.FileType + " é muito pequeno!");
                }

                if (myFile.FileName.Equals(""))
                {
                    throw new Exception("Não foi possível enviar este arquivo!\n" + myFile.FileName + myFile.FileType + " Nome incompatível");
                }
            }

            catch (Exception ex)
            {
                throw new Exception("Erro ao verificar tamanho do Arquivo: " + ex.Message + " " + myFile.FileName + myFile.FileType);
            }

            return myFile;

        }
    }
}
