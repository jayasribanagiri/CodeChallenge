using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;


namespace CodeChallenge.Features
{
    public static class FileConfigurationExtensions
    {
        public const string FileProviderKey = "FileProvider";

        public const string FileLoadExceptionHandlerKey = "FileLoadExceptionHandler";

       
        public static IConfigurationBuilder SetFileProvider(this IConfigurationBuilder builder, Microsoft.Extensions.FileProviders.IFileProvider fileProvider)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));
            if (fileProvider == null)
                throw new ArgumentNullException(nameof(fileProvider));

            builder.Properties["FileProvider"] = fileProvider;
            return builder;
        }
       // System.ThrowHelper.ThrowIfNull(builder, "builder");
          //  System.ThrowHelper.ThrowIfNull(fileProvider, "fileProvider");
           // builder.Properties["FileProvider"] = fileProvider;
          //  return builder;
      //  }

        internal static Microsoft.Extensions.FileProviders.IFileProvider? GetUserDefinedFileProvider(this IConfigurationBuilder builder)
        {
            if (!builder.Properties.TryGetValue("FileProvider", out object value))
            {
                return null;
            }

            return (IFileProvider)value;
        }

        //
        // Summary:
        //     Gets the default Microsoft.Extensions.FileProviders.IFileProvider to be used
        //     for file-based providers.
        //
        // Parameters:
        //   builder:
        //     The Microsoft.Extensions.Configuration.IConfigurationBuilder.
        //
        // Returns:
        //     The default Microsoft.Extensions.FileProviders.IFileProvider.
        public static IFileProvider GetFileProvider(this IConfigurationBuilder builder)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            return builder.GetUserDefinedFileProvider() ?? new PhysicalFileProvider(AppContext.BaseDirectory ?? string.Empty);
        }
       // System.ThrowHelper.ThrowIfNull(builder, "builder");
          //  return builder.GetUserDefinedFileProvider() ?? new PhysicalFileProvider(AppContext.BaseDirectory ?? string.Empty);
       // }

        //
        // Summary:
        //     Sets the FileProvider for file-based providers to a PhysicalFileProvider with
        //     the base path.
        //
        // Parameters:
        //   builder:
        //     The Microsoft.Extensions.Configuration.IConfigurationBuilder to add to.
        //
        //   basePath:
        //     The absolute path of file-based providers.
        //
        // Returns:
        //     The Microsoft.Extensions.Configuration.IConfigurationBuilder.
        public static IConfigurationBuilder SetBasePath(this IConfigurationBuilder builder, string basePath)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));
            if (basePath == null)
                throw new ArgumentNullException(nameof(basePath));

            return builder.SetFileProvider(new PhysicalFileProvider(basePath));
        }
    
        //
        // Summary:
        //     Sets a default action to be invoked for file-based providers when an error occurs.
        //
        //
        // Parameters:
        //   builder:
        //     The Microsoft.Extensions.Configuration.IConfigurationBuilder to add to.
        //
        //   handler:
        //     The Action to be invoked on a file load exception.
        //
        // Returns:
        //     The Microsoft.Extensions.Configuration.IConfigurationBuilder.
        public static IConfigurationBuilder SetFileLoadExceptionHandler(this IConfigurationBuilder builder, Action<FileLoadExceptionContext> handler)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));
            if (handler == null)
                throw new ArgumentNullException(nameof(handler));

            builder.Properties["FileLoadExceptionHandler"] = handler;
            return builder;
        }

        //
        // Summary:
        //     Gets a default action to be invoked for file-based providers when an error occurs.
        //
        //
        // Parameters:
        //   builder:
        //     The Microsoft.Extensions.Configuration.IConfigurationBuilder.
        //
        // Returns:
        //     The The Action to be invoked on a file load exception, if set.
        public static Action<FileLoadExceptionContext>? GetFileLoadExceptionHandler(this IConfigurationBuilder builder)
        {
            if(builder == null)
            throw new ArgumentNullException(nameof(builder));

            if (builder.Properties.TryGetValue("FileLoadExceptionHandler", out object value))
            {
                return value as Action<FileLoadExceptionContext>;
            }

            return null;
        }
    }
}
#if false // Decompilation log
'196' items in cache
------------------
Resolve: 'System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Found single assembly: 'System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Load from: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.4\ref\net8.0\System.Runtime.dll'
------------------
Resolve: 'System.Runtime.InteropServices, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Found single assembly: 'System.Runtime.InteropServices, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Load from: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.4\ref\net8.0\System.Runtime.InteropServices.dll'
------------------
Resolve: 'Microsoft.Extensions.Configuration.Abstractions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60'
Found single assembly: 'Microsoft.Extensions.Configuration.Abstractions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60'
Load from: 'C:\Users\dgl95\.nuget\packages\microsoft.extensions.configuration.abstractions\8.0.0\lib\net8.0\Microsoft.Extensions.Configuration.Abstractions.dll'
------------------
Resolve: 'Microsoft.Extensions.FileProviders.Abstractions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60'
Found single assembly: 'Microsoft.Extensions.FileProviders.Abstractions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60'
Load from: 'C:\Users\dgl95\.nuget\packages\microsoft.extensions.fileproviders.abstractions\8.0.0\lib\net8.0\Microsoft.Extensions.FileProviders.Abstractions.dll'
------------------
Resolve: 'Microsoft.Extensions.Configuration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60'
Found single assembly: 'Microsoft.Extensions.Configuration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60'
Load from: 'C:\Users\dgl95\.nuget\packages\microsoft.extensions.configuration\8.0.0\lib\net8.0\Microsoft.Extensions.Configuration.dll'
------------------
Resolve: 'Microsoft.Extensions.Primitives, Version=8.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60'
Found single assembly: 'Microsoft.Extensions.Primitives, Version=8.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60'
Load from: 'C:\Users\dgl95\.nuget\packages\microsoft.extensions.primitives\8.0.0\lib\net8.0\Microsoft.Extensions.Primitives.dll'
------------------
Resolve: 'Microsoft.Extensions.FileProviders.Physical, Version=8.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60'
Found single assembly: 'Microsoft.Extensions.FileProviders.Physical, Version=8.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60'
Load from: 'C:\Users\dgl95\.nuget\packages\microsoft.extensions.fileproviders.physical\8.0.0\lib\net8.0\Microsoft.Extensions.FileProviders.Physical.dll'
------------------
Resolve: 'System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Found single assembly: 'System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Load from: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.4\ref\net8.0\System.Collections.dll'
------------------
Resolve: 'System.Threading.Thread, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Found single assembly: 'System.Threading.Thread, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Load from: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.4\ref\net8.0\System.Threading.Thread.dll'
------------------
Resolve: 'System.Runtime.CompilerServices.Unsafe, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null'
Found single assembly: 'System.Runtime.CompilerServices.Unsafe, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Load from: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.4\ref\net8.0\System.Runtime.CompilerServices.Unsafe.dll'
#endif
