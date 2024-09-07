# ResponseCache

ResponseCache is a .NET Core library designed to enhance the performance of web APIs by caching responses. It simplifies the process of implementing caching strategies, helping to reduce load times and improve scalability.

## Features

- **Easy Integration**: Seamlessly integrates with ASP.NET Core applications.
- **Flexible Caching**: Supports various caching strategies like in-memory, distributed, and more.
- **Customizable**: Easily configure cache duration, key generation, and eviction policies.
- **Enhanced Performance**: Reduces server load by serving cached responses for repeated requests.
- **Minimal Setup**: Simple to set up and use with minimal configuration.

## Getting Started

### Prerequisites

- [.NET Core 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Basic knowledge of ASP.NET Core

### Installation

To install ResponseCache, add the package via NuGet Package Manager:

```bash
dotnet add package ResponseCache
```

Or edit your `.csproj` file to include:

```xml
<PackageReference Include="ResponseCache" Version="1.0.0" />
```

### Usage

1. **Configure Services**: Add the `ResponseCache` service in your `Startup.cs` or `Program.cs`:

    ```csharp
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddResponseCaching(); // Add ResponseCaching service
    }
    ```

2. **Apply Caching**: Use the `[ResponseCache]` attribute on your controllers or actions:

    ```csharp
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet]
        [ResponseCache(Duration = 60)] // Cache response for 60 seconds
        public IEnumerable<WeatherForecast> Get()
        {
            // Your logic here
        }
    }
    ```

3. **Advanced Configuration**: Customize caching settings using the `ResponseCacheOptions`:

    ```csharp
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddResponseCaching(options =>
        {
            options.UseInMemoryCache = true; // Choose in-memory caching
            options.DefaultDuration = 120;   // Default cache duration
        });
    }
    ```

### Running Tests

To run the unit tests, use the following command:

```bash
dotnet test
```

## Contributing

Contributions are welcome! Please follow these steps:

1. Fork the repository.
2. Create a new branch (`git checkout -b feature/YourFeature`).
3. Commit your changes (`git commit -am 'Add new feature'`).
4. Push to the branch (`git push origin feature/YourFeature`).
5. Open a pull request.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## Contact

For any inquiries or issues, please open an issue on GitHub or contact me at [your email address].

---

**Note**: This project is still in development. Contributions and suggestions are highly appreciated!
