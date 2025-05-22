using System;
using System.Data;
namespace SharpVision.Base.BaseDataBase
{
	/// <summary>
	/// Summary description for IBaseDataBase.
	/// </summary>
	public interface IBaseDataBase
	{
		void Add();
		void Edit();
		void Delete();
		DataTable Search();
		

	}
}
