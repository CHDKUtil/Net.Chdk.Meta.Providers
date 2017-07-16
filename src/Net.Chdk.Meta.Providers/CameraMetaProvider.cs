using System;
using System.Collections.Generic;
using System.Linq;

namespace Net.Chdk.Meta.Providers
{
    sealed class CameraMetaProvider : ICameraMetaProvider
    {
        private IEnumerable<IProductCameraMetaProvider> CameraProviders { get; }

        public CameraMetaProvider(IEnumerable<IProductCameraMetaProvider> cameraProviders)
        {
            CameraProviders = cameraProviders;
        }

        public CameraInfo GetCamera(string productName, string fileName)
        {
            var provider = CameraProviders.SingleOrDefault(p => productName.Equals(p.ProductName, StringComparison.Ordinal));
            if (provider == null)
                throw new InvalidOperationException($"Unknown product: {productName}");
            return provider.GetCamera(fileName);
        }
    }
}
