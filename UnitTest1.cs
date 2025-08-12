using ImageMagick;

namespace MagickNET_perceptualhash_change;

[TestClass]
public class UnitTest1
{
	private const string Version_14_0_0_Hash = "af04685a6188478888fe61b5c8b63f61c8ca231e81a7a85cee85a418bb0a869a28bc78aeb3d84e358992e89dfe61f5c8c54162712ceff982a4f81b62819f7834b882f1f85c7cadc9c8497d888f388db061c1d8b29661fb5ae97684fe988e82890f561ce28b8ed6205e";
    private const string Version_14_6_0_Hash = "af04685a6188478888fe61b5c8b63f61c8ca231e81a7a85cee85a418bb0a869a28bc78aeb3d84e358992e89dfe61f5c8c54162712ceff982a4f81b62819f7834b882f1f85c7cadc9c8497d888f388db061c1d8b29661fb5ae97684fe988e82890f561ce28b8ed6205e";
    private const string Version_14_7_0_Hash = "af04685a6188478888fe61b5c8b63f61c8ca231e81a7a85cee85a418bb0a869a28bc78aeb3d84e358992e89dfe61f5c8c54162ee0ceff982a4f81b62819f7834b882f1f85c7cadc9c8497d888f388db061c1d8b29662ee0ae97684fe988e82890f561ce28b8ed6205e";

    [TestMethod]
	public void GenerateHash_MagickNET_Q16_AnyCPU_14_0_0()
	{
		using var image = new MagickImage("pexels-photo-5563472.jpg");
		var result = image.PerceptualHash(ColorSpace.sRGB, ColorSpace.HCLp)!.ToString();
		Assert.AreEqual(Version_14_0_0_Hash, result);
	}

    [TestMethod]
    public void GenerateHash_MagickNET_Q16_AnyCPU_14_6_0()
    {
        using var image = new MagickImage("pexels-photo-5563472.jpg");
        var result = image.PerceptualHash(ColorSpace.sRGB, ColorSpace.HCLp)!.ToString();
        Assert.AreEqual(Version_14_6_0_Hash, result);
    }

    [TestMethod]
    public void GenerateHash_MagickNET_Q16_AnyCPU_14_7_0()
    {
        using var image = new MagickImage("pexels-photo-5563472.jpg");
        var result = image.PerceptualHash(ColorSpace.sRGB, ColorSpace.HCLp)!.ToString();
        Assert.AreEqual(Version_14_7_0_Hash, result);
    }

    [TestMethod]
    public void HashDifference_MagickNET_Q16_AnyCPU_14_0_0_VS_MagickNET_Q16_AnyCPU_14_6_0()
    {
        var hash1 = new PerceptualHash(Version_14_0_0_Hash, ColorSpace.sRGB, ColorSpace.HCLp);
        var hash2 = new PerceptualHash(Version_14_6_0_Hash, ColorSpace.sRGB, ColorSpace.HCLp);
        Assert.IsTrue(hash1.SumSquaredDistance(hash2) == 0);
    }

    [TestMethod]
    public void HashDifference_MagickNET_Q16_AnyCPU_14_6_0_VS_MagickNET_Q16_AnyCPU_14_7_0()
    {
        var hash1 = new PerceptualHash(Version_14_6_0_Hash, ColorSpace.sRGB, ColorSpace.HCLp);
        var hash2 = new PerceptualHash(Version_14_7_0_Hash, ColorSpace.sRGB, ColorSpace.HCLp);
        Assert.IsTrue(hash1.SumSquaredDistance(hash2) < 0.0001);
    }
}