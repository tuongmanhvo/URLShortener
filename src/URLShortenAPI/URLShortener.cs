namespace URLShortenAPI;
public class URLShortener {
    public static string Shorten(string? url, ShrinkUrlSettings urlSettings) {
        url = url?.Trim();
        ArgumentException.ThrowIfNullOrEmpty(url);

        if (!TryGetValidURL(url, out Uri? uri)) throw new FormatException();

        url = RemovePrefixUrl(uri!);

        var urlBuilder = new UriBuilder(urlSettings.BaseUrl) {
            Path = Cryptography.EncryptUrl(url, urlSettings.MaxLength)
        };
        return urlBuilder.Uri.ToString();
    }

    private static string RemovePrefixUrl(Uri uri) {
        var host = uri.Host;
        if (uri.Host.StartsWith("www.")) {
            host = host[4..];
        }
        return host + uri.LocalPath;
    }

    public static bool TryGetValidURL(string url, out Uri? uriResult) =>
        Uri.TryCreate(url, UriKind.Absolute, out uriResult)
        && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
}