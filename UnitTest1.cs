using ImageMagick;

namespace MagickNET_perceptualhash_change;

[TestClass]
public class UnitTest1
{
	private const string Version_14_0_0_Hash = "a6784839b28a7658adaa622778d3d6624f1a231e81a7a85cee85a418bb0a869a28bc78a7212838eb8a3628a9fe621de8c68c622fea63ab83ed98327c831b1863f585127884beab934846ff870ec873428e55f896d861c01af401850b48a35f8a5dc621128ce386242d";
    private const string Version_14_6_0_Hash = "a6783839b28a7658adad622778d3dc624f4a231e81a7a85cee85a418bb0a869a28bc78a720f838eb8a35e8a9fb621de8c689622fda63ab83ed98327c831b1863f585127884beab932846fe870ec873428e55e896d761c01af401850b48a35f8a5dc621128ce386242d";
    private const string Version_14_7_0_Hash = "a6783839b28a7658adad62ee08d3dc624f4a231e81a7a85cee85a418bb0a869a28bc78a720f838eb8a35e8a9fb621de8c68962ee0a63ab83ed98327c831b1863f585127884beab932846fe870ec873428e55e896d761c01af401850b48a35f8a5dc621128ce386242d";

    [TestMethod]
	public void GenerateHash_MagickNET_Q16_AnyCPU_14_0_0()
	{
		using var image = new MagickImage("pexels-photo-5563472.jpg");
		var result = image.PerceptualHash()!.ToString();
		Assert.AreEqual(Version_14_0_0_Hash, result);
	}

    [TestMethod]
    public void GenerateHash_MagickNET_Q16_AnyCPU_14_6_0()
    {
        using var image = new MagickImage("pexels-photo-5563472.jpg");
        var result = image.PerceptualHash()!.ToString();
        Assert.AreEqual(Version_14_6_0_Hash, result);
    }

    [TestMethod]
    public void GenerateHash_MagickNET_Q16_AnyCPU_14_7_0()
    {
        using var image = new MagickImage("pexels-photo-5563472.jpg");
        var result = image.PerceptualHash()!.ToString();
        Assert.AreEqual(Version_14_7_0_Hash, result);
    }

    [TestMethod]
    public void HashDifference_MagickNET_Q16_AnyCPU_14_0_0_VS_MagickNET_Q16_AnyCPU_14_6_0()
    {
        var hash1 = new PerceptualHash(Version_14_0_0_Hash);
        var hash2 = new PerceptualHash(Version_14_6_0_Hash);
        Assert.IsTrue(hash1.SumSquaredDistance(hash2) < 0.0001);
    }

    [TestMethod]
    public void HashDifference_MagickNET_Q16_AnyCPU_14_6_0_VS_MagickNET_Q16_AnyCPU_14_7_0()
    {
        var hash1 = new PerceptualHash(Version_14_6_0_Hash);
        var hash2 = new PerceptualHash(Version_14_7_0_Hash);
        Assert.IsTrue(hash1.SumSquaredDistance(hash2) < 0.0001);
    }
}