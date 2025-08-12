using ImageMagick;

namespace MagickNET_perceptualhash_change;

[TestClass]
public class UnitTest1
{
	private const string Version_7_16_0_Hash = "af04685a6188478888fe61b5c8b63f61c8ca231f81a7a85cf485a478bb18869a98bc82aeb3d84e358992e89dfe61f5c8c54162712ceff982a4f81b62819f7834b882f1f85c7cadc9c8497d888f388db061c1d8b29661fb5ae97684fe988e82890f561ce28b8ed6205e";
	private const string Version_13_10_0_Hash = "af04685a6188478888fe61b5c8b63f61c8ca231e81a7a85cee85a418bb0a869a28bc78aeb3d84e358992e89dfe61f5c8c54162712ceff982a4f81b62819f7834b882f1f85c7cadc9c8497d888f388db061c1d8b29661fb5ae97684fe988e82890f561ce28b8ed6205e";
	private const string Version_14_0_0_Hash = "a6784839b28a7658adaa622778d3d6624f1a231e81a7a85cee85a418bb0a869a28bc78a7212838eb8a3628a9fe621de8c68c622fea63ab83ed98327c831b1863f585127884beab934846ff870ec873428e55f896d861c01af401850b48a35f8a5dc621128ce386242d";

	[TestMethod]
	public void GenerateHash_MagickNET_Q16_AnyCPU_7_16_0()
	{
		using var image = new MagickImage("pexels-photo-5563472.jpg");
		var result = image.PerceptualHash()!.ToString();
		Assert.AreEqual(Version_7_16_0_Hash, result);
	}

	[TestMethod]
	public void GenerateHash_MagickNET_Q16_AnyCPU_13_10_0()
	{
		using var image = new MagickImage("pexels-photo-5563472.jpg");
		var result = image.PerceptualHash()!.ToString();
		Assert.AreEqual(Version_13_10_0_Hash, result);
	}

	[TestMethod]
	public void HashDifference_MagickNET_Q16_AnyCPU_7_16_0_VS_MagickNET_Q16_AnyCPU_13_10_0()
	{
		var hash1 = new PerceptualHash(Version_7_16_0_Hash);
		var hash2 = new PerceptualHash(Version_13_10_0_Hash);
		Assert.IsTrue(hash1.SumSquaredDistance(hash2) < 0.00001);
	}

	[TestMethod]
	public void GenerateHash_MagickNET_Q16_AnyCPU_14_0_0()
	{
		using var image = new MagickImage("pexels-photo-5563472.jpg");
		var result = image.PerceptualHash()!.ToString();
		Assert.AreEqual(Version_14_0_0_Hash, result);
	}

	[TestMethod]
	public void HashDifference_MagickNET_Q16_AnyCPU_13_10_0_VS_MagickNET_Q16_AnyCPU_14_0_0()
	{
		var hash1 = new PerceptualHash(Version_13_10_0_Hash);
		var hash2 = new PerceptualHash(Version_14_0_0_Hash);
		Assert.AreEqual(0, hash1.SumSquaredDistance(hash2));
	}
}