using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using LibraryClassTransfile;

namespace TransfileService
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
	// NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
	public class Service1 : IServiceTransfile
	{
		
		public void CreateUser(User user)
		{
			throw new NotImplementedException();
		}

		public void DeleteFile(File file)
		{
			throw new NotImplementedException();
		}

		public void DeleteUser(User user)
		{
			throw new NotImplementedException();
		}

		public void InsertFile(File file)
		{
			throw new NotImplementedException();
		}

		public List<File> ListFIle()
		{
			throw new NotImplementedException();
		}

		public List<User> ListUser()
		{
			throw new NotImplementedException();
		}

		public void LoggIn(User user)
		{
			throw new NotImplementedException();
		}

		public File TransferFile(File file)
		{
			throw new NotImplementedException();
		}

		public void UpdateFile(File file)
		{
			throw new NotImplementedException();
		}

		public void UpdateUser(User user)
		{
			throw new NotImplementedException();
		}

		public bool VerifyUser(User user)
		{
			throw new NotImplementedException();
		}
	}
}
