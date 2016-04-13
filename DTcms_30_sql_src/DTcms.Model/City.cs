using System;
namespace DTcms.Model
{
	/// <summary>
	/// City:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class City
	{
		public City()
		{}
		#region Model
		private int _id;
		private string _provincename;
		private int? _provinceno;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string provinceName
		{
			set{ _provincename=value;}
			get{return _provincename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? provinceNo
		{
			set{ _provinceno=value;}
			get{return _provinceno;}
		}
		#endregion Model

	}
}

