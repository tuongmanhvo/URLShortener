using Microsoft.Extensions.Options;

namespace URLShortenAPI {
    public static class URLShortenSettings {
        public static IServiceCollection AddShrinkUrlSettings(this IServiceCollection services, IConfiguration configuration) {
            services.Configure<ShrinkUrlSettings>(configuration.GetSection(nameof(ShrinkUrlSettings)));
            services.AddSingleton(provider => provider.GetRequiredService<IOptions<ShrinkUrlSettings>>().Value);

            return services;
        }
    }
    public class ShrinkUrlSettings {
        public string BaseUrl { get; set; } = string.Empty;
        public int MaxLength { get; set; }
    }
}
