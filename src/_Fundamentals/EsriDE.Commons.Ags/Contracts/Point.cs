using System.Runtime.Serialization;

namespace EsriDE.Commons.Ags.Contracts
{
	[DataContract]
	public class Point
	{
		[DataMember(Name = "x")]
		public double X { get; set; }

		[DataMember(Name = "y")]
		public double Y { get; set; }
	}
}