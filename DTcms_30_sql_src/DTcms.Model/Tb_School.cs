using System;
namespace DTcms.Model
{
	/// <summary>
	/// Tb_School:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Tb_School
	{
		public Tb_School()
		{}
		#region Model
		private int _schoolid;
		private string _schoolname;
		private int? _provinceid;
		private int? _cityid;
		private int? _countyid;
		private string _schoolcode;
		private string _serverurl;
		private string _schoolsite;
		private string _emsurl;
		private int? _schooltype;
		private int? _upschoolid;
		private int? _townsid;
		private string _automaticliveurl;
		private string _schoolkey;
		/// <summary>
		/// 
		/// </summary>
		public int SchoolID
		{
			set{ _schoolid=value;}
			get{return _schoolid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SchoolName
		{
			set{ _schoolname=value;}
			get{return _schoolname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ProvinceID
		{
			set{ _provinceid=value;}
			get{return _provinceid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CityID
		{
			set{ _cityid=value;}
			get{return _cityid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CountyID
		{
			set{ _countyid=value;}
			get{return _countyid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SchoolCode
		{
			set{ _schoolcode=value;}
			get{return _schoolcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ServerUrl
		{
			set{ _serverurl=value;}
			get{return _serverurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SchoolSite
		{
			set{ _schoolsite=value;}
			get{return _schoolsite;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EMSUrl
		{
			set{ _emsurl=value;}
			get{return _emsurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? SchoolType
		{
			set{ _schooltype=value;}
			get{return _schooltype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? upSchoolID
		{
			set{ _upschoolid=value;}
			get{return _upschoolid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? TownsID
		{
			set{ _townsid=value;}
			get{return _townsid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AutomaticLiveUrl
		{
			set{ _automaticliveurl=value;}
			get{return _automaticliveurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SchoolKey
		{
			set{ _schoolkey=value;}
			get{return _schoolkey;}
		}
		#endregion Model

	}
}

