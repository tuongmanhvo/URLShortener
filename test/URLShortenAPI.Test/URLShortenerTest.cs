namespace URLShortenAPI.Test;
public class URLShortenerTest {
    [Fact]
    public void TwoUrls_DiffAtBeginning_ShortUrlShouldDiff() {
        ShrinkUrlSettings urlSettings = CreateUrlSettings();
        var url1 = "https://www.quantbe.com/welcome/canada/logs/validate";
        var url2 = "https://www.auantbe.com/welcome/canada/logs/validate";

        var shortUrl1 = URLShortener.Shorten(url1, urlSettings);
        var shortUrl2 = URLShortener.Shorten(url2, urlSettings);

        Assert.NotEqual(shortUrl1, shortUrl2);
    }

    [Fact]
    public void TwoUrls_SameAtBeginning_ShortUrlShouldSame() {
        ShrinkUrlSettings urlSettings = CreateUrlSettings();
        var url1 = "https://www.quantbe.com/welcome/canada/logs/validate";
        var url2 = "https://www.quantbe.com/welcome/canada/logs/validate1";

        var shortUrl1 = URLShortener.Shorten(url1, urlSettings);
        var shortUrl2 = URLShortener.Shorten(url2, urlSettings);

        Assert.Equal(shortUrl1, shortUrl2);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void UrlNullOrEmptyThrowArgumentEx(string url) {
        ShrinkUrlSettings urlSettings = CreateUrlSettings();
        Assert.ThrowsAny<ArgumentException>(() => URLShortener.Shorten(url, urlSettings));
    }

    [Theory]
    [InlineData("htt://www.google.com")]
    [InlineData("google.com")]
    public void InvalidUrlShouldThrowFormatEx(string url) {
        ShrinkUrlSettings urlSettings = CreateUrlSettings();
        Assert.Throws<FormatException>(() => URLShortener.Shorten(url, urlSettings));
    }

    private static ShrinkUrlSettings CreateUrlSettings() =>
        new() {
            BaseUrl = "https://example.co/",
            MaxLength = 6
        };
}